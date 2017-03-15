using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using JW.AUBE.Base.Constants;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Grid
{
	partial class XGrid
	{
		public event EventHandler DataSourceChanged;

		/// <summary>
		/// 그리드 뷰를 선택한 그리드뷰형태로 변환하여 MainView와 연결한다.
		/// </summary>
		private void SetGridView()
		{
			switch (GridViewType)
			{
				case GridViewType.GridView:
					Grid.MainView = _GridView;
					break;
				case GridViewType.BandedGridView:
					Grid.MainView = _BandedGridView;
					break;
				case GridViewType.AdvBandedGridView:
					Grid.MainView = _AdvBandedGridView;
					break;
				case GridViewType.CardView:
					Grid.MainView = _CardView;
					break;
				case GridViewType.LayoutView:
					Grid.MainView = _LayoutView;
					break;
				case GridViewType.TileView:
					Grid.MainView = _TileView;
					break;
				case GridViewType.WinExplorerView:
					Grid.MainView = _WinExplorerView;
					break;
				default:
					Grid.MainView = null;
					break;
			}
		}

		/// <summary>
		/// 인쇄미리보기
		/// </summary>
		public void PrintPreview()
		{
			var pageHeaderFooter = _PrintableComponentLink.PageHeaderFooter as PageHeaderFooter;
			pageHeaderFooter.Header.Content.Clear();
			pageHeaderFooter.Header.Content.AddRange(new string[] { PageHeaderLeft, PageHeaderCenter, PageHeaderRight });
			pageHeaderFooter.Header.LineAlignment = BrickAlignment.Far;

			pageHeaderFooter.Footer.Content.AddRange(new string[] { PageFooterLeft, PageFooterCenter, PageFooterRight });
			pageHeaderFooter.Footer.LineAlignment = BrickAlignment.Far;

			_PrintableComponentLink.Component = Grid;
			_PrintableComponentLink.CreateDocument(_PrintingSystem);
			_PrintableComponentLink.ShowPreview();
		}

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		public void Init()
		{
			if (MainView.GetType() == typeof(GridView) ||
				MainView.GetType() == typeof(BandedGridView) ||
				MainView.GetType() == typeof(AdvBandedGridView))
			{
				if (GlobalVar.Settings.GetValue("GRID_EVEN_AND_ODD").ToStringNullToEmpty() == "Y")
				{
					((GridView)Grid.MainView).OptionsView.EnableAppearanceEvenRow = true;
					((GridView)Grid.MainView).OptionsView.EnableAppearanceOddRow = true;
				}
				((GridView)Grid.MainView).OptionsView.ShowGroupPanel = false;
				((GridView)Grid.MainView).OptionsView.ShowDetailButtons = false;
				((GridView)Grid.MainView).OptionsSelection.EnableAppearanceFocusedRow = true;
				((GridView)Grid.MainView).OptionsSelection.EnableAppearanceFocusedCell = true;
				((GridView)Grid.MainView).FocusRectStyle = DrawFocusRectStyle.CellFocus;
				((GridView)Grid.MainView).OptionsSelection.MultiSelect = true;
				((GridView)Grid.MainView).OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
				((GridView)Grid.MainView).OptionsView.ColumnAutoWidth = false;
				((GridView)Grid.MainView).OptionsView.ShowFooter = false;
				((GridView)Grid.MainView).OptionsBehavior.ReadOnly = true;
				((GridView)Grid.MainView).OptionsBehavior.Editable = false;
				(Grid.MainView as GridView).OptionsView.ShowGroupPanel = false;
			}

			if (GlobalVar.Settings.GetValue("GRID_SKIN").IsNullOrEmpty() == false)
			{
				LookAndFeel.UseDefaultLookAndFeel = false;
				LookAndFeel.SkinName = GlobalVar.Settings.GetValue("GRID_SKIN").ToString();
			}
		}

		/// <summary>
		/// 그리드 컬럼을 추가하여 초기화
		/// </summary>
		/// <param name="columns">GridColumn 배열</param>
		public void Init(params GridColumn[] columns)
		{
			Init();

			if (columns != null && columns.Length > 0)
			{
				AddGridColumns(columns);
				BestFitColumns();
			}
		}

		/// <summary>
		/// 그리드 컬럼을 추가하여 초기화
		/// </summary>
		/// <param name="columns">XGridColumn 배열</param>
		public void Init(params XGridColumn[] columns)
		{
			Init(false, columns);
		}

		/// <summary>
		/// 편집가능여부, 그리드 컬럼 포함 그리드 초기화
		/// </summary>
		/// <param name="isEditable">편집여부</param>
		/// <param name="columns">XGridColumn 배열</param>
		public void Init(bool isEditable, params XGridColumn[] columns)
		{
			Init();

			MainView.OptionsBehavior.Editable = isEditable;

			if (columns != null && columns.Length > 0)
			{
				AddGridColumns(columns);
				BestFitColumns();
			}
		}

		/// <summary>
		/// 전체 그리드 컬럼의 Width를 자동으로 맞춘다.
		/// </summary>
		public void BestFitColumns()
		{
			if (GridViewType == GridViewType.GridView ||
				GridViewType == GridViewType.BandedGridView ||
				GridViewType == GridViewType.AdvBandedGridView)
			{
				((GridView)Grid.MainView).BestFitColumns();
			}
		}

		/// <summary>
		/// GridColumn 배열로 그리드의 컬럼을 추가한다.
		/// </summary>
		/// <param name="columns">GridColumn 배열</param>
		public void AddGridColumns(params GridColumn[] columns)
		{
			MainView.BeginUpdate();

			MainView.Columns.Clear();

			foreach (GridColumn col in columns)
			{
				if (string.IsNullOrEmpty(col.Caption))
				{
					col.Caption = DomainUtils.GetFieldName(col.FieldName);
				}
				col.OptionsColumn.AllowMerge = DefaultBoolean.False;
				col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
				col.CustomizationCaption = col.Caption;
				col.AppearanceHeader.Options.UseTextOptions = true;
				col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			}

			MainView.Columns.AddRange(columns);

			MainView.EndUpdate();
		}

		/// <summary>
		/// XGridColumn 배열로 그리드의 컬럼을 추가한다.
		/// </summary>
		/// <param name="columns">XGridColumn 배열</param>
		public void AddGridColumns(params XGridColumn[] columns)
		{
			MainView.BeginUpdate();

			MainView.Columns.Clear();

			foreach (XGridColumn column in columns)
			{
				if (MainView is BandedGridView || MainView is AdvBandedGridView)
				{
					AddBandColumn(column);
				}
				else
				{
					AddGridColumn(column);
				}
			}
			MainView.EndUpdate();
		}

		/// <summary>
		/// 그리드의 컬럼을 추가한다.
		/// </summary>
		/// <param name="column">XGridColumn</param>
		public void AddGridColumn(XGridColumn column)
		{
			//Caption
			if (string.IsNullOrEmpty(column.Caption))
			{
				if (!string.IsNullOrEmpty(column.CaptionCode))
				{
					column.Caption = DomainUtils.GetFieldName(column.CaptionCode);
				}
				else
				{
					column.Caption = DomainUtils.GetFieldName(column.FieldName);
				}
			}

			var gridColumn = new GridColumn()
			{
				Caption = column.Caption,
				FieldName = column.FieldName,
				UnboundType = column.ColumnType
			};

			gridColumn.OptionsColumn.AllowMerge = DefaultBoolean.False;
			gridColumn.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
			gridColumn.CustomizationCaption = gridColumn.Caption;
			gridColumn.AppearanceHeader.Options.UseTextOptions = true;
			gridColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			if (column.IsMandatory)
			{
				gridColumn.AppearanceHeader.Options.UseForeColor = true;
				if (SkinUtils.IsDarkSkin())
					gridColumn.AppearanceHeader.ForeColor = Color.Yellow;
				else
					gridColumn.AppearanceHeader.ForeColor = Color.Red;
				gridColumn.Tag = true;
			}
			else
			{
				gridColumn.AppearanceHeader.Options.UseForeColor = false;
				gridColumn.Tag = null;
			}
			gridColumn.AppearanceCell.Options.UseTextOptions = true;
			switch (column.FieldName)
			{
				case "ROW_NO":
				case "INS_TIME":
				case "INS_USER":
				case "INS_USER_NAME":
				case "UPD_TIME":
				case "UPD_USER":
				case "UPD_USER_NAME":
					gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
					break;
				default:
					if (column.FieldName.EndsWith("_DATE"))
						gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
					else
						gridColumn.AppearanceCell.TextOptions.HAlignment = column.HorzAlignment;
					break;
			}

			gridColumn.DisplayFormat.FormatType =
				gridColumn.GroupFormat.FormatType = column.FormatType;

			if (!string.IsNullOrEmpty(column.FormatString))
			{
				gridColumn.DisplayFormat.FormatString = column.FormatString;
				gridColumn.GroupFormat.FormatString = column.FormatString;
			}

			if (column.RepositoryItem != null)
			{
				gridColumn.ColumnEdit = column.RepositoryItem;
			}

			if ((column.IsSummary) &&
				(MainView.GetType() == typeof(GridView) || 
				 MainView.GetType() == typeof(BandedGridView) || 
				 MainView.GetType() == typeof(AdvBandedGridView)))
			{
				gridColumn.SummaryItem.SummaryType = column.SummaryItemType;
				gridColumn.SummaryItem.FieldName = column.FieldName;

				if (!string.IsNullOrEmpty(column.FormatString))
				{
					gridColumn.SummaryItem.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
				}

				if (column.IsSummaryGroup)
				{
					var item = new GridGroupSummaryItem()
					{
						FieldName = column.FieldName,
						ShowInGroupColumnFooter = gridColumn,
						ShowInGroupColumnFooterName = column.FieldName,
						SummaryType = column.SummaryItemType
					};

					if (!string.IsNullOrEmpty(column.FormatString))
					{
						item.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
					}
					GroupSummaryAdd(item);

					gridColumn.OptionsColumn.AllowGroup = DefaultBoolean.True;
				}
			}

			if (column.ReadOnly || MainView.OptionsBehavior.Editable == false)
			{
				gridColumn.OptionsColumn.ReadOnly = true;
				gridColumn.OptionsColumn.AllowEdit = false;
				gridColumn.OptionsColumn.AllowFocus = false;
			}
			else
			{
				gridColumn.OptionsColumn.ReadOnly = false;
				gridColumn.OptionsColumn.AllowEdit = true;
				gridColumn.OptionsColumn.AllowFocus = true;
			}

			if (column.Width > 0)
			{
				gridColumn.Width = column.Width;
				gridColumn.MinWidth = column.Width;
			}
			else
			{
				switch (column.FieldName)
				{
					case "ROW_NO":
						gridColumn.Width = 50;
						gridColumn.MinWidth = 50;
						break;
					case "INS_TIME":
					case "UPD_TIME":
						gridColumn.Width = 150;
						gridColumn.MinWidth = 150;
						break;
					case "INS_USER":
					case "UPD_USER":
						gridColumn.Width = 100;
						gridColumn.MinWidth = 100;
						break;
					case "INS_USER_NAME":
					case "UPD_USER_NAME":
						gridColumn.Width = 100;
						gridColumn.MinWidth = 100;
						break;
					default:
						if (column.FieldName.EndsWith("_DATE"))
						{
							gridColumn.Width = 100;
							gridColumn.MinWidth = 100;
						}
						else
						{
							gridColumn.BestFit();
						}
						break;
				}
			}
			gridColumn.Visible = column.Visible;

			if (column.Visible)
			{
				gridColumn.VisibleIndex = MainView.Columns.Count;
			}
			MainView.Columns.Add(gridColumn);
		}

		/// <summary>
		/// 그리드의 밴드에 컬럼을 추가한다.
		/// </summary>
		/// <param name="column">XGridColumn</param>
		public void AddBandColumn(XGridColumn column)
		{
			//Caption
			if (string.IsNullOrEmpty(column.Caption))
			{
				if (!string.IsNullOrEmpty(column.CaptionCode))
				{
					column.Caption = DomainUtils.GetFieldName(column.CaptionCode);
				}
				else
				{
					column.Caption = DomainUtils.GetFieldName(column.FieldName);
				}
			}

			var bandedColumn = new BandedGridColumn()
			{
				Caption = column.Caption,
				FieldName = column.FieldName,
				UnboundType = column.ColumnType
			};

			bandedColumn.OptionsColumn.AllowMerge = DefaultBoolean.False;
			bandedColumn.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
			bandedColumn.CustomizationCaption = bandedColumn.Caption;
			bandedColumn.AppearanceHeader.Options.UseTextOptions = true;
			bandedColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			bandedColumn.AppearanceCell.Options.UseTextOptions = true;
			bandedColumn.AppearanceCell.TextOptions.HAlignment = column.HorzAlignment;

			bandedColumn.DisplayFormat.FormatType =
				bandedColumn.GroupFormat.FormatType = column.FormatType;

			if (!string.IsNullOrEmpty(column.FormatString))
			{
				bandedColumn.DisplayFormat.FormatString = column.FormatString;
				bandedColumn.GroupFormat.FormatString = column.FormatString;
			}

			if (column.RepositoryItem != null)
			{
				bandedColumn.ColumnEdit = column.RepositoryItem;
			}

			if ((column.IsSummary) &&
				(MainView.GetType() == typeof(GridView) || MainView.GetType() == typeof(BandedGridView) || MainView.GetType() == typeof(AdvBandedGridView)))
			{
				bandedColumn.SummaryItem.SummaryType = column.SummaryItemType;
				bandedColumn.SummaryItem.FieldName = column.FieldName;

				if (!string.IsNullOrEmpty(column.FormatString))
				{
					bandedColumn.SummaryItem.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
				}

				if (column.IsSummaryGroup)
				{
					var item = new GridGroupSummaryItem()
					{
						FieldName = column.FieldName,
						ShowInGroupColumnFooter = bandedColumn,
						ShowInGroupColumnFooterName = column.FieldName,
						SummaryType = column.SummaryItemType
					};

					if (!string.IsNullOrEmpty(column.FormatString))
					{
						item.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
					}
					GroupSummaryAdd(item);

					bandedColumn.OptionsColumn.AllowGroup = DefaultBoolean.True;
				}
			}

			if (column.ReadOnly || MainView.OptionsBehavior.Editable == false)
			{
				bandedColumn.OptionsColumn.ReadOnly = true;
				bandedColumn.OptionsColumn.AllowEdit = false;
				bandedColumn.OptionsColumn.AllowFocus = false;
			}
			else
			{
				bandedColumn.OptionsColumn.ReadOnly = false;
				bandedColumn.OptionsColumn.AllowEdit = true;
				bandedColumn.OptionsColumn.AllowFocus = true;
			}

			if (column.Width > 0)
			{
				bandedColumn.Width = column.Width;
				bandedColumn.MinWidth = column.Width;
			}

			bandedColumn.Visible = column.Visible;

			if (column.Visible)
			{
				bandedColumn.VisibleIndex = MainView.Columns.Count;
			}
			MainView.Columns.Add(bandedColumn);
		}

		/// <summary>
		/// 그리드의 밴드를 추가한다.
		/// </summary>
		/// <param name="bands">GridBand의 배열</param>
		public void BandsAdd(params GridBand[] bands)
		{
			if (MainView.GetType() != typeof(BandedGridView) && MainView.GetType() != typeof(AdvBandedGridView))
			{
				return;
			}
			MainView.BeginUpdate();
			((BandedGridView)MainView).Bands.AddRange(bands);
			MainView.EndUpdate();
		}

		/// <summary>
		/// 그리드 밴드와 컬럼 설정
		/// </summary>
		/// <param name="band">GridBand</param>
		/// <param name="columns">컬럼명 배열</param>
		public void SetBandAndColumns(GridBand band, params string[] columns)
		{
			if (MainView.GetType() != typeof(BandedGridView) && MainView.GetType() != typeof(AdvBandedGridView))
			{
				return;
			}
			var view = MainView as BandedGridView;
			view.BeginUpdate();

			if (band.Caption.IsNullOrEmpty())
			{
				band.Caption = DomainUtils.GetFieldName(band.Name);
			}
			band.AppearanceHeader.Options.UseTextOptions = true;
			band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			band.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

			if (view.Bands.Where(x => x.Name == band.Name).Any() == false)
			{
				view.Bands.Add(band);
			}
			if (columns != null && columns.Length > 0)
			{
				var width = 0;
				view.Columns.Cast<BandedGridColumn>().Where(x => columns.Contains(x.FieldName)).ToList().ForEach(x =>
				{
					x.OwnerBand = band;
					if (x.Visible)
					{
						width += x.Width;
					}
					x.CustomizationCaption = (band.Caption.Trim().IsNullOrEmpty() == false) ? string.Format("{0}-{1}", band.Caption, x.Caption) : x.Caption;
				});
				band.Width = width;
			}
			view.EndUpdate();
		}

		/// <summary>
		/// 새로운 라인을 생성한다.
		/// </summary>
		/// <returns>추가한 Row번호</returns>
		public int AddNewRow()
		{
			if (MainView.DataSource == null)
			{
				var dt = new DataTable();
				foreach (GridColumn col in MainView.Columns)
				{
					dt.Columns.Add(col.FieldName, col.ColumnType);
				}
				var dr = dt.NewRow();
				dt.Rows.Add(dr);
				DataSource = dt;
			}
			else
			{
				MainView.PostEditor();
				MainView.UpdateCurrentRow();
				var dt = (DataTable)DataSource;
				var dr = dt.NewRow();
				dt.Rows.Add(dr);
				DataSource = dt;
			}
			MainGrid.RefreshDataSource();
			return MainView.RowCount - 1;
		}
		
		/// <summary>
		/// 그리드 컬럼의 편집여부 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="editable">편집여부</param>
		public void SetColumnEditable(string fieldName, bool editable)
		{
			MainView.Columns[fieldName].OptionsColumn.ReadOnly = !editable;
			MainView.Columns[fieldName].OptionsColumn.AllowEdit = editable;
			MainView.Columns[fieldName].OptionsColumn.AllowFocus = editable;

			if (editable)
			{
				MainView.Columns[fieldName].Caption = MainView.Columns[fieldName].Caption.Replace("**", string.Empty) + "**";
			}

			SetEditStyle();
		}

		/// <summary>
		/// 그리드 편집 여부 설정
		/// </summary>
		/// <param name="editable">편집여부</param>
		public void SetEditable(bool editable)
		{
			Editable = editable;
			ReadOnly = !editable;
			SetEditStyle();
		}

		/// <summary>
		/// 편집 가능한 컬럼 배열 설정
		/// </summary>
		/// <param name="columns">컬럼명 배열</param>
		public void SetEditable(params string[] columns)
		{
			if (columns != null && columns.Length > 0)
			{
				SetEditable(true);
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col) && IsExitsColumn(col))
					{
						SetColumnEditable(col, true);
					}
				}
			}
			SetEditStyle();
		}

		/// <summary>
		/// 편집 가능한 컬럼 배열 설정
		/// </summary>
		/// <param name="isEdit">편집여부</param>
		/// <param name="columns">컬럼명 배열</param>
		public void SetEditable(bool isEdit, params string[] columns)
		{
			if (columns != null && columns.Length > 0)
			{
				SetEditable(true);
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col) && IsExitsColumn(col))
					{
						SetColumnEditable(col, isEdit);
					}
				}
			}
			SetEditStyle();
		}

		/// <summary>
		/// 컬럼 RepositoryItem 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="item">RepositoryItem</param>
		public void SetColumnEdit(string fieldName, RepositoryItem item)
		{
			MainView.Columns[fieldName].ColumnEdit = item;
			MainView.Columns[fieldName].ColumnEdit.EditValueChanged += RepositoryItemEditValueChanged;
		}

		/// <summary>
		/// RepositoryItem 값 변경 이벤트
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">EventArgs</param>
		private void RepositoryItemEditValueChanged(object sender, EventArgs e)
		{
			MainView.PostEditor();
		}

		/// <summary>
		/// 그리드 편집가능 셀 스타일 설정
		/// </summary>
		private void SetEditStyle()
		{
			//if (MainView.GetType() == typeof(GridView))
			//{
			//	var view = MainView as GridView;
			//	var bEditable = false;

			//	bEditable = view.Columns.Cast<GridColumn>().Where(x => x.OptionsColumn.AllowEdit == true).Any();

			//	view.Appearance.FocusedCell.BorderColor = Color.Red;
			//	view.Appearance.FocusedCell.BackColor = SkinUtils.EditBackColor;
			//	view.Appearance.FocusedCell.ForeColor = SkinUtils.EditForeColor;
			//	view.Appearance.FocusedCell.Options.UseBorderColor = bEditable;
			//	view.Appearance.FocusedCell.Options.UseBackColor = bEditable;
			//}
		}

		/// <summary>
		/// 그리드에 컬럼 존재 여부
		/// </summary>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public bool IsExitsColumn(string fieldName)
		{
			return MainView.Columns.Cast<GridColumn>().Any(x => x.FieldName == fieldName);
		}

		/// <summary>
		/// 그리드 데이터 초기화
		/// </summary>
		public void Clear()
		{
			if (DataSource != null && DataSource is DataTable)
			{
				(DataSource as DataTable).Rows.Clear();
				MainView.RefreshData();
			}
		}

		/// <summary>
		/// 그리드 컬럼 초기화
		/// </summary>
		public void ColumnClear()
		{
			DataSource = null;
			MainView.Columns.Clear();
		}

		/// <summary>
		/// 그리드 Readonly 설정
		/// </summary>
		/// <param name="bEnable"></param>
		public void SetEnable(bool bEnable = false)
		{
			MainView.OptionsBehavior.ReadOnly = !bEnable;
		}

		/// <summary>
		/// 그리드 뷰의 값 적용
		/// </summary>
		public void PostEditor()
		{
			MainView.PostEditor();
		}

		/// <summary>
		/// 현재 Row의 값 Update
		/// </summary>
		public void UpdateCurrentRow()
		{
			MainView.UpdateCurrentRow();
		}

		/// <summary>
		/// 엑셀변환
		/// </summary>
		public void ExportToXlsx()
		{
			try
			{
				if (MainView.RowCount == 0)
				{
					MsgBox.Show("엑셀 내보내기할 데이터가 없습니다.");
					return;
				}

				var fileName = string.Format("{0}_{1}", ParentForm.Text, string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));

				fileName = fileName
					.Replace(@"\", string.Empty)
					.Replace(@"/", string.Empty)
					.Replace(@":", string.Empty)
					.Replace(@"*", string.Empty)
					.Replace(@"?", string.Empty)
					.Replace("\"", string.Empty)
					.Replace(@"<", string.Empty)
					.Replace(@">", string.Empty)
					.Replace(@"|", string.Empty)
				;

				var path = FileUtils.GetExportFilePath();
				if (string.IsNullOrEmpty(path))
				{
					path = @"C:\";
				}
				using (var savefile = new SaveFileDialog())
				{
					savefile.InitialDirectory = path;
					savefile.Title = "Save Grid Excel File";
					savefile.DefaultExt = "xlsx";
					savefile.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls|All files (*.*)|*.*";
					savefile.FileName = fileName;
					if (savefile.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					fileName = savefile.FileName;
				}

				path = Path.GetDirectoryName(fileName);
				FileUtils.SetExcelPath(path);

				MainView.ExportToXlsx(fileName);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 기본 레이아웃 파일명 가져오기
		/// </summary>
		/// <returns></returns>
		public string GetDefaultLayoutFileName()
		{
			return string.Format("{0}\\Layout_{1}_{2}.xml", GetDefaultLayoutPathName(), ParentForm.Name, Name);
		}

		/// <summary>
		/// 기본 레이아웃 경로명 가져오기
		/// </summary>
		/// <returns></returns>
		public string GetDefaultLayoutPathName()
		{
			return string.Format("{0}\\GridLayout", CommonConsts.APP_PATH);
		}

		/// <summary>
		/// 셀의 값 클립보드로 복사
		/// </summary>
		/// <param name="hitInfo"></param>
		public void CellToClipboard(GridHitInfo hitInfo)
		{
			try
			{
				var objVal = hitInfo.Column.View.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column);

				if (objVal.GetType().Equals(Type.GetType("System.Byte[]")))
				{
					var bArrayImg = (byte[])objVal;

					var img = Image.FromStream(new MemoryStream(bArrayImg));
					Clipboard.SetImage(img);
				}
				else
				{
					Clipboard.SetText(hitInfo.Column.View.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column).ToString());
				}
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 레지스트리에서 레이아웃 설정 가져오기
		/// </summary>
		public void RestoreLayoutToRegistry()
		{
			MainView.RestoreLayoutFromRegistry(GetDefaultLayoutPathName());
		}
		
		public void CheckSelect(bool isCheck, string columnName = null, string condition = null)
		{
			try
			{
				if (string.IsNullOrEmpty(columnName))
					columnName = "CHK_YN";

				if (MainView.DataSource == null)
					return;

				if (MainView.DataRowCount == 0)
					return;

				if (IsFiltered() == true && isCheck == true)
				{
					//기처리한 건 초기화
					((DataView)MainView.DataSource).Table
						.Select(columnName + "='Y'").ToList()
							.ForEach(r => r[columnName] = "N");

					for (int i = 0; i < MainView.DataRowCount; i++)
					{
						int rowHandle = MainView.GetVisibleRowHandle(i);
						((DataRowView)MainView.GetRow(rowHandle)).Row[columnName] = (isCheck) ? "Y" : "N";
					}
				}
				else
				{
					((DataView)MainView.DataSource).Table
						.Select(string.Format("{0}='{1}'{2}", columnName, (isCheck) ? "N" : "Y", string.IsNullOrEmpty(condition) ? "" : " AND " + condition)).ToList()
							.ForEach(r => r[columnName] = (isCheck) ? "Y" : "N");
				}
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 데이터 바인딩
		/// </summary>
		/// <param name="serverId">서비스ID</param>
		/// <param name="processId">프로세스ID</param>
		/// <param name="sqlId">SQL ID</param>
		/// <param name="param">파라미터</param>
		/// <param name="bestFit">자동맞춤여부</param>
		public void BindData(string serviceId = null, string processId = null, string sqlId = null, DataMap param = null, bool bestFit = false)
		{
			int rowIndex = this.MainView.FocusedRowHandle;
			this.DataSource = ServerRequest.SingleRequest(serviceId, processId, sqlId, param);
			if (this.DataSource == null)
			{
				this.EmptyDataTableBinding();
			}
			else
			{
				this.MainView.FocusedRowHandle = rowIndex;
				this.MainView.SelectRow(rowIndex);
			}

			if (bestFit)
			{
				BestFitColumns();
			}
		}
	}
}

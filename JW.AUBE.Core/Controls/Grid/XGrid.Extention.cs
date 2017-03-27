using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Grid
{
	partial class XGrid
	{
		/// <summary>
		/// CellValueChanged 이벤트 UpdateCurrentRow 여부
		/// </summary>
		private bool _IsUpdateCurrentRowByCellValueChangedEvent = true;

		/// <summary>
		/// 편집가능한 셀의 스타일 적용 여부
		/// </summary>
		private bool _IsEditableRowCellStyle = true;

		/// <summary>
		/// 현재 포커싱된 컬럼명
		/// </summary>
		private string _CurrentColumnName = String.Empty;

		/// <summary>
		/// Merge할 컬럼 리스트
		/// </summary>
		private List<string> _MergeColumns = new List<string>();

		/// <summary>
		/// Band Height
		/// </summary>
		private int _bandHeight = 0;

		/// <summary>
		/// 뷰의 DataSource 변경 이벤트
		/// </summary>
		public event EventHandler ViewDataSourceChanged;

		private void InitializeEvents()
		{
			_GridView.RowCellClick += GridViewRowCellClick;
			_BandedGridView.RowCellClick += GridViewRowCellClick;
			_AdvBandedGridView.RowCellClick += GridViewRowCellClick;

			_GridView.RowClick += GridViewRowClick;
			_BandedGridView.RowClick += GridViewRowClick;
			_AdvBandedGridView.RowClick += GridViewRowClick;

			_GridView.RowCellStyle += GridViewRowCellStyle;
			_BandedGridView.RowCellStyle += GridViewRowCellStyle;
			_AdvBandedGridView.RowCellStyle += GridViewRowCellStyle;

			_GridView.CellValueChanged += GridViewCellValueChanged;
			_BandedGridView.CellValueChanged += GridViewCellValueChanged;
			_AdvBandedGridView.CellValueChanged += GridViewCellValueChanged;

			_GridView.CellValueChanging += GridViewCellValueChanging;
			_BandedGridView.CellValueChanging += GridViewCellValueChanging;
			_AdvBandedGridView.CellValueChanging += GridViewCellValueChanging;

			_GridView.Click += GridViewClick;
			_BandedGridView.Click += GridViewClick;
			_AdvBandedGridView.Click += GridViewClick;

			_GridView.CustomDrawCell += GridViewCustomDrawCell;
			_BandedGridView.CustomDrawCell += GridViewCustomDrawCell;
			_AdvBandedGridView.CustomDrawCell += GridViewCustomDrawCell;

			_GridView.CustomRowCellEdit += GridViewCustomRowCellEdit;
			_BandedGridView.CustomRowCellEdit += GridViewCustomRowCellEdit;
			_AdvBandedGridView.CustomRowCellEdit += GridViewCustomRowCellEdit;

			_GridView.RowStyle += GridViewRowStyle;
			_BandedGridView.RowStyle += GridViewRowStyle;
			_AdvBandedGridView.RowStyle += GridViewRowStyle;
			_GridView.GridMenuItemClick += GridViewGridMenuItemClick;
			_BandedGridView.GridMenuItemClick += GridViewGridMenuItemClick;
			_AdvBandedGridView.GridMenuItemClick += GridViewGridMenuItemClick;

			_BandedGridView.CustomDrawBandHeader += BandedViewCustomDrawBandHeader;
			_AdvBandedGridView.CustomDrawBandHeader += BandedViewCustomDrawBandHeader;

			MainView.DataSourceChanged += delegate(object sender, EventArgs e)
			{
				if (ViewDataSourceChanged != null)
					ViewDataSourceChanged.Invoke(sender, e);
			};

			MainView.FocusedColumnChanged += MainViewFocusedColumnChanged;

			MainView.FocusedRowChanged += MainViewFocusedRowChanged;

			MainView.PrintExportProgress += MainViewGridMenuItemClick;

			MainView.PrintInitialize += MainViewPrintInitialize;

			MainView.SelectionChanged += MainViewSelectionChanged;

			MainView.ValidateRow += MainViewValidateRow;

			MainView.MouseDown += MainViewMouseDown;

			MainView.KeyDown += MainViewKeyDown;

			MainView.ColumnFilterChanged += delegate (object sender, EventArgs e)
			{
				if (MainView == null || MainView.DataSource == null || MainView.RowCount == 0)
				{
					return;
				}
			};

			MainGrid.HandleCreated += MainGridHandleCreated;
			MainGrid.HandleDestroyed += MainGridHandleDestroyed;

			_GridView.CellMerge += ViewCellMerge;
			_BandedGridView.CellMerge += ViewCellMerge;
			_AdvBandedGridView.CellMerge += ViewCellMerge;
		}

		private void ViewCellMerge(object sender, CellMergeEventArgs e)
		{
			if (_MergeColumns.Contains(e.Column.FieldName) == false) return;

			bool is_merge = false;
			int idx = _MergeColumns.IndexOf(e.Column.FieldName);
			if (idx > 0)
			{
				for (int i = 0; i < idx; i++)
				{
					string bas1 = this.GetValue(e.RowHandle1, _MergeColumns[i]) == null ? null : this.GetValue(e.RowHandle1, _MergeColumns[i]).ToString();
					string bas2 = this.GetValue(e.RowHandle2, _MergeColumns[i]) == null ? null : this.GetValue(e.RowHandle2, _MergeColumns[i]).ToString();
					is_merge = (bas1 == bas2);
					if (is_merge == false)
						break;
				}
			}
			else
			{
				is_merge = true;
			}
			string val_1 = this.GetValue(e.RowHandle1, e.Column.FieldName) == null ? null : this.GetValue(e.RowHandle1, e.Column.FieldName).ToString();
			string val_2 = this.GetValue(e.RowHandle2, e.Column.FieldName) == null ? null : this.GetValue(e.RowHandle2, e.Column.FieldName).ToString();
			e.Merge = (is_merge && (val_1 == val_2));
			e.Handled = true;
		}

		private void MainViewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				try
				{
					if (sender.GetType() != typeof(GridView))
					{
						return;
					}
					var view = sender as GridView;

					if (view.GetSelectedCells().Length == 1 || view.OptionsView.AllowCellMerge == true)
					{
						object val = view.GetRowCellDisplayText(view.FocusedRowHandle, _CurrentColumnName);
						Clipboard.SetText(val.ToString());

						e.Handled = true;
					}
				}
				catch
				{
				}
			}
		}

		private void MainViewMouseDown(object sender, MouseEventArgs e)
		{
			if (sender.GetType() != typeof(GridView))
			{
				return;
			}
			var view = sender as GridView;
			var hi = view.CalcHitInfo(e.Location);

			if (hi.InRowCell)
			{
				if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemButtonEdit))
				{
					view.FocusedRowHandle = hi.RowHandle;
					view.FocusedColumn = hi.Column;
					view.ShowEditor();
					var edit = (view.ActiveEditor as ButtonEdit);
					if (edit == null)
					{
						return;
					}
					var p = view.GridControl.PointToScreen(e.Location);
					p = edit.PointToClient(p);
					var ehi = (edit.GetViewInfo() as ButtonEditViewInfo).CalcHitInfo(p);
					if (ehi.HitTest == EditHitTest.Button)
					{
						var args = ehi.HitObject as EditorButtonObjectInfoArgs;
						var PerformClickMethod = typeof(RepositoryItemButtonEdit).GetMethod("RaiseButtonClick", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
						PerformClickMethod.Invoke(hi.Column.RealColumnEdit, new object[] { new ButtonPressedEventArgs(args.Button) });
						((DXMouseEventArgs)e).Handled = true;
					}
				}
				else if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemLookUpEdit))
				{
					view.FocusedRowHandle = hi.RowHandle;
					view.FocusedColumn = hi.Column;
					view.ShowEditor();
					var edit = (view.ActiveEditor as LookUpEdit);
					if (edit == null)
					{
						return;
					}
					var p = view.GridControl.PointToScreen(e.Location);
					p = edit.PointToClient(p);
					var ehi = (edit.GetViewInfo() as ButtonEditViewInfo).CalcHitInfo(p);
					if (ehi.HitTest == EditHitTest.Button)
					{
						edit.ShowPopup();
						((DXMouseEventArgs)e).Handled = true;
					}
				}
				else if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
				{
					view.FocusedRowHandle = hi.RowHandle;
					view.FocusedColumn = hi.Column;
					view.ShowEditor();
					var edit = (view.ActiveEditor as DateEdit);
					if (edit == null)
					{
						return;
					}
					var p = view.GridControl.PointToScreen(e.Location);
					p = edit.PointToClient(p);
					var ehi = (edit.GetViewInfo() as ButtonEditViewInfo).CalcHitInfo(p);
					if (ehi.HitTest == EditHitTest.Button)
					{
						edit.ShowPopup();
						((DXMouseEventArgs)e).Handled = true;
					}
				}
				else if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemSpinEdit))
				{
					view.FocusedRowHandle = hi.RowHandle;
					view.FocusedColumn = hi.Column;
					view.ShowEditor();
					var edit = (view.ActiveEditor as SpinEdit);
					if (edit == null)
					{
						return;
					}
					var p = view.GridControl.PointToScreen(e.Location);
					p = edit.PointToClient(p);
					var ehi = (edit.GetViewInfo() as ButtonEditViewInfo).CalcHitInfo(p);
					if (ehi.HitTest == EditHitTest.Button)
					{
						if ((ehi.HitObject as EditorButtonObjectInfoArgs).Button.Kind == ButtonPredefines.SpinUp)
						{
							edit.Value += edit.Properties.Increment;
						}
						else
						{
							if ((ehi.HitObject as EditorButtonObjectInfoArgs).Button.Kind == ButtonPredefines.SpinDown)
							{
								edit.Value -= edit.Properties.Increment;
							}
						}
						((DXMouseEventArgs)e).Handled = true;
					}
				}
				else if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemCheckEdit))
				{
					view.FocusedRowHandle = hi.RowHandle;
					view.FocusedColumn = hi.Column;
					view.ShowEditor();
					var edit = view.ActiveEditor as CheckEdit;
					if (edit == null)
					{
						return;
					}
					edit.Toggle();
					((DXMouseEventArgs)e).Handled = true;
				}
			}
		}

		#region CustomDrawBandHeader
		public event BandHeaderCustomDrawEventHandler CustomDrawBandHeader;
		private void BandedViewCustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
		{
			if (sender.GetType() != typeof(BandedGridView) || sender.GetType() != typeof(AdvBandedGridView))
			{
				return;
			}
			if (e.Band == null)
			{
				return;
			}
			CustomDrawBandHeader?.Invoke(sender, e);

			if (e.Band.Caption == string.Empty)
			{
				var rect = e.Bounds;
				if (_bandHeight == 0)
					_bandHeight = e.Bounds.Height + 2;

				rect.Height = _bandHeight;
				e.Info.Bounds = rect;
			}
		}
		#endregion

		#region GridHandleDestroyed
		public event EventHandler GridHandleDestroyed;
		private void MainGridHandleDestroyed(object sender, EventArgs e)
		{
			GridHandleDestroyed?.Invoke(sender, e);
		}
		#endregion

		#region GridHandleCreated
		public event EventHandler GridHandleCreated;
		private void MainGridHandleCreated(object sender, EventArgs e)
		{
			GridHandleCreated?.Invoke(sender, e);
		}
		#endregion

		#region ValidateRow
		public event ValidateRowEventHandler ValidateRow;
		private void MainViewValidateRow(object sender, ValidateRowEventArgs e)
		{
			ValidateRow?.Invoke(sender, e);
		}
		#endregion

		#region SelectionChanged
		public event SelectionChangedEventHandler SelectionChanged;
		private void MainViewSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SelectionChanged?.Invoke(sender, e);
		}
		#endregion

		#region RowStyle
		public event RowStyleEventHandler RowStyle;
		private void GridViewRowStyle(object sender, RowStyleEventArgs e)
		{
			RowStyle?.Invoke(sender, e);
		}
		#endregion

		#region PrintInitialize
		public event PrintInitializeEventHandler PrintInitialize;
		private void MainViewPrintInitialize(object sender, PrintInitializeEventArgs e)
		{
			PrintInitialize?.Invoke(sender, e);
		}
		#endregion

		public event ProgressChangedEventHandler PrintExportProgress;
		private void MainViewGridMenuItemClick(object sender, ProgressChangedEventArgs e)
		{
			PrintExportProgress?.Invoke(sender, e);
		}

		public event GridMenuItemClickEventHandler MenuItemClick;
		private void GridViewGridMenuItemClick(object sender, GridMenuItemClickEventArgs e)
		{
			MenuItemClick?.Invoke(sender, e);
		}

		public event FocusedRowChangedEventHandler FocusedRowChanged;
		private void MainViewFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			FocusedRowChanged?.Invoke(sender, e);
		}

		public event FocusedColumnChangedEventHandler FocusedColumnChanged;
		private void MainViewFocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
		{
			FocusedColumnChanged?.Invoke(sender, e);
		}

		public event CustomRowCellEditEventHandler CustomRowCellEdit;
		private void GridViewCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
		{
			CustomRowCellEdit?.Invoke(sender, e);
		}

		public event RowCellCustomDrawEventHandler CustomDrawCell;
		private void GridViewCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			CustomDrawCell?.Invoke(sender, e);
		}

		public event EventHandler ViewClick;
		private void GridViewClick(object sender, EventArgs e)
		{
			ViewClick?.Invoke(sender, e);
		}

		public event CellValueChangedEventHandler CellValueChanging;
		private void GridViewCellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			CellValueChanging?.Invoke(sender, e);
		}

		public event CellValueChangedEventHandler CellValueChanged;
		private void GridViewCellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			CellValueChanged?.Invoke(sender, e);
			if (_IsUpdateCurrentRowByCellValueChangedEvent)
			{
				MainView.UpdateCurrentRow();
			}
		}

		public event RowCellStyleEventHandler RowCellStyle;
		private void GridViewRowCellStyle(object sender, RowCellStyleEventArgs e)
		{
			if (_IsEditableRowCellStyle)
			{
				CellStyle(sender, e);
			}

			RowCellStyle?.Invoke(sender, e);
		}
		public void CellStyle(object sender, RowCellStyleEventArgs e)
		{
			if (sender.GetType() != typeof(GridView))
			{
				return;
			}
			try
			{
				var view = sender as GridView;
				var viewInfo = view.GetViewInfo() as GridViewInfo;
				var rowInfo = viewInfo.RowsInfo.FindRow(e.RowHandle) as GridDataRowInfo;

				if (rowInfo != null)
				{
					if (MainView.OptionsBehavior.ReadOnly)
					{
						if (rowInfo.Cells[e.Column] != null)
						{
							if (rowInfo.Cells[e.Column].Editor is RepositoryItemSpinEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemSpinEdit).Buttons.Count > 0)
							{
								(rowInfo.Cells[e.Column].Editor as RepositoryItemSpinEdit).Buttons[0].Visible = false;
							}
							else
							{
								if (rowInfo.Cells[e.Column].Editor is RepositoryItemButtonEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemButtonEdit).Buttons.Count > 0)
								{
									(rowInfo.Cells[e.Column].Editor as RepositoryItemButtonEdit).Buttons[0].Visible = false;
								}
								else
								{
									if (rowInfo.Cells[e.Column].Editor is RepositoryItemLookUpEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemLookUpEdit).Buttons.Count > 0)
									{
										(rowInfo.Cells[e.Column].Editor as RepositoryItemLookUpEdit).Buttons[0].Visible = false;
									}
								}
							}
						}
					}
					else
					{
						if (!e.Column.OptionsColumn.ReadOnly && rowInfo.Cells[e.Column] != null && rowInfo.Cells[e.Column].Editor != null && !rowInfo.Cells[e.Column].Editor.ReadOnly)
						{
							if (rowInfo.Cells[e.Column] != null)
							{
								if (rowInfo.Cells[e.Column].Editor is RepositoryItemSpinEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemSpinEdit).Buttons.Count > 0)
								{
									(rowInfo.Cells[e.Column].Editor as RepositoryItemSpinEdit).Buttons[0].Visible = true;
								}
								else
								{
									if (rowInfo.Cells[e.Column].Editor is RepositoryItemButtonEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemButtonEdit).Buttons.Count > 0)
									{
										(rowInfo.Cells[e.Column].Editor as RepositoryItemButtonEdit).Buttons[0].Visible = true;
									}
									else
									{
										if (rowInfo.Cells[e.Column].Editor is RepositoryItemLookUpEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemLookUpEdit).Buttons.Count > 0)
										{
											(rowInfo.Cells[e.Column].Editor as RepositoryItemLookUpEdit).Buttons[0].Visible = true;
										}
									}
								}
							}
						}
						else
						{
							if (rowInfo.Cells[e.Column] != null)
							{
								if (rowInfo.Cells[e.Column].Editor is RepositoryItemSpinEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemSpinEdit).Buttons.Count > 0)
								{
									(rowInfo.Cells[e.Column].Editor as RepositoryItemSpinEdit).Buttons[0].Visible = false;
								}
								else
								{
									if (rowInfo.Cells[e.Column].Editor is RepositoryItemButtonEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemButtonEdit).Buttons.Count > 0)
									{
										(rowInfo.Cells[e.Column].Editor as RepositoryItemButtonEdit).Buttons[0].Visible = false;
									}
									else
									{
										if (rowInfo.Cells[e.Column].Editor is RepositoryItemLookUpEdit && (rowInfo.Cells[e.Column].Editor as RepositoryItemLookUpEdit).Buttons.Count > 0)
										{
											(rowInfo.Cells[e.Column].Editor as RepositoryItemLookUpEdit).Buttons[0].Visible = false;
										}
									}
								}
							}
						}
					}
				}

				if (e.RowHandle == view.FocusedRowHandle)
				{
					e.Appearance.BackColor = SkinUtils.HighlightBackColor;
					e.Appearance.ForeColor = SkinUtils.HighlightForeColor;
				}
				else
				{
					var cell = viewInfo.GetGridCellInfo(e.RowHandle, e.Column);
					if (cell == null)
					{
						return;
					}
					if (!cell.IsMerged)
					{
						return;
					}
					foreach (GridCellInfo ci in cell.MergedCell.MergedCells)
					{
						if (ci.RowHandle == view.FocusedRowHandle)
						{
							e.Appearance.BackColor = SkinUtils.HighlightBackColor;
							e.Appearance.ForeColor = SkinUtils.HighlightForeColor;
							break;
						}
					}
				}
			}
			catch
			{
			}
		}

		public event RowClickEventHandler RowClick;
		private void GridViewRowClick(object sender, RowClickEventArgs e)
		{
			RowClick?.Invoke(sender, e);
		}

		public event RowCellClickEventHandler RowCellClick;
		private void GridViewRowCellClick(object sender, RowCellClickEventArgs e)
		{
			_CurrentColumnName = e.Column.FieldName;

			RowCellClick?.Invoke(sender, e);
		}

		/// <summary>
		/// GetValue
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		/// <returns>object형식의 값</returns>
		public object GetValue(int rowHandle, string fieldName)
		{
			return MainView.GetRowCellValue(rowHandle, fieldName);
		}

		/// <summary>
		/// GetValueToInt
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		/// <returns>Integer형식의 숫자</returns>
		public int GetValueToInt(int rowHandle, string fieldName)
		{
			return Convert.ToInt32(GetValue(rowHandle, fieldName));
		}

		/// <summary>
		/// GetValueToDecimal
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		/// <returns>Decimal형식의 숫자</returns>
		public decimal GetValueToDecimal(int rowHandle, string fieldName)
		{
			return Convert.ToDecimal(GetValue(rowHandle, fieldName));
		}

		/// <summary>
		/// GetValueToString
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		/// <returns>String형식의 값</returns>
		public string GetValueToString(int rowHandle, string fieldName)
		{
			return Convert.ToString(GetValue(rowHandle, fieldName));
		}

		/// <summary>
		/// GetValueToDateTime
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		/// <returns>DateTime형식의 값</returns>
		public DateTime GetValueToDateTime(int rowHandle, string fieldName)
		{
			return Convert.ToDateTime(GetValue(rowHandle, fieldName));
		}

		/// <summary>
		/// SetValue
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		/// <param name="value">object형식의 값</param>
		public void SetValue(int rowHandle, string fieldName, object value)
		{
			MainView.SetRowCellValue(rowHandle, fieldName, value);
		}

		/// <summary>
		/// 컬럼 Width 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="width">Width값</param>
		public void SetColumnWidth(string fieldName, int width)
		{
			MainView.Columns[fieldName].OptionsColumn.AllowSize = false;
			MainView.Columns[fieldName].Width = width;
		}

		/// <summary>
		/// 컬럼 Merge 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="merge">Merge여부</param>
		public void SetColumnMerge(string fieldName, DefaultBoolean merge)
		{
			MainView.Columns[fieldName].OptionsColumn.AllowMerge = merge;
		}

		/// <summary>
		/// 컬럼 배경색 설정
		/// </summary>
		/// <param name="color">색상값</param>
		/// <param name="columns">컬럼명 배열</param>
		public void SetColumnBackColor(Color color, params string[] columns)
		{
			if (columns != null && columns.Length > 0)
			{
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col) && MainView.Columns.Cast<GridColumn>().Where(x => x.FieldName.Equals(col)).Any())
					{
						MainView.Columns[col].AppearanceCell.BackColor = color;
					}
				}
			}
		}

		/// <summary>
		/// 컬럼 문자색 설정
		/// </summary>
		/// <param name="color">색상값</param>
		/// <param name="columns">컬럼명 배열</param>
		public void SetColumnForeColor(Color color, params string[] columns)
		{
			if (columns != null && columns.Length > 0)
			{
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col) && MainView.Columns.Cast<GridColumn>().Where(x => x.FieldName.Equals(col)).Any())
					{
						MainView.Columns[col].AppearanceCell.ForeColor = color;
					}
				}
			}
		}

		/// <summary>
		/// 포커스된 컬럼의 배경색 설정
		/// </summary>
		/// <param name="color">색상값</param>
		public void SetFocusedRowBackColor(Color color)
		{
			if (MainView.GetType() == typeof(GridView))
			{
				(MainView as GridView).Appearance.FocusedRow.Options.UseBackColor = true;
				(MainView as GridView).Appearance.FocusedRow.BackColor = color;
			}
		}

		/// <summary>
		/// 선택된 Row의 배경색 설정
		/// </summary>
		/// <param name="color">색상값</param>
		public void SetSelectedRowBackColor(Color color)
		{
			if (MainView.GetType() == typeof(GridView))
			{
				(MainView as GridView).Appearance.SelectedRow.Options.UseBackColor = true;
				(MainView as GridView).Appearance.SelectedRow.BackColor = color;
			}
		}

		/// <summary>
		/// 컬럼 Visible 설정
		/// </summary>
		/// <param name="visible">Visible여부</param>
		/// <param name="columns">컬럼명 배열</param>
		public void SetVisible(bool visible, params string[] columns)
		{
			foreach (string col in columns)
			{
				MainView.Columns[col].Visible = visible;
			}

			if (MainView is BandedGridView)
			{
				foreach (BandedGridColumn col in (MainView as BandedGridView).Columns.Where(x => columns.Contains(x.FieldName)))
				{
					if ((MainView as BandedGridView).Columns.OfType<BandedGridColumn>().Where(x => x.OwnerBand == col.OwnerBand && x.Visible == !visible).Any() == false)
					{
						col.OwnerBand.Visible = visible;
					}
				}
			}
		}

		/// <summary>
		/// 포커스 이동
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		/// <param name="fieldName">필드명</param>
		public void SetFocus(int rowHandle, string fieldName)
		{
			MainView.Focus();
			MainView.ClearSelection();
			MainView.SelectRow(rowHandle);
			MainView.FocusedColumn = MainView.Columns[fieldName];
			MainView.FocusedRowHandle = rowHandle;
			MainView.ShowEditor();
		}

		/// <summary>
		/// Row 포커스 이동
		/// </summary>
		/// <param name="rowHandle">Row번호</param>
		public void SetFocusRow(int rowHandle)
		{
			MainView.Focus();
			MainView.ClearSelection();
			MainView.SelectRow(rowHandle);
			MainView.FocusedRowHandle = rowHandle;
			MainView.ShowEditor();
		}

		/// <summary>
		/// 컬럼 Width 설정(컬럼고정 포함)
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="width">Width값</param>
		/// <param name="isFixed">고정여부</param>
		public void SetWidth(string fieldName, int width, bool isFixed = false)
		{
			if (MainView.Columns.Cast<GridColumn>().Where(x => x.FieldName == fieldName).Any())
			{
				MainView.Columns[fieldName].Width = width;
				MainView.Columns[fieldName].OptionsColumn.FixedWidth = isFixed;
			}
		}
		
		/// <summary>
		/// 컬럼 Width 자동 조정
		/// </summary>
		/// <param name="colName">컬럼명</param>
		public void BestFit(string colName)
		{
			if (MainView.Columns.Cast<GridColumn>().Where(x => x.FieldName == colName).Any())
			{
				MainView.Columns[colName].BestFit();
			}
		}

		/// <summary>
		/// 컬럼 고정
		/// </summary>
		/// <param name="colName">컬럼명</param>
		/// <param name="fixStyle">고정스타일</param>
		public void ColumnFix(string colName, FixedStyle fixStyle = FixedStyle.Left)
		{
			if (MainView.Columns.Cast<GridColumn>().Where(x => x.FieldName == colName).Any())
			{
				MainView.Columns[colName].Fixed = fixStyle;
			}
		}
		
		/// <summary>
		/// 헤더명 변경
		/// </summary>
		/// <param name="colName">컬럼명</param>
		/// <param name="caption">헤더명</param>
		public void SetCaption(string colName, string caption)
		{
			MainView.Columns[colName].Caption = caption;
		}

		/// <summary>
		/// 컬럼의 포맷 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="formatType">포맷유형</param>
		/// <param name="formatString">포맷문자열</param>
		public void SetFormat(string fieldName, FormatType formatType, string formatString)
		{
			MainView.Columns[fieldName].DisplayFormat.FormatType = formatType;
			MainView.Columns[fieldName].DisplayFormat.FormatString = formatString;
		}

		/// <summary>
		/// 컬럼 가로정렬 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="hAlign">정렬값</param>
		public void SetHorzAlign(string fieldName, HorzAlignment hAlign)
		{
			MainView.Columns[fieldName].AppearanceCell.Options.UseTextOptions = true;
			MainView.Columns[fieldName].AppearanceCell.TextOptions.HAlignment = hAlign;
		}

		/// <summary>
		/// 그리드 Merge여부 설정
		/// </summary>
		/// <param name="mergeYn">Merge여부</param>
		public void SetMerge(bool mergeYn)
		{
			if (MainView is GridView)
			{
				(MainView as GridView).OptionsView.AllowCellMerge = mergeYn;
			}
		}

		/// <summary>
		/// 컬럼 Merge 설정
		/// </summary>
		/// <param name="columns">컬럼명 배열</param>
		public void SetMerge(params string[] columns)
		{
			if (MainView is GridView)
			{
				var view = MainView as GridView;

				view.OptionsView.AllowCellMerge = true;
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col))
					{
						if (MainView.Columns.Where(x => x.FieldName == col).Any())
						{
							_MergeColumns.Add(col);
							SetCellMerge(col, DefaultBoolean.True);
						}
					}
				}
			}
		}

		/// <summary>
		/// 컬럼 셀 Merger 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="mergeYn">Merge여부</param>
		public void SetCellMerge(string fieldName, DefaultBoolean mergeYn)
		{
			if (IsExitsColumn(fieldName))
			{
				MainView.Columns[fieldName].OptionsColumn.AllowMerge = mergeYn;
			}
		}

		/// <summary>
		/// 변경된 Row 리스트 반환
		/// </summary>
		/// <returns>DataRow 리스트</returns>
		public List<DataRow> GetChangedRows()
		{
			List<DataRow> rows = null;
			if (MainGrid.DataSource != null && MainGrid.DataSource.GetType() == typeof(DataTable))
			{
				rows = (MainGrid.DataSource as DataTable).AsEnumerable().Where(row => row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added).ToList();
			}
			return rows;
		}

		/// <summary>
		/// 삭제된 Row 리스트 반환
		/// </summary>
		/// <returns>DataRow 리스트</returns>
		public List<DataRow> GetDeletedRows()
		{
			List<DataRow> rows = null;
			if (MainGrid.DataSource != null && MainGrid.DataSource.GetType() == typeof(DataTable))
			{
				rows = (MainGrid.DataSource as DataTable).AsEnumerable().Where(row => row.RowState == DataRowState.Deleted).ToList();
			}
			return rows;
		}

		/// <summary>
		/// 추가한 컬럼을 기준으로 빈 데이터테이블 바인딩
		/// </summary>
		/// <param name="isSetFormatType">컬럼포맷사용여부</param>
		public void EmptyDataTableBinding(bool isSetFormatType = false)
		{
			var dt = new DataTable();
			foreach (GridColumn column in MainView.Columns)
			{
				if (isSetFormatType)
				{
					if (column.DisplayFormat.FormatType == FormatType.DateTime)
					{
						dt.Columns.Add(column.FieldName, typeof(DateTime));
					}
					else
					{
						if (column.DisplayFormat.FormatType == FormatType.Numeric)
						{
							dt.Columns.Add(column.FieldName, typeof(Decimal));
						}
						else
						{
							dt.Columns.Add(column.FieldName, column.ColumnType);
						}
					}
				}
				else
				{
					dt.Columns.Add(column.FieldName, column.ColumnType);
				}
			}

			DataSource = dt;
		}

		/// <summary>
		/// 필터링되지 않은 Row만 반환
		/// </summary>
		/// <returns>데이터테이블</returns>
		public DataTable GetFilteredData()
		{
			if (MainView == null)
			{
				return null;
			}
			if (MainView.ActiveFilter == null || !MainView.ActiveFilterEnabled
				|| MainView.ActiveFilter.Expression == string.Empty)
			{
				return (MainView.DataSource as DataView).Table;
			}
			var table = ((DataView)MainView.DataSource).Table;
			var filteredDataView = new DataView(table) { RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(MainView.ActiveFilterCriteria) };
			return filteredDataView.Table;
		}

		/// <summary>
		/// 필터링여부
		/// </summary>
		/// <returns>Boolean</returns>
		public bool IsFiltered()
		{
			if (MainView == null)
			{
				return false;
			}
			if (MainView.ActiveFilter == null || !MainView.ActiveFilterEnabled || MainView.ActiveFilter.Expression == string.Empty)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 컬럼존재여부
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <returns>Boolean</returns>
		public bool IsColumn(string fieldName)
		{
			return MainView.Columns.Where(x => x.FieldName.Equals(fieldName)).Any();
		}

		/// <summary>
		/// 데이터테이블 반환
		/// </summary>
		/// <returns>데이터테이블</returns>
		public DataTable GetDataTable()
		{
			if (MainView.DataSource == null)
			{
				return null;
			}
			else
			{
				return ((DataView)MainView.DataSource).Table;
			}
		}

		public void SelectRow(int rowIndex)
		{
			MainView.ClearSelection();
			MainView.SelectRow(rowIndex);
			MainView.FocusedRowHandle = rowIndex;
		}

		public void DeleteRow(int rowIndex)
		{
			if (rowIndex < 0)
				return;

			MainView.DeleteRow(rowIndex);
		}
	}
}

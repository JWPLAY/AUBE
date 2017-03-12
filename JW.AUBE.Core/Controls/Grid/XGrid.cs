using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraPrinting;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Utils;
using Microsoft.Win32;

namespace JW.AUBE.Core.Controls.Grid
{
	[ToolboxItem(true)]
	public partial class XGrid : XtraUserControl
	{
		private GridView _GridView;
		private BandedGridView _BandedGridView;
		private AdvBandedGridView _AdvBandedGridView;
		private CardView _CardView;
		private LayoutView _LayoutView;
		private TileView _TileView;
		private WinExplorerView _WinExplorerView;

		private PrintingSystem _PrintingSystem;
		private PrintableComponentLink _PrintableComponentLink;

		private GridViewType _GridViewType;

		public XGrid()
		{
			InitializeComponent();
			Initialize();
			InitializeEvents();

			_PrintableComponentLink.CreateReportHeaderArea += delegate (object sender, CreateAreaEventArgs e)
			{
				if (PrintHeader.IsNullOrEmpty() == false)
				{
					e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
					e.Graph.Font = new Font(SystemFonts.DefaultFont.FontFamily, 14f, FontStyle.Bold);
					var rect = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
					e.Graph.DrawString(PrintHeader, Color.Black, rect, BorderSide.None);
				}
			};
			_PrintableComponentLink.CreateReportFooterArea += delegate (object sender, CreateAreaEventArgs e)
			{
				if (PrintFooter.IsNullOrEmpty() == false)
				{
					e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
					e.Graph.Font = new Font(SystemFonts.DefaultFont.FontFamily, 10f, FontStyle.Regular);
					var rect = new RectangleF(0, e.Graph.ClientPageSize.Height - 50, e.Graph.ClientPageSize.Width, 50);
					e.Graph.DrawString(PrintHeader, Color.Black, rect, BorderSide.None);
				}
			};

			_GridView.PopupMenuShowing += GridViewPopupMenuShowing;
			_BandedGridView.PopupMenuShowing += BandedGridViewPopupMenuShowing;
			_AdvBandedGridView.PopupMenuShowing += BandedGridViewPopupMenuShowing;

			GridLocalizer.Active = new KoreanGridLocalizer();

			Grid.DataSourceChanged += delegate (object sender, EventArgs e)
			{
				DataSourceChanged?.Invoke(sender, e);
			};
		}

		private void GridViewPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			try
			{
				var menu = e.Menu as GridViewMenu;
				if (menu == null)
				{
					return;
				}
				if (e.MenuType == GridMenuType.Column && e.HitInfo.InColumn)
				{
					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuColumnFrameLeftFix"), new EventHandler(GridViewMenuClicked))
					{
						BeginGroup = true,
						Tag = new XGridMenuItem() { Name = "FrameLeftFix", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuColumnFrameRightFix"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "FrameRightFix", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuColumnLeftFix"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "LeftFix", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuColumnRightFix"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "RightFix", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuColumnUnFix"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "UnFix", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuColumnsUnFix"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "UnFixAll", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuSaveLayout"), new EventHandler(GridViewMenuClicked))
					{
						BeginGroup = true,
						Tag = new XGridMenuItem() { Name = "SaveLayout", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuDeleteLayout"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "DeleteLayout", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuExportExcel"), new EventHandler(GridViewMenuClicked))
					{
						BeginGroup = true,
						Tag = new XGridMenuItem() { Name = "ExportExcel", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuCellMerge"), new EventHandler(GridViewMenuClicked))
					{
						BeginGroup = true,
						Tag = new XGridMenuItem() { Name = "CellMerge", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});

					if (e.HitInfo.Column.RealColumnEdit.GetType() == typeof(RepositoryItemCheckEdit) &&
						e.HitInfo.Column.OptionsColumn.AllowEdit == true &&
						e.HitInfo.Column.OptionsColumn.ReadOnly == false)
					{
						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuCheckAll"), new EventHandler(GridViewMenuClicked))
						{
							BeginGroup = true,
							Tag = new XGridMenuItem() { Name = "CheckAll", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
						});
						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuUnCheckAll"), new EventHandler(GridViewMenuClicked))
						{
							Tag = new XGridMenuItem() { Name = "UnCheckAll", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
						});
					}
				}

				if (e.MenuType == GridMenuType.Row && e.HitInfo.InRowCell)
				{
					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuCopyCell"), new EventHandler(GridViewMenuClicked))
					{
						Tag = new XGridMenuItem() { Name = "CopyCell", Column = e.HitInfo.Column, GridHitInfo = e.HitInfo }
					});
				}
			}
			catch
			{
				throw;
			}
		}

		private void BandedGridViewPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			try
			{
				var menu = e.Menu as GridViewMenu;
				if (menu == null)
				{
					return;
				}
				if (e.MenuType == GridMenuType.Column)
				{
					var hit = e.HitInfo as BandedGridHitInfo;
					if (hit != null)
					{
						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuBandFrameLeftFix"), new EventHandler(BandedViewMenuClicked))
						{
							BeginGroup = true,
							Tag = new XGridMenuItem()
							{
								Name = "FrameLeftFix",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuBandFrameRightFix"), new EventHandler(BandedViewMenuClicked))
						{
							Tag = new XGridMenuItem()
							{
								Name = "FrameRightFix",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuBandLeftFix"), new EventHandler(BandedViewMenuClicked))
						{
							Tag = new XGridMenuItem()
							{
								Name = "LeftFix",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuBandRightFix"), new EventHandler(BandedViewMenuClicked))
						{
							Tag = new XGridMenuItem()
							{
								Name = "RightFix",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuBandUnFix"), new EventHandler(BandedViewMenuClicked))
						{
							BeginGroup = true,
							Tag = new XGridMenuItem()
							{
								Name = "UnFix",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuBandsUnFix"), new EventHandler(BandedViewMenuClicked))
						{
							Tag = new XGridMenuItem()
							{
								Name = "UnFixAll",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuSaveLayout"), new EventHandler(BandedViewMenuClicked))
						{
							BeginGroup = true,
							Tag = new XGridMenuItem()
							{
								Name = "SaveLayout",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuDeleteLayout"), new EventHandler(BandedViewMenuClicked))
						{
							Tag = new XGridMenuItem()
							{
								Name = "DeleteLayout",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuExportExcel"), new EventHandler(BandedViewMenuClicked))
						{
							BeginGroup = true,
							Tag = new XGridMenuItem()
							{
								Name = "xportExcel",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuCellMerge"), new EventHandler(BandedViewMenuClicked))
						{
							BeginGroup = true,
							Tag = new XGridMenuItem()
							{
								Name = "CellMerge",
								Column = e.HitInfo.Column,
								Band = hit.Band ?? hit.Column.OwnerBand,
								GridHitInfo = e.HitInfo
							}
						});

						if (e.HitInfo.Column.RealColumnEdit.GetType() == typeof(RepositoryItemCheckEdit) &&
							e.HitInfo.Column.OptionsColumn.AllowEdit == true &&
							e.HitInfo.Column.OptionsColumn.ReadOnly == false)
						{
							menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuCheckAll"), new EventHandler(GridViewMenuClicked))
							{
								BeginGroup = true,
								Tag = new XGridMenuItem()
								{
									Name = "CheckAll",
									Column = e.HitInfo.Column,
									Band = hit.Band ?? hit.Column.OwnerBand,
									GridHitInfo = e.HitInfo
								}
							});
							menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuUnCheckAll"), new EventHandler(GridViewMenuClicked))
							{
								Tag = new XGridMenuItem()
								{
									Name = "UnCheckAll",
									Column = e.HitInfo.Column,
									Band = hit.Band ?? hit.Column.OwnerBand,
									GridHitInfo = e.HitInfo
								}
							});
						}
					}
				}

				if (e.MenuType == GridMenuType.Row && e.HitInfo.InRowCell)
				{
					var hit = e.HitInfo as BandedGridHitInfo;
					menu.Items.Add(new DXMenuItem(DomainUtils.GetPopMenuValue("MenuCopyCell"), new EventHandler(BandedViewMenuClicked))
					{
						Tag = new XGridMenuItem()
						{
							Name = "CopyCell",
							Column = e.HitInfo.Column,
							Band = hit.Band ?? hit.Column.OwnerBand,
							GridHitInfo = e.HitInfo
						}
					});
				}
			}
			catch
			{
			}
		}

		public void GroupSummaryAdd(GridSummaryItem item)
		{
			switch (GridViewType)
			{
				case GridViewType.GridView:
				case GridViewType.BandedGridView:
				case GridViewType.AdvBandedGridView:
					((GridView)MainView).GroupSummary.Add(item);
					break;
				default:
					break;
			}
		}

		private void GridViewMenuClicked(object sender, EventArgs e)
		{
			var item = sender as DXMenuItem;
			if (item.Tag == null)
			{
				return;
			}
			var data = item.Tag as XGridMenuItem;

			switch (data.Name)
			{
				case "FrameLeftFix":
					for (var i = data.Column.View.VisibleColumns.Count - 1; i > data.Column.VisibleIndex; i--)
					{
						if (data.Column.View.VisibleColumns[i].Fixed == FixedStyle.Left)
						{
							data.Column.View.VisibleColumns[i].Fixed = FixedStyle.None;
						}
					}
					for (var i = 0; i <= data.Column.VisibleIndex; i++)
					{
						data.Column.View.VisibleColumns[i].Fixed = FixedStyle.Left;
					}
					break;
				case "FrameRightFix":
					for (var i = data.Column.View.VisibleColumns.Count - 1; i > data.Column.VisibleIndex; i--)
					{
						if (data.Column.View.VisibleColumns[i].Fixed == FixedStyle.Left)
						{
							data.Column.View.VisibleColumns[i].Fixed = FixedStyle.None;
						}
					}
					for (var i = 0; i <= data.Column.VisibleIndex; i++)
					{
						data.Column.View.VisibleColumns[i].Fixed = FixedStyle.Left;
					}
					break;
				case "LeftFix":
					data.Column.Fixed = FixedStyle.Left;
					break;
				case "RightFix":
					data.Column.Fixed = FixedStyle.Right;
					break;
				case "UnFix":
					data.Column.Fixed = FixedStyle.None;
					break;
				case "UnFixAll":
					data.Column.View.Columns.Where(x => x.Fixed != FixedStyle.None).ToList().ForEach(x => x.Fixed = FixedStyle.None);
					break;
				case "SaveLayout":
					((GridView)MainView).SaveLayoutToRegistry(GetDefaultLayoutPathName());
					break;
				case "DeleteLayout":
					var registryKeyHKCU = Registry.CurrentUser;
					registryKeyHKCU.DeleteSubKeyTree(GetDefaultLayoutPathName());
					break;
				case "ExportExcel":
					ExportToXlsx();
					break;
				case "CellMerge":
					if (MainView.GetType() == typeof(GridView))
					{
						((GridView)MainView).OptionsView.AllowCellMerge = !((GridView)MainView).OptionsView.AllowCellMerge;
					}
					break;
				case "CopyCell":
					CellToClipboard(data.GridHitInfo);
					break;
				case "CheckAll":
					CheckSelect(true, data.GridHitInfo.Column.FieldName);
					break;
				case "UnCheckAll":
					CheckSelect(false, data.GridHitInfo.Column.FieldName);
					break;
			}
		}

		private void BandedViewMenuClicked(object sender, EventArgs e)
		{
			var item = sender as DXMenuItem;
			if (item.Tag == null)
			{
				return;
			}
			var data = item.Tag as XGridMenuItem;

			switch (data.Name)
			{
				case "FrameLeftFix":
					for (var i = data.Band.View.Bands.VisibleBandCount - 1; i > data.Band.Index; i--)
					{
						if (data.Band.View.Bands[i].Fixed == FixedStyle.Left)
						{
							data.Band.View.Bands[i].Fixed = FixedStyle.None;
						}
					}
					for (var i = 0; i <= data.Band.Index; i++)
					{
						data.Band.View.Bands[i].Fixed = FixedStyle.Left;
					}
					break;
				case "FrameRightFix":
					for (var i = 0; i < data.Band.Index; i++)
					{
						if (data.Band.View.Bands[i].Fixed == FixedStyle.Right)
						{
							data.Band.View.Bands[i].Fixed = FixedStyle.None;
						}
					}
					for (var i = data.Band.View.Bands.VisibleBandCount - 1; i >= data.Band.Index; i--)
					{
						data.Band.View.Bands[i].Fixed = FixedStyle.Right;
					}
					break;
				case "LeftFix":
					data.Band.Fixed = FixedStyle.Left;
					break;
				case "RightFix":
					data.Band.Fixed = FixedStyle.Right;
					break;
				case "UnFix":
					data.Band.Fixed = FixedStyle.None;
					break;
				case "UnFixAll":
					data.Band.View.Bands.Where(x => x.Fixed != FixedStyle.None).ToList().ForEach(x => x.Fixed = FixedStyle.None);
					break;
				case "SaveLayout":
					MainView.SaveLayoutToRegistry(GetDefaultLayoutPathName());
					break;
				case "DeleteLayout":
					var registryKeyHKCU = Registry.CurrentUser;
					registryKeyHKCU.DeleteSubKeyTree(GetDefaultLayoutPathName());
					break;
				case "ExportExcel":
					ExportToXlsx();
					break;
				case "CellMerge":
					if (MainView.GetType() == typeof(BandedGridView) || MainView.GetType() == typeof(AdvBandedGridView))
					{
						((BandedGridView)MainView).OptionsView.AllowCellMerge = !((BandedGridView)MainView).OptionsView.AllowCellMerge;
					}
					break;
				case "CopyCell":
					CellToClipboard(data.GridHitInfo);
					break;
			}
		}

		private void Initialize()
		{
			_GridView = new GridView() { Name = "GridView" };
			_BandedGridView = new BandedGridView() { Name = "BandedGridView" };
			_AdvBandedGridView = new AdvBandedGridView() { Name = "AdvBandedGridView" };
			_CardView = new CardView() { Name = "CardView" };
			_LayoutView = new LayoutView() { Name = "LayoutView" };
			_TileView = new TileView() { Name = "TileView" };
			_WinExplorerView = new WinExplorerView() { Name = "WinExplorerView" };

			_GridView.GridControl = Grid;
			_BandedGridView.GridControl = Grid;
			_AdvBandedGridView.GridControl = Grid;
			_CardView.GridControl = Grid;
			_LayoutView.GridControl = Grid;
			_TileView.GridControl = Grid;
			_WinExplorerView.GridControl = Grid;

			Grid.ViewCollection.AddRange(new BaseView[] 
			{   _GridView,
				_BandedGridView,
				_AdvBandedGridView,
				_CardView,
				_LayoutView,
				_TileView,
				_WinExplorerView
			});
			Grid.MainView = _GridView;

			View.OptionsView.ShowGroupPanel = false;
			_GridView.OptionsView.ShowGroupPanel = false;
			_BandedGridView.OptionsView.ShowGroupPanel = false;
			_AdvBandedGridView.OptionsView.ShowGroupPanel = false;

			if (View != null)
			{
				View.Dispose();
			}
			_PrintingSystem = new PrintingSystem();
			_PrintableComponentLink = new PrintableComponentLink(_PrintingSystem)
			{
				Component = Grid,
				PaperKind = PaperKind.A4
			};
		}

		[Browsable(false)]
		public GridControl MainGrid
		{
			get
			{
				return Grid;
			}
		}

		[Browsable(false)]
		public ColumnView MainView
		{
			get
			{
				ColumnView _view;
				switch (GridViewType)
				{
					case GridViewType.WinExplorerView:
						_view = _WinExplorerView;
						break;
					case GridViewType.TileView:
						_view = _TileView;
						break;
					case GridViewType.LayoutView:
						_view = _LayoutView;
						break;
					case GridViewType.CardView:
						_view = _CardView;
						break;
					case GridViewType.AdvBandedGridView:
						_view = _AdvBandedGridView;
						break;
					case GridViewType.BandedGridView:
						_view = _BandedGridView;
						break;
					default:
						_view = _GridView;
						break;
				}
				return _view;
			}
		}

		[Browsable(false)]
		public object DataSource
		{
			get
			{
				return Grid.DataSource;
			}
			set
			{
				Grid.DataSource = value;
			}
		}

		[Browsable(true)]
		public GridViewType GridViewType
		{
			get
			{
				return _GridViewType;
			}
			set
			{
				if (_GridViewType != value)
				{
					_GridViewType = value;
					SetGridView();
				}
			}
		}

		[Browsable(true)]
		public bool Compress
		{
			get; set;
		}

		[Browsable(true)]
		public bool ShowGroupPanel
		{
			get
			{
				bool _showGroupPanel = false;
				switch (GridViewType)
				{
					case GridViewType.GridView:
					case GridViewType.BandedGridView:
					case GridViewType.AdvBandedGridView:
						_showGroupPanel =((GridView)MainView).OptionsView.ShowGroupPanel;
						break;
					default:
						break;
				}
				return _showGroupPanel;
			}
			set
			{
				switch (GridViewType)
				{
					case GridViewType.GridView:
					case GridViewType.BandedGridView:
					case GridViewType.AdvBandedGridView:
						((GridView)MainView).OptionsView.ShowGroupPanel = value;
						break;
					default:
						break;
				}
			}
		}

		[Browsable(true)]
		public XPager Pager { get; set; }

		[Browsable(true)]
		public bool ReadOnly
		{
			get
			{
				return MainView.OptionsBehavior.ReadOnly;
			}
			set
			{
				MainView.OptionsBehavior.ReadOnly = value;
			}
		}

		[Browsable(true)]
		public bool Editable
		{
			get
			{
				return MainView.OptionsBehavior.Editable;
			}
			set
			{
				MainView.OptionsBehavior.Editable = value;
			}
		}

		[Browsable(true)]
		public bool ShowFooter
		{
			get
			{
				bool _ret = false;
				switch (GridViewType)
				{
					case GridViewType.GridView:
					case GridViewType.BandedGridView:
					case GridViewType.AdvBandedGridView:
						_ret = ((GridView)MainView).OptionsView.ShowFooter;
						break;
					default:
						break;
				}
				return _ret;
			}
			set
			{
				switch (GridViewType)
				{
					case GridViewType.GridView:
					case GridViewType.BandedGridView:
					case GridViewType.AdvBandedGridView:
						((GridView)MainView).OptionsView.ShowFooter = value;
						break;
					default:
						break;
				}
			}
		}

		[Browsable(false)]
		public string PrintHeader { get; set; }

		[Browsable(false)]
		public string PrintFooter { get; set; }

		[Browsable(false)]
		public string PageHeaderLeft { get; set; }

		[Browsable(false)]
		public string PageHeaderCenter { get; set; }

		[Browsable(false)]
		public string PageHeaderRight { get; set; }

		[Browsable(false)]
		public string PageFooterLeft { get; set; }

		[Browsable(false)]
		public string PageFooterCenter { get; set; }

		[Browsable(false)]
		public string PageFooterRight { get; set; }
	}
}

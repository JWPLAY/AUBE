using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTreeList;
using JW.AUBE.Base.Constants;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Controls.Common;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Resources;
using JW.AUBE.Core.Utils;
using JW.AUBE.Core.Base.Interface;
using JW.AUBE.Core.Interfaces;
using JW.AUBE.Core.Forms.Sales;
using JW.AUBE.Model.Auth;
using System.Collections.Generic;

namespace JW.AUBE
{
	public partial class MainForm : XtraForm, IMainForm
	{
		private string currentFormName = string.Empty;

		private XTree mainMenu = null;

		public MainForm()
		{
			InitializeComponent();
			InitSkin();
			LoadFormLayout();
			Init();

			barManager.ItemClick += delegate (object sender, ItemClickEventArgs e) { ToolbarButtonClick(sender, e); };
			navBarNavigate.LinkClicked += delegate (object sender, NavBarLinkEventArgs e)
			{
				try
				{
					if (sender == null)
					{
						return;
					}
					if (e.Link.Item.Tag != null)
					{
						if (e.Link.Item.Tag is MainMenuDataModel)
						{
							MainMenuDataModel model = e.Link.Item.Tag as MainMenuDataModel;
							OpenForm(new MenuData()
							{
								MENU_ID = model.MENU_ID.ToIntegerNullToZero(),
								MENU_NAME = model.MENU_NAME.ToStringNullToEmpty(),
								CAPTION = model.MENU_NAME.ToStringNullToEmpty(),
								IMAGE = e.Link.Item.SmallImage,
								ASSEMBLY = model.ASSEMBLY.ToStringNullToEmpty(),
								NAMESPACE = model.NAMESPACE.ToStringNullToEmpty(),
								INSTANCE = model.INSTANCE.ToStringNullToEmpty(),
								FORM_TYPE = model.FORM_TYPE.ToStringNullToEmpty(),
								VIEW_YN = model.VIEW_YN.ToStringNullToEmpty(),
								EDIT_YN = model.EDIT_YN.ToStringNullToEmpty()
							});
						}
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};

			mdiManager.PageAdded += delegate (object sender, MdiTabPageEventArgs e)
			{
				if (e.Page.MdiChild != null)
				{
					e.Page.Image = ((IBaseForm)e.Page.MdiChild).TabImage;
					//e.Page.Image = e.Page.MdiChild.BackgroundImage;
				}
			};
			mdiManager.BeginDocking += delegate (object sender, FloatingCancelEventArgs e)
			{
				try
				{
					e.Cancel = false;
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.BeginFloating += delegate (object sender, FloatingCancelEventArgs e)
			{
				try
				{
					e.Cancel = false;
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.EndDocking += delegate (object sender, FloatingEventArgs e)
			{
				try
				{
					if (e.ChildForm != null)
					{
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.EndFloating += delegate (object sender, FloatingEventArgs e)
			{
				try
				{
					if (mdiManager.SelectedPage != null && mdiManager.SelectedPage.MdiChild != null)
					{
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.FloatMDIChildDragging += delegate (object sender, FloatMDIChildDraggingEventArgs e)
			{
				try
				{
					var manager = sender as XtraTabbedMdiManager;
					var info = manager.GetType().GetMethod("PointToClient", BindingFlags.Instance | BindingFlags.NonPublic);
					var point = (Point)info.Invoke(manager, new object[] { e.ScreenPoint });
					var rect = manager.Bounds;
					rect.Height = 20;
					if (manager.Pages.Count == 0 && rect.Contains(point))
					{
						manager.FloatForms.Remove(e.ChildForm);
						e.ChildForm.MdiParent = manager.MdiParent;
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.PageRemoved += delegate (object sender, MdiTabPageEventArgs e)
			{
				try
				{
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.SelectedPageChanged += delegate (object sender, EventArgs e)
			{
				try
				{
					if (mdiManager.SelectedPage != null && mdiManager.SelectedPage.MdiChild != null)
					{
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			mdiManager.MouseDown += delegate (object sender, MouseEventArgs e)
			{
				if (e.Button != MouseButtons.Right)
				{
					return;
				}
				var ea = e as DevExpress.Utils.DXMouseEventArgs;
				var hi = mdiManager.CalcHitInfo(new Point(e.X, e.Y));
				if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader)
				{
					currentFormName = (hi.Page as XtraMdiTabPage).Text;
					popupMenuTabPage.ShowPopup(Cursor.Position);
					ea.Handled = true;
				}
			};

			navBarFavorite.LinkClicked += delegate (object sender, NavBarLinkEventArgs e)
			{
				if (e.Link.Item.Tag != null)
				{
				}
			};
			navBarFavorite.MouseClick += delegate (object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Right)
				{
					var navBar = sender as NavBarControl;
					var hitInfo = navBar.CalcHitInfo(navBar.PointToClient(MousePosition));

					if (hitInfo.InLink && hitInfo.Group.Name.Equals("navBarGroupBookMark"))
					{
					}
				}
			};

			timerMainTime.Tick += delegate (object sender, EventArgs e)
			{
				timerMainTime.Enabled = false;
				barStatusBarDatetime.Caption = DateTime.Now.ToString("F");
				timerMainTime.Enabled = true;

				if (NetworkUtils.IsConnectedToNetwork())
				{
					barStatusBarDatetime.ItemAppearance.Normal.Options.UseBackColor = false;
				}
				else
				{
					barStatusBarDatetime.ItemAppearance.Normal.BackColor = Color.Red;
					barStatusBarDatetime.ItemAppearance.Normal.ForeColor = Color.White;
				}
			};
			timerHomeShow.Tick += delegate (object sender, EventArgs e)
			{
				timerHomeShow.Enabled = false;

				ShowHomePage();
			};

			barPopupUxButtonpandAll.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				if (mainMenu != null)
				{
					mainMenu.ExpandAll();
				}
			};
			barPopupButtonCollapseAll.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				if (mainMenu != null)
				{
					mainMenu.CollapseAll();
				}
			};
			barPopupButtonRefresh.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				LoadMainMenu();
				LoadSystemMenu();
			};

			barButtonTabPageCloseAll.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				try
				{
					mdiManager.Pages.Cast<XtraMdiTabPage>().Where(x => x.Text != "HOME").ToList().ForEach(x =>
						x.MdiChild.Close()
					);
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
			barButtonTabPageCloseAllButThis.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				try
				{
					mdiManager.Pages.Cast<XtraMdiTabPage>().Where(x => x.Text != "HOME" && x.Text != currentFormName).ToList().ForEach(x =>
						x.MdiChild.Close()
					);
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
		}
		
		private void Init()
		{
			Icon = IconResource.icon;
			barManager.Items.OfType<BarButtonItem>().ToList().ForEach(x => x.Tag = x.Name.Replace("barButton", string.Empty));
			dockPanelLog.Padding = new Padding(2);			
		}

		private void InitSkin()
		{
			barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = this.LookAndFeel.UseDefaultLookAndFeel = true;
			barAndDockingController.LookAndFeel.UseWindowsXPTheme = this.LookAndFeel.UseWindowsXPTheme = false;
		}

		private void LoadFormLayout()
		{
			if (!string.IsNullOrEmpty(GlobalVar.Settings.GetValue("MAINFORM_WINDOW_STATE").ToStringNullToEmpty()))
				WindowState = (FormWindowState)GlobalVar.Settings.GetValue("MAINFORM_WINDOW_STATE");
			else
				WindowState = FormWindowState.Maximized;
		}
		
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			try
			{
				base.OnFormClosing(e);

				if (MsgBox.Show(DomainUtils.GetMessageValue("SYSTEM_CLOSE"), "HELP", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					e.Cancel = true;
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			try
			{
				base.OnFormClosed(e);
				SaveLogout();
				Logger.Debug("MainForm Closed...({0})", e.CloseReason);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void SaveLogout()
		{
			try
			{
				//var res = ServerRequest.SingleRequest("Auth", "Logout", null, new DataMap()
				//{
				//	{ "USER_ID", GlobalVar.Settings.GetValue("USER_ID") },
				//	{ "MAC_ADDRESS", CommonUtils.GetMacAddress() }
				//});

				//if (res.ErrorNumber != 0)
				//{
				//	MsgBox.Show(res.ErrorMessage);
				//	return;
				//}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			try
			{
				SetFormTitle();

				barStatusBarCorpName.Caption = GlobalVar.Settings.GetValue("COMPANY_NAME").ToStringNullToEmpty();
				barStatusBarUserInfo.Caption = GlobalVar.Settings.GetValue("USER_NAME").ToStringNullToEmpty();
				barStatusBarCulture.Caption = Application.CurrentCulture.ToString();
				barStatusBarDatetime.Caption = DateTime.Now.ToString("F");
				timerMainTime.Interval = 1000;
				timerMainTime.Enabled = true;
				timerMainTime.Start();

				InitLayoutSetting();
				InitMainMenu();

				timerHomeShow.Interval = 100;
				timerHomeShow.Enabled = true;
				timerHomeShow.Start();

				Logger.Debug("MainForm Loaded..");
			}
			catch (Exception ex)
			{
				MsgBox.Show(ErrorUtils.GetException(ex));
			}
			finally
			{
				if (SplashScreenManager.Default != null)
				{
					SplashScreenManager.CloseForm();
				}
			}
		}

		private void InitLayoutSetting()
		{
			try
			{
				//dpFavorite.Visibility = DockVisibility.AutoHide;
				dpFavorite.Visibility = DockVisibility.Hidden;
				barButtonFav.Visibility = BarItemVisibility.Never;
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void InitMainMenu()
		{
			try
			{
				navBarNavigate.BeginUpdate();
				navBarNavigate.PaintStyleKind = NavBarViewKind.NavigationPane;
				navBarNavigate.Groups.Clear();
				navBarNavigate.Items.Clear();

				var navBarGroupBusiness = new NavBarGroup()
				{
					Name = "navBarGroupBusiness",
					Caption = "Business",
					GroupStyle = NavBarGroupStyle.ControlContainer,
					SmallImage = ImageResource.menu_business_16x16,
					LargeImage = ImageResource.menu_business_32x32
				};
				var navBarGroupSystem = new NavBarGroup()
				{
					Name = "navBarGroupSystem",
					Caption = "System",
					SmallImage = ImageResource.menu_system_16x16,
					LargeImage = ImageResource.menu_system_32x32
				};

				navBarNavigate.OptionsNavPane.ShowExpandButton = false;
				//navBarNavigate.Groups.AddRange(new NavBarGroup[] { navBarGroupBusiness, navBarGroupAnalysis, navBarGroupSystem });
				navBarNavigate.Groups.AddRange(new NavBarGroup[] { navBarGroupBusiness, navBarGroupSystem });
				navBarGroupBusiness.ControlContainer = new NavBarGroupControlContainer();

				mainMenu = new XTree() { Name = "mainMenu", Dock = DockStyle.Fill };
				if (mainMenu != null)
				{
					navBarGroupBusiness.ControlContainer.Controls.Add(mainMenu);

					mainMenu.OptionsBehavior.PopulateServiceColumns = true;
					mainMenu.OptionsBehavior.AllowExpandOnDblClick = true;
					mainMenu.OptionsView.ShowColumns = false;
					mainMenu.OptionsView.ShowIndicator = false;
					mainMenu.OptionsView.ShowHorzLines = false;
					mainMenu.OptionsView.ShowVertLines = false;
					mainMenu.OptionsView.AutoWidth = true;
					mainMenu.OptionsView.EnableAppearanceEvenRow = false;
					mainMenu.OptionsView.EnableAppearanceOddRow = false;

					imageCollection.Clear();
					imageCollection.AddImage(ImageResource.tree_group_collapse_16x16);
					imageCollection.AddImage(ImageResource.tree_group_expand_16x16);
					imageCollection.AddImage(ImageResource.tree_item_normal3_16x16);
					imageCollection.AddImage(ImageResource.tree_item_hot3_16x16);
					imageCollection.AddImage(ImageResource.tree_item_not3_16x16);

					mainMenu.StateImageList = imageCollection;

					mainMenu.GetStateImage += delegate (object sender, GetStateImageEventArgs e)
					{
						if (e.Node.HasChildren)
						{
							if (e.Node.Expanded)
							{
								e.NodeImageIndex = 1;
							}
							else
							{
								e.NodeImageIndex = 0;
							}
						}
						else
						{
							if (e.Node.GetValue("VIEW_YN").ToStringNullToEmpty().Equals("N"))
							{
								e.NodeImageIndex = 4;
							}
							else
							{
								if (e.Node.GetValue("BOOKMARK_YN").ToStringNullToEmpty().Equals("Y"))
								{
									e.NodeImageIndex = 3;
								}
								else
								{
									e.NodeImageIndex = 2;
								}
							}
						}
					};

					mainMenu.GetSelectImage += delegate (object sender, GetSelectImageEventArgs e)
					{
						if (e.Node.HasChildren)
						{
							e.NodeImageIndex = 1;
						}
					};

					mainMenu.MouseDoubleClick += delegate (object sender, MouseEventArgs e)
					{
						try
						{
							if (e.Button == MouseButtons.Left && e.Clicks == 2)
							{
								var tree = sender as XTree;
								var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

								if (info.HitInfoType == HitInfoType.Cell && !info.Node.HasChildren)
								{
									OpenForm(new MenuData()
									{
										MENU_ID = info.Node["MENU_ID"].ToIntegerNullToZero(),
										MENU_NAME = info.Node["MENU_NAME"].ToStringNullToEmpty(),
										CAPTION = info.Node["MENU_NAME"].ToStringNullToEmpty(),
										IMAGE = imageCollection.Images[2],
										ASSEMBLY = info.Node["ASSEMBLY"].ToStringNullToEmpty(),
										NAMESPACE = info.Node["NAMESPACE"].ToStringNullToEmpty(),
										INSTANCE = info.Node["INSTANCE"].ToStringNullToEmpty(),
										FORM_TYPE = info.Node["FORM_TYPE"].ToStringNullToEmpty(),
										VIEW_YN = info.Node["VIEW_YN"].ToStringNullToEmpty(),
										EDIT_YN = info.Node["EDIT_YN"].ToStringNullToEmpty()
									});
								}
							}
						}
						catch (Exception ex)
						{
							MsgBox.Show(ex);
						}
					};

					mainMenu.MouseClick += delegate (object sender, MouseEventArgs e)
					{
						try
						{
							var tree = sender as XTree;
							var info = tree.CalcHitInfo(tree.PointToClient(MousePosition));

							if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && tree.State == TreeListState.Regular)
							{
								if (info.HitInfoType == HitInfoType.Cell && info.Node.HasChildren == false)
								{
									barPopupButtonBookmark.Visibility = BarItemVisibility.Always;
								}
								else
								{
									barPopupButtonBookmark.Visibility = BarItemVisibility.Never;
								}
								popupMenuOfMainMenu.ShowPopup(MousePosition);
							}
						}
						catch (Exception ex)
						{
							MsgBox.Show(ex);
						}
					};

					mainMenu.AddColumn("MENU_NAME");
					mainMenu.AddColumn("MENU_ID", false);
					mainMenu.AddColumn("PARENT_ID", false);
					mainMenu.AddColumn("HIER_ID", false);
					mainMenu.AddColumn("ASSEMBLY", false);
					mainMenu.AddColumn("NAMESPACE", false);
					mainMenu.AddColumn("INSTANCE", false);
					mainMenu.AddColumn("CHILD_COUNT", false);
					mainMenu.AddColumn("BOOKMARK_YN", false);
					mainMenu.AddColumn("FORM_TYPE", false);
					mainMenu.AddColumn("VIEW_YN", false);
					mainMenu.AddColumn("EDIT_YN", false);

					mainMenu.ParentFieldName = "PARENT_ID";
					mainMenu.KeyFieldName = "MENU_ID";
					mainMenu.RootValue = "MENU_GROUP_BIZ";

					LoadMainMenu();
					LoadSystemMenu();
				}

				navBarNavigate.EndUpdate();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void LoadMainMenu()
		{
			try
			{
				if (mainMenu != null)
				{
					var list = ServerRequest.SingleRequest("Auth", "GetMainMenus", "MainMenus", new DataMap()
					{
						{ "USER_ID", GlobalVar.Settings.GetValue("USER_ID") },
						{ "MENU_GROUP", "BIZ" }
					});

					if (list != null)
					{
						mainMenu.DataSource = list;
						mainMenu.ExpandAll();
						mainMenu.BestFitColumns();
						mainMenu.Sort(new string[] { "HIER_ID" }, new SortOrder[] { SortOrder.Ascending });
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void LoadSystemMenu()
		{
			try
			{
				if (navBarNavigate != null && navBarNavigate.Groups.Where(x => x.Name == "navBarGroupSystem").Any())
				{
					var navGroup = navBarNavigate.Groups.Where(x => x.Name == "navBarGroupSystem").FirstOrDefault();
					navGroup.ItemLinks.Clear();

					var list = ServerRequest.SingleRequest("Auth", "GetMainMenus", "MainMenus", new DataMap()
					{
						{ "USER_ID", GlobalVar.Settings.GetValue("USER_ID") },
						{ "MENU_GROUP", "SYS" }
					});

					if (list != null)
					{
						foreach (MainMenuDataModel model in (List<MainMenuDataModel>)list)
						{
							navGroup.ItemLinks.Add(navBarNavigate.Items.Add(new NavBarItem()
							{
								Caption = model.MENU_NAME.ToStringNullToEmpty(),
								Tag = model,
								SmallImage = ImageResource.menu_system_16x16,
								SmallImageSize = new Size(16, 16)
							}));
						}
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public void SetFormTitle()
		{
			try
			{
				var attributes = GetType().Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				var version = Assembly.GetExecutingAssembly().GetName().Version;

				this.Text = string.Format("{0} ({1})", ((AssemblyTitleAttribute)attributes[0]).Title, version);
				barStatusBarCorpName.Caption = GlobalVar.Settings.GetValue("COMPANY_NAME").ToStringNullToEmpty();
				notifyIcon1.Text = this.Text;
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void ShowHomePage()
		{
			try
			{
				CreateChildForm(new MenuData()
				{
					MENU_ID = 0,
					MENU_NAME = "HomeForm",
					CAPTION = "HOME",
					IMAGE = null,
					ASSEMBLY = "JW.AUBE.exe",
					NAMESPACE = "JW.AUBE",
					INSTANCE = "HomeForm",
					FORM_TYPE = "",
					VIEW_YN = "Y",
					EDIT_YN = "Y"
				});
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
		
		private void ToggleDockPanel(DockPanel dock)
		{
			if (dock.Visibility == DockVisibility.Visible)
			{
				dock.Visibility = DockVisibility.Hidden;
			}
			else
			{
				dock.Visibility = DockVisibility.Visible;


				if (dock.Name == "dockPanelLog")
				{
					if (dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().Any() == false)
					{
						dockPanelLog.Controls.Add(new ListBoxControl()
						{
							Name = "lbLogList",
							Dock = DockStyle.Fill,
							SelectionMode = SelectionMode.MultiExtended
						});
					}

					if (dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().Any() == true)
					{
						using (var stRead = new StreamReader(CommonConsts.APP_PATH + @"\Log\log.log", Encoding.Default))
						{
							while (!stRead.EndOfStream)
							{
#if (DEBUG)
								dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().ToList()[0].Items.Add(stRead.ReadLine());
#else
                                string text = stRead.ReadLine();
                                if (text.Contains("DEBUG") == false)
                                {
                                    ((ListBoxControl)dockPanelLog.ControlContainer.Controls.OfType<ListBoxControl>().ToList()[0]).Items.Add(stRead.ReadLine());
                                }
#endif
							}
						}
					}
				}
			}
		}

		#region 툴바버튼 클릭 이벤트 (ToolbarButtonClick)
		public void ToolbarButtonClick(object sender, ItemClickEventArgs e)
		{
			if (e == null || e.Item == null || e.Item.Tag == null || e.Item.Tag.IsNullOrEmpty()) return;
			if (e.Item.Name == "barButtonSkin") return;

			try
			{
				switch (e.Item.Tag.ToString().ToUpper())
				{
					case "CLOSE":
						CloseForm();
						break;
					case "NAV":
						ToggleDockPanel(dpNavigation);
						break;
					case "FAV":
						ToggleDockPanel(dpFavorite);
						break;
					case "LOG":
						ToggleDockPanel(dockPanelLog);
						break;
					case "DOMAIN":
						SetMessage("용어사전을 다운로드하는 중입니다... 잠시만 기다리세요!!!");
						DomainUtils.SetData();
						SetMessage("");
						break;
					case "HOME":
						ShowHomePage();
						break;
					case "CHANGEPASSWORD":
						ShowChangePwd();
						break;
					case "SETTING":
						OpenSaleTran();
						break;
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
		#endregion

		/// <summary>
		/// 상태바의 메시지를 변경하는 메서드
		/// </summary>
		/// <param name="message"></param>
		public void SetMessage(string message)
		{
			try
			{
				barStatusBarMessage.Caption = message.Trim();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public bool ExistsChildForm(string childName)
		{
			return mdiManager.Pages.Where(x => x.MdiChild.Name.Equals(childName)).Any();
		}

		public void CreateChildForm(MenuData data)
		{
			try
			{
				var formName = string.Format("{0}_{1}", data.MENU_ID.ToString("000000"), data.INSTANCE);
				var bOpened = ExistsChildForm(formName);
				if (bOpened)
				{
					mdiManager.SelectedPage = mdiManager.Pages.Where(x => x.MdiChild.Name.Equals(formName)).ToList()[0];
					return;
				}

				if (string.IsNullOrEmpty(data.NAMESPACE) || string.IsNullOrEmpty(data.INSTANCE))
				{
					return;
				}
				
				var assembly = FormUtils.GetAssembly(data.ASSEMBLY);
				if (assembly == null)
				{
					throw new Exception("어셈블리를 찾을 수 없습니다.");
				}

				var form = (BaseForm)assembly.CreateInstance(string.Format("{0}.{1}", data.NAMESPACE, data.INSTANCE));
				if (form == null)
				{
					throw new Exception("해당 화면을 생성할 수 없습니다.");
				}

				form.Name = formName;
				form.Text = data.CAPTION;
				form.MdiParent = this;
				form.Padding = new Padding(2);
				form.MenuId = data.MENU_ID;
				form.TabImage = data.IMAGE;
				if (!string.IsNullOrEmpty(data.FORM_TYPE))
				{
					if (data.FORM_TYPE == "1")
						((IEditForm)form).FormType = Core.Enumerations.FormTypeEnum.Edit;
					else if (data.FORM_TYPE == "2")
						((IEditForm)form).FormType = Core.Enumerations.FormTypeEnum.ListAndEdit;
					else
						((IEditForm)form).FormType = Core.Enumerations.FormTypeEnum.List;
					((IEditForm)form).IsDataList = (data.VIEW_YN == "Y") ? true : false;
					((IEditForm)form).IsDataEdit = (data.EDIT_YN == "Y") ? true : false;
				}

				form.Show();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void CloseForm()
		{
			try
			{
				if (mdiManager.Pages.Count > 0)
				{
					mdiManager.SelectedPage.MdiChild.Close();
				}
				else
				{
					Close();
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public void OpenForm(MenuData formData)
		{
			try
			{
				CreateChildForm(formData);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
		private void ShowChangePwd()
		{
			using (var form = new PasswordForm())
			{
				form.Text = "비밀번호변경";
				form.Name = "PasswordForm";
				form.FormBorderStyle = FormBorderStyle.FixedDialog;
				form.StartPosition = FormStartPosition.CenterScreen;

				if (form.ShowDialog() == DialogResult.OK)
				{
					Close();
				}
			}
		}

		public void RefreshMainMenu()
		{
		}

		public void RefreshBookmark()
		{
		}

		public void OpenSaleTran(object param = null)
		{
			if (FormUtils.IsExistsForm("SaleTranForm") == false)
			{
				SaleTranForm form = new SaleTranForm()
				{
					Name = "SaleTranForm",
					Text = "판매등록",
					MdiParent = null,
					Padding = new Padding(2),
					MenuId = 10,
					TabImage = null,
					ParamsData = param,
					StartPosition = FormStartPosition.CenterScreen
				};
				((IEditForm)form).FormType = Core.Enumerations.FormTypeEnum.Edit;
				((IEditForm)form).IsDataList = true;
				((IEditForm)form).IsDataEdit = true;
				form.Show();
			} 
			else
			{
				FormUtils.GetForm("SaleTranForm").Focus();
			}
		}
	}
}

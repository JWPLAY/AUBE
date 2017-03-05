using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Variables;
using JW.AUBE.Core.Base.Interface;
using JW.AUBE.Core.Controls.Common;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Base.Forms
{
	public partial class EditForm : BaseForm, IEditForm
	{
		private ToolbarButtons _ToolbarButtons;

		public delegate void SaveCallback(object arg, object data);
		public delegate void DeleteCallback(object arg, object data);

		public EditForm()
		{
			InitializeComponent();
			Initialize();

			barManager.ItemClick += delegate (object sender, ItemClickEventArgs e)
			{
				switch (e.Item.Name.Replace("barButton","").ToUpper())
				{
					case "REFRESH":
						actRefresh();
						break;
					case "NEW":
						actNew();
						break;
					case "SAVE":
						actSave();
						break;
					case "SAVEANDCLOSE":
						actSaveAndClose();
						break;
					case "SAVEANDNEW":
						actSaveAndNew();
						break;
					case "DELETE":
						actDelete();
						break;
					case "CANCEL":
						actCancel();
						break;
					case "EXPORT":
						actExport();
						break;
					case "PRINT":
						actPrint();
						break;
					case "HELP":
						actHelp();
						break;
					case "CLOSE":
						Close();
						break;
					default:
						break;
				}
			};
		}

		private void Initialize()
		{
			if (!this.DesignMode)
			{
				if (GlobalVar.Settings.GetValue("FORM_SKIN").ToStringNullToEmpty() != "")
				{
					this.LookAndFeel.UseDefaultLookAndFeel = false;
					this.LookAndFeel.SetSkinStyle(GlobalVar.Settings.GetValue("FORM_SKIN").ToStringNullToEmpty());
				}
				else
				{
					this.LookAndFeel.UseDefaultLookAndFeel = true;
				}
				if (GlobalVar.Settings.GetValue("MAIN_SKIN").ToStringNullToEmpty() != "")
				{
					barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = false;
					barAndDockingController.LookAndFeel.SetSkinStyle(GlobalVar.Settings.GetValue("MAIN_SKIN").ToStringNullToEmpty());
				}
				else
				{
					barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = true;
				}
				barTools.Appearance.BackColor = SkinUtils.BackColor();
				barTools.OptionsBar.AllowQuickCustomization = false;

				ToolbarButtons = new ToolbarButtons();
				LoadingElapseTime = new ElapseTime();
				IsLoaded = false;

				if (Name.EndsWith("EditForm"))
				{
					EditMode = EditModeEnum.New;
				}
				else
				{
					EditMode = EditModeEnum.List;
				}
			}
			else
			{
				this.LookAndFeel.UseDefaultLookAndFeel = 
					barAndDockingController.LookAndFeel.UseDefaultLookAndFeel = true;
			}
		}

		[Browsable(false)]
		[Category("Customize")]
		public ElapseTime LoadingElapseTime { get; set; }

		[Browsable(false)]
		[Category("Customize")]
		public ToolbarButtons ToolbarButtons
		{
			get
			{
				return _ToolbarButtons;
			}
			set
			{
				_ToolbarButtons = value;
				ChangeToolbarButtons();
			}
		}

		[Browsable(false)]
		[Category("Customize")]
		public EditModeEnum EditMode { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public FormTypeEnum FormType { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public bool IsDataEdit { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public bool IsDataList { get; set; }

		[Browsable(true)]
		[Category("Customize")]
		public bool VisibleToolbar
		{
			get
			{
				return barTools.Visible;
			}
			set
			{
				barTools.Visible = value;
			}
		}

		[Browsable(true)]
		[Category("Customize")]
		public bool VisibleStatusbar
		{
			get
			{
				return barStatus.Visible;
			}
			set
			{
				barStatus.Visible = value;
			}
		}

		[Browsable(true)]
		[Category("Customize")]
		public bool IsLoadingRefresh { get; set; }

		[Browsable(false)]
		[Category("Customize")]
		public bool IsLoaded { get; internal set; }
		private void SetLayout()
		{
			try
			{
				try
				{
					foreach (LayoutControlGroup group in lc.Items.OfType<LayoutControlGroup>().Where(x => x.Name.Equals("lcGroupSearch")))
					{
						group.Text = "검색조건";
						group.ExpandButtonVisible = false;
					}
				}
				catch
				{
					throw;
				}

				var items = new string[] { "InsTime", "InsUser", "InsUserName", "UpdTime", "UpdUser", "UpdUserName" };
				lc.Items.OfType<LayoutControlItem>()
					.Where(x => items.Contains(x.Name.Replace("lcItem", string.Empty)))
					.ToList()
					.ForEach(x =>
				{
					try
					{
						(x.Control as TextEdit).SetEnable(false);
						x.Control.Name = string.Format("txt{0}", x.Name.Replace("lcItem", string.Empty));
					}
					catch
					{
						throw;
					}
				});

				lc.Items.OfType<LayoutControlItem>()
					.Where(x => x.Control != null && x.Control.GetType() == typeof(SimpleButton))
					.ToList()
					.ForEach(x =>
				{
					try
					{
						(x.Control as SimpleButton).TabIndex = 0;
						(x.Control as SimpleButton).TabStop = false;
					}
					catch
					{
						throw;
					}
				});

				try
				{
					if (Controls.Count > 0)
					{
						foreach (Control control in Controls)
						{
							if (control.GetType() == typeof(LayoutControl))
							{
								((LayoutControl)control).Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2);
								break;
							}
						}
					}
				}
				catch
				{
					throw;
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		public void SetToolbarButtons(ToolbarButtons toolbarButtons)
		{
			_ToolbarButtons = toolbarButtons;
			ChangeToolbarButtons();
		}

		private void ChangeToolbarButtons()
		{
			barTools.ItemLinks.OfType<BarButtonItemLink>().Where(x => x.Item.Name.StartsWith("barButton")).ToList().ForEach(x =>
			{
				if (_ToolbarButtons.ToDictionary().Where(button => 
						button.Key == x.Item.Name.Replace("barButton", string.Empty)).FirstOrDefault().Value.ToBooleanNullToFalse() == true ||
						x.Item.Name.Replace("barButton", string.Empty) == "Close" ||
						x.Item.Name.Replace("barButton", string.Empty) == "Help")
				{
					x.Item.Visibility = BarItemVisibility.Always;
				}
				else
				{
					x.Item.Visibility = BarItemVisibility.Never;
				}
			});
		}


		private void SetButtonName()
		{
			try
			{
				barButtonRefresh.Caption = "조회";
				barButtonNew.Caption = "신규";
				barButtonSave.Caption = "저장";
				barButtonSaveAndClose.Caption = "저장 후 닫기";
				barButtonSaveAndNew.Caption = "저장 후 신규";
				barButtonDelete.Caption = "삭제";
				barButtonCancel.Caption = "취소";
				barButtonExport.Caption = "엑셀";
				barButtonPrint.Caption = "인쇄";
				barButtonHelp.Caption = "도움말";
				barButtonClose.Caption = "종료";
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		/// <summary>
		/// 버튼초기화
		/// </summary>
		protected virtual void InitButtons()
		{
			barTools.ItemLinks.OfType<BarButtonItemLink>().Where(x => x.Item.Name.Contains("barButton")).ToList().ForEach(x =>
				{
					if (GlobalVar.Settings.GetValue("VisibleToolbarName").ToStringNullToEmpty() == "YES")
					{
						x.Item.PaintStyle = BarItemPaintStyle.CaptionGlyph;
					}
					else
					{
						x.Item.PaintStyle = BarItemPaintStyle.Standard;
					}
				});
		}

		/// <summary>
		/// 컨트롤 초기화
		/// </summary>
		protected virtual void InitControls() { }

		/// <summary>
		/// 폼이 로드되었을 때의 이벤트 (상속폼에서 이벤트 델리게이트 하지 않고 사용하는 경우)
		/// </summary>
		protected override void LoadForm()
		{
			try
			{
				if (Name.EndsWith("ListForm"))
				{
					EditMode = EditModeEnum.List;
				}
				else
				{
					if (Name.EndsWith("ViewForm"))
					{
						EditMode = EditModeEnum.View;
					}
				}
				SetButtonName();

				SetLayout();

				barTitle.Caption = this.Text;
				barTitle.ItemAppearance.Normal.BackColor = Color.Black;
				barTitle.ItemAppearance.Normal.BackColor2 = Color.Transparent;
				barStaticMessage.Caption = string.Empty;
				barStaticTotalRecords.Caption = string.Empty;
				barStaticEditMode.Caption = EditMode.ToString().ToUpper();

				InitButtons();
				InitControls();
				barStaticViewName.Caption = Name;
				SetTextBoxKeydownEvent();

				if (IsLoadingRefresh)
				{
					if (ParamsData != null)
					{
						DataLoad(ParamsData);
					}
					else
					{
						DataInit();
					}
				}

				IsLoaded = true;
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		/// <summary>
		/// 편집화면 로딩 메소드
		/// </summary>
		/// <param name="data"></param>
		protected virtual void ShowEdit(object data = null) { }

		protected override void ChildCallback(object data = null)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => DataLoad(data)));
			}
		}

		/// <summary>
		/// 툴바버튼 New 클릭 이벤트 상속 메소드
		/// </summary>
		protected virtual void ActNew()
		{
			if (EditMode == EditModeEnum.List || EditMode == EditModeEnum.View)
			{
				ShowEdit(null);
			}
			else
			{
				if (EditMode != EditModeEnum.New)
				{
					if (MsgBox.Show("신규로 등록하겠습니까?", "New", MessageBoxButtons.OKCancel) != DialogResult.OK)
					{
						return;
					}
				}
				DataInit();
			}
		}

		/// <summary>
		/// 툴바버튼 Save 클릭 이벤트 상속 메소드
		/// DataSave 메소드를 호출하고 DataCallback 메소드를 콜백메소드로 설정한다.
		/// </summary>
		protected virtual void ActSave()
		{
			SplashUtils.ShowWait("저장하는 중입니다... 잠시만...");
			try
			{
				DataSave(MethodBase.GetCurrentMethod().Name, DataCallback);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 SaveAndNew 클릭 이벤트 상속 메소드
		/// DataSave 메소드를 호출하고 DataCallback 메소드를 콜백메소드로 설정한다.
		/// </summary>
		protected virtual void ActSaveAndNew()
		{
			SplashUtils.ShowWait("저장하는 중입니다... 잠시만...");
			try
			{
				DataSave(MethodBase.GetCurrentMethod().Name, DataCallback);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 SaveAndClose 클릭 이벤트 상속 메소드
		/// DataSave 메소드를 호출하고 DataCallback 메소드를 콜백메소드로 설정한다.
		/// </summary>
		protected virtual void ActSaveAndClose()
		{
			SplashUtils.ShowWait("저장하는 중입니다... 잠시만...");
			try
			{
				DataSave(MethodBase.GetCurrentMethod().Name, DataCallback);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 Cancel 클릭 이벤트 상속 메소드
		/// 편집모드가 Modify이면 DataLoad 호출, New이면 DataInit 호출함
		/// </summary>
		protected virtual void ActCancel()
		{
			if (EditMode == EditModeEnum.Modify)
			{
				DataLoad(ParamsData);
			}
			else
			{
				if (EditMode == EditModeEnum.New)
				{
					DataInit();
				}
			}
		}

		/// <summary>
		/// 툴바버튼 Delete 클릭 이벤트 상속 메소드
		/// 삭제확인 메시지박스를 보여주고 OK인 경우
		/// DataDelete를 실행하고 DataCallback으로 콜백메소드를 설정한다.
		/// </summary>
		protected virtual void ActDelete()
		{
			if (EditMode == EditModeEnum.Modify)
			{
				if (MsgBox.Show("삭제하겠습니까?", "삭제", MessageBoxButtons.OKCancel) != DialogResult.OK)
				{
					return;
				}
				SplashUtils.ShowWait("삭제하는 중입니다... 잠시만...");
				try
				{
					DataDelete(MethodBase.GetCurrentMethod().Name, DataCallback);
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
				finally
				{
					SplashUtils.CloseWait();
				}
			}
			else
			{
				DataInit();
			}
		}

		/// <summary>
		/// 툴바버튼 Refresh 클릭 이벤트 상속 메소드
		/// DataLoad를 호출한다.
		/// </summary>
		protected virtual void ActRefresh()
		{
			SplashUtils.ShowWait();
			try
			{
				DataLoad(ParamsData);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}

		/// <summary>
		/// 툴바버튼 Export 클릭 이벤트 상속 메소드
		/// </summary>
		protected virtual void ActExport()
		{
			if (EditMode == EditModeEnum.List || EditMode == EditModeEnum.View)
			{
				foreach (var c in Controls)
				{
					if (c.GetType() == typeof(LayoutControl) || c.GetType() == typeof(LayoutControl))
					{
						foreach (var g in ((LayoutControl)c).Controls)
						{
							if (g.GetType() == typeof(XGrid))
							{
								return;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// 툴바버튼 Print 클릭 이벤트 상속 메소드
		/// </summary>
		protected virtual void ActPrint() { }

		protected virtual void ActHelp()
		{
			try
			{
				FormUtils.ShowHelp(null, FormId);
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void actNew() { ActNew(); }
		private void actSave() { ActSave(); }
		private void actSaveAndNew() { ActSaveAndNew(); }
		private void actSaveAndClose() { ActSaveAndClose(); }
		private void actCancel() { ActCancel(); }
		private void actDelete() { ActDelete(); }
		private void actRefresh() { ActRefresh(); }
		private void actExport() { ActExport(); }
		private void actPrint() { ActPrint(); }
		private void actHelp() { ActHelp(); }

		/// <summary>
		/// 데이터 초기화 메소드
		/// </summary>
		protected virtual void DataInit() { }

		/// <summary>
		/// 데이터 로드 메소드
		/// </summary>
		/// <param name="param"></param>
		protected virtual void DataLoad(object param = null) { }

		/// <summary>
		/// 데이터 저장 메소드
		/// 파라미터로 처리된 콜백 메소드를 호출한다.
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="callback"></param>
		protected virtual void DataSave(object arg, SaveCallback callback)
		{
			callback?.Invoke(arg, null);
		}

		/// <summary>
		/// 데이터 삭제 메소드
		/// 파라미터로 처리된 콜백 메소드를 호출한다.
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="callback"></param>
		protected virtual void DataDelete(object arg, DeleteCallback callback)
		{
			callback?.Invoke(arg, null);
		}

		/// <summary>
		/// 데이터 처리 이후의 콜백 메소드
		/// 저장, 삭제에 대한 사전 정의된 콜백 메소드
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="data"></param>
		protected virtual void DataCallback(object arg, object data)
		{
			SetModifiedCount();

			if (arg.ToString().Equals("ActSave"))
			{
				DataLoad(data);
			}
			else if (arg.ToString().Equals("ActSaveAndClose"))
			{
				Close();
			}
			else
			{
				//ActSaveAndNew or ActDelete
				if (this.FormType == FormTypeEnum.ListAndEdit)
					DataLoad(null);
				else
					DataInit();
			}
		}
		
		/// <summary>
		/// 데이터를 검사하는 메소드
		/// </summary>
		/// <returns></returns>
		protected virtual bool DataValidate()
		{
			string msg = string.Empty;
			try
			{
				foreach(LayoutControlItem item in lc.Items.OfType<LayoutControlItem>().Where(x => x.Tag != null && x.Tag.ToBooleanNullToFalse()).Reverse().ToList())
				{
					if (item.Control != null)
					{
						if (item.Control.GetType() == typeof(TextEdit))
						{
							if ((item.Control as TextEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(MemoEdit))
						{
							if ((item.Control as MemoEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(XLookup))
						{
							if ((item.Control as XLookup).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(SpinEdit))
						{
							if ((item.Control as SpinEdit).EditValue.ToDecimalNullToZero() == 0)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(XSearch))
						{
							if ((item.Control as XSearch).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(DateEdit))
						{
							if ((item.Control as DateEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
						else if (item.Control.GetType() == typeof(ButtonEdit))
						{
							if ((item.Control as ButtonEdit).EditValue.ToStringNullToEmpty().Trim() == string.Empty)
							{
								item.Control.Focus();
								msg = string.Format("{0}을(를) 입력해야 합니다.", item.Text.Replace(":", string.Empty));
								break;
							}
						}
					}
				};

				if (!string.IsNullOrEmpty(msg))
				{
					ShowMsgBox(msg);
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
				return false;
			}
		}

		public EditForm Init(BaseForm parentForm, object data, object optionalData = null)
		{
			Name = parentForm.Name.Replace("ListForm", "EditForm");
			Text = string.Format("{0} [편집]", parentForm.Text);
			StartPosition = FormStartPosition.CenterScreen;
			FormId = parentForm.FormId;
			MenuId = parentForm.MenuId;
			ParamsData = data;
			OptionData = optionalData;
			ParentFormName = parentForm.Name;
			EditMode = (data == null) ? EditModeEnum.New : EditModeEnum.Modify;
			IsLoadingRefresh = true;
			return this;
		}

		/// <summary>
		/// 메시지박스 보이기
		/// </summary>
		/// <param name="msg"></param>
		public void ShowMsgBox(string msg)
		{
			MsgBox.Show(msg);
		}

		/// <summary>
		/// 에러 메시지박스 보이기(오류객체)
		/// </summary>
		/// <param name="ex"></param>
		public void ShowErrBox(Exception ex)
		{
			MsgBox.Show(ex);
		}

		/// <summary>
		/// 에러 메시지박스 보이기(문자열)
		/// </summary>
		/// <param name="msg"></param>
		public void ShowErrBox(string msg)
		{
			MsgBox.Show(new Exception(msg));
		}



		protected virtual void SetFieldName(LayoutControlItem item)
		{
			var itemName = item.Name.Replace("lcItem", string.Empty);
			itemName = StringUtils.ToUpperUnderscoreByPattern(itemName).Replace("_", " ");
			SetFieldName(item, itemName, HorzAlignment.Far, VertAlignment.Center);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName)
		{
			SetFieldName(item, fieldName, HorzAlignment.Far, VertAlignment.Center);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName, VertAlignment vertAlign)
		{
			SetFieldName(item, fieldName, HorzAlignment.Far, vertAlign);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName, HorzAlignment horzAlign)
		{
			SetFieldName(item, fieldName, horzAlign, VertAlignment.Center);
		}
		protected virtual void SetFieldName(LayoutControlItem item, string fieldName, HorzAlignment horzAlign, VertAlignment vertAlign)
		{
			item.Text = DomainUtils.GetFieldName(fieldName) + ":";
		}
		protected virtual void SetFieldNames()
		{
			try
			{
				SuspendLayout();
				if (Controls.Count > 0)
				{
					foreach (Control control in Controls)
					{
						if (control.GetType() == typeof(LayoutControl) || control.GetType() == typeof(LayoutControl))
						{
							var lc = (LayoutControl)control;
							lc.BeginUpdate();
							SetFieldNames(lc);
							lc.EndUpdate();
						}
					}
				}
				ResumeLayout(true);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		private void SetFieldNames(LayoutControl control)
		{
			try
			{
				if (control.Items.Count > 0)
				{
					foreach (var item in control.Items)
					{
						if (item.GetType() == typeof(LayoutControlItem) &&
							((LayoutControlItem)item).Name.ToLower().Contains("lcitem"))
						{
							((LayoutControlItem)item).AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
							((LayoutControlItem)item).AppearanceItemCaption.TextOptions.VAlignment = VertAlignment.Center;

							var itemName = ((LayoutControlItem)item).Name.Replace("lcItem", string.Empty);
							itemName = StringUtils.ToUpperUnderscoreByPattern(itemName);

							var itemText = DomainUtils.GetFieldName(itemName);
							if (string.IsNullOrEmpty(itemText))
							{
								itemText = itemName.Replace("_", " ");
							}
							if (((LayoutControlItem)item).Tag != null && ((LayoutControlItem)item).Tag.GetType() == typeof(bool) && (bool)((LayoutControlItem)item).Tag == true)
							{
								((LayoutControlItem)item).Text = string.Format("*{0}:", itemText);
								((LayoutControlItem)item).AppearanceItemCaption.ForeColor = (SkinUtils.IsDarkSkin()) ? Color.Yellow : Color.Red;
								((LayoutControlItem)item).AppearanceItemCaption.Options.UseForeColor = true;
							}
							else
							{
								((LayoutControlItem)item).Text = itemText + ":";
								((LayoutControlItem)item).AppearanceItemCaption.Options.UseForeColor = false;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		public void SetRecords(int rowcount)
		{
			barStaticTotalRecords.Caption = string.Format("조회건수: {0:N0}건", rowcount);
		}

		private void SetTextBoxKeydownEvent()
		{
			try
			{
				foreach (LayoutControl lc in Controls.OfType<LayoutControl>().ToList())
				{
					foreach (LayoutControlGroup lcg in lc.Items.OfType<LayoutControlGroup>().Where(x => x.Name.ToLower().Equals("lcgroupsearch")))
					{
						foreach (LayoutControlItem lci in lcg.Items.OfType<LayoutControlItem>().Where(x => (x.Control != null && x.Control.GetType() == typeof(TextEdit))))
						{
							((TextEdit)lci.Control).KeyDown += delegate (object sender, KeyEventArgs e)
							{
								if (e.KeyCode == Keys.Enter)
								{
									DataLoad(null);
								}
							};
						}
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}

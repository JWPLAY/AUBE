using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Helper;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Common
{
	[ToolboxItem(true)]
	public partial class XSearch : XtraUserControl
	{
		public delegate void EditValueChangedEventHandler(object value);
		public event EditValueChangedEventHandler EditValueChanged = null;

		public delegate void ButtonClickEventHandler(object sender, ButtonPressedEventArgs e);
		public event ButtonClickEventHandler ButtonClicked = null;
		public event ButtonClickEventHandler DeleteButtonClicked = null;
		public event ButtonClickEventHandler OtherButtonClicked = null;

		public XSearch()
		{
			InitializeComponent();
			Initialize();

			txtCodeName.Properties.ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == ButtonPredefines.Ellipsis)
				{
					if (ButtonClicked != null)
					{
						ButtonClicked(sender, e);
					}
					else
					{
						Search(true);
					}
				}
				else
				{
					if (e.Button.Kind == ButtonPredefines.Delete)
					{
						txtCodeName.EditValue = null;
						txtCodeId.EditValue = null;

						if (EditValueChanged != null)
							EditValueChanged.Invoke(null);

						if (DeleteButtonClicked != null)
							DeleteButtonClicked.Invoke(sender, e);
					}
					else
					{
						if (OtherButtonClicked != null)
							OtherButtonClicked.Invoke(sender, e);
					}
				}
			};
			txtCodeName.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					if (txtCodeName.Properties.ReadOnly == false && txtCodeName.Enabled == true)
					{
						Search(false);
					}
				}
			};
			txtCodeName.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (txtCodeName.EditValue.IsNullOrEmpty())
				{
					txtCodeId.EditValue = null;

					if (EditValueChanged != null)
						EditValueChanged.Invoke(null);
				}
			};
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			txtCodeName.Focus();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (txtCodeId == null)
			{
				Height = 20;
				MinimumSize = new Size(0, 20);
				MaximumSize = new Size(0, 20);
			}
			else
			{
				Height = txtCodeId.Height;
				MaximumSize = new Size(0, txtCodeId.Height);
				MinimumSize = new Size(0, txtCodeId.Height);
			}
			Refresh();
		}

		private void Initialize()
		{
			CodeGroup = "CODES";
			CodeField = "CODE";
			NameField = "NAME";
			DisplayFields = new string[] { CodeField, NameField };
			Text = "코드검색";
			txtCodeId.SetEnable(false);
			txtCodeId.Width = 100;
			Width = 500;
		}
		public void Init(string codeGroup, string codeField, string nameField, string[] displayFields, DataMap parameters = null)
		{
			CodeGroup = codeGroup;

			if (codeField.IsNullOrEmpty() == false)
				CodeField = codeField;

			if (nameField.IsNullOrEmpty() == false)
				NameField = nameField;

			if (displayFields != null)
				DisplayFields = displayFields;
			else
				DisplayFields = new string[] { CodeField, NameField };

			if (parameters == null)
				parameters = new DataMap();

			Parameters = parameters;
		}

		[Browsable(true)]
		public new string Text { get; set; }

		[Browsable(false)]
		public DataMap Parameters { get; set; }

		[Browsable(true)]
		public string CodeField { get; set; }

		[Browsable(true)]
		public string NameField { get; set; }

		[Browsable(true)]
		public string CodeGroup { get; set; }

		[Browsable(false)]
		public object EditValue
		{
			get
			{
				return txtCodeId.EditValue;
			}
			set
			{
				txtCodeId.EditValue = value;
			}
		}

		[Browsable(false)]
		public object EditText
		{
			get
			{
				return txtCodeName.EditValue;
			}
			set
			{
				txtCodeName.EditValue = value;
			}
		}

		[Browsable(false)]
		public string[] DisplayFields { get; set; }

		[Browsable(true)]
		public int CodeWidth
		{
			get
			{
				return txtCodeId.Width;
			}
			set
			{
				txtCodeId.Width = value;
			}
		}

		public void SetEnable(bool bEnable = false)
		{
			txtCodeName.SetEnable(bEnable);
		}

		public void Clear()
		{
			txtCodeName.EditValue = null;
			txtCodeId.EditValue = null;
		}

		private void Search(bool buttonClick = false)
		{
			try
			{
				if (txtCodeName.EditValue.IsNullOrEmpty())
				{
					SearchForm();
					return;
				}

				if (Parameters == null)
					Parameters = new DataMap();

				if (txtCodeName.EditValue != null)
				{
					Parameters.SetValue("FIND_TEXT", txtCodeName.EditValue);
				}

				var data = CodeHelper.Search(CodeGroup, Parameters);
				if (data != null)
				{
					if (data.Rows.Count == 0 && buttonClick == false)
					{
						MsgBox.Show("해당 코드를 검색할 수 없습니다.\r\n확인 후 다시 시도하세요!!!");
						return;
					}

					if (data.Rows.Count == 1 && txtCodeName.EditValue.ToStringNullToEmpty().IsNullOrEmpty() == false && buttonClick == false)
					{
						EditValue = data.Rows[0][CodeField];
						EditText = data.Rows[0][NameField];

						if (EditValueChanged != null)
							EditValueChanged.Invoke(data.ToDataMap());

						return;
					}
					else
					{
						SearchForm(data);
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void SearchForm(DataTable data = null)
		{
			if (this.Parameters == null)
				this.Parameters = new DataMap();

			this.Parameters.SetValue("FIND_TEXT", EditText);

			var res = CodeHelper.ShowForm(this.CodeGroup, this.Parameters, data);
			if (res != null)
			{
				EditValue = res.GetValue(CodeField);
				EditText = res.GetValue(NameField);

				if (EditValueChanged != null)
					EditValueChanged.Invoke(res);
			}
		}

		public Font GetFontCodeText()
		{
			return txtCodeId.Font;
		}
		public void SetFontCodeText(Font value)
		{
			txtCodeId.Font = value;
		}
		public Font GetFontNameText()
		{
			return txtCodeName.Font;
		}
		public void SetFontNameText(Font value)
		{
			txtCodeName.Font = value;
		}
	}
}

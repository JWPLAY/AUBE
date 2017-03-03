using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Base.Forms
{
	public partial class HelpForm : BaseForm
	{
		public HelpForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			richEditor.ReadOnly = true;

			lc.SetFieldName();
		}
		public string Subject
		{
			get
			{
				return txtHelpName.Text;
			}
			set
			{
				txtHelpName.EditValue = value;
			}
		}
		public object Content
		{
			get
			{
				return richEditor.Text;
			}
			set
			{
				richEditor.Text = value.ToStringNullToEmpty();
			}
		}
		public object ContentByRte
		{
			get
			{
				return richEditor.RtfText;
			}
			set
			{
				richEditor.RtfText = value.ToStringNullToEmpty();
			}
		}
		public string InsertDtime
		{
			get
			{
				return txtInsertDtime.Text;
			}
			set
			{
				txtInsertDtime.EditValue = value;
			}
		}
		public string InsertUserName
		{
			get
			{
				return txtInsertUserName.Text;
			}
			set
			{
				txtInsertUserName.EditValue = value;
			}
		}
		public string UpdateDtime
		{
			get
			{
				return txtUpdateDtime.Text;
			}
			set
			{
				txtUpdateDtime.EditValue = value;
			}
		}
		public string UpdateUserName
		{
			get
			{
				return txtUpdateUserName.Text;
			}
			set
			{
				txtUpdateUserName.EditValue = value;
			}
		}
	}
}

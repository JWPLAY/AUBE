using System.Windows.Forms;
using DevExpress.XtraEditors;
using JW.AUBE.Core.Resources;

namespace JW.AUBE.Core.Messages
{
	public partial class ErrorMessageBox : XtraForm
	{
		public ErrorMessageBox()
		{
			InitializeComponent();
			Init();

			btnOk.Click += delegate (object sender, System.EventArgs e)
			{
				Close();
			};
			Shown += delegate (object sender, System.EventArgs e)
			{
				btnOk.Focus();
			};
		}

		private void Init()
		{
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			Icon = IconResource.comment;

			memMessage.ReadOnly = true;
			memStackTrace.ReadOnly = true;

			lcTabGroup.SelectedTabPage = lcTabGroupMessage;
		}

		public object Message
		{
			get { return memMessage.EditValue; }
			set { memMessage.EditValue = value; }
		}

		public object StackTrace
		{
			get { return memStackTrace.EditValue; }
			set { memStackTrace.EditValue = value; }
		}
	}
}

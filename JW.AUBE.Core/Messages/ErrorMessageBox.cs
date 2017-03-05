using System.IO;
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
			//btnExport.Click += delegate (object sender, System.EventArgs e)
			//{
			//	using (var dlg = new SaveFileDialog())
			//	{
			//		dlg.Filter = "Text files (*.txt)|*.txt";
			//		dlg.Title = "Export in Text format";
			//		dlg.CheckPathExists = true;

			//		if (dlg.ShowDialog() == DialogResult.OK)
			//		{
			//			var fileName = dlg.FileName;
			//			File.WriteAllText(fileName, memMessage.Text);
			//		}
			//	}
			//};

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
		}

		public string Message
		{
			get
			{
				return memMessage.Text;
			}
			set
			{
				memMessage.Text = value;
			}
		}
	}
}

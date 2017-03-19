using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Utils;

namespace JW.AUBE.Core.Messages
{
	public static class MsgBox
	{
		public static void Show(string text)
		{
			XtraMessageBox.Show(text, "HELP!!");
		}
		public static void Show(string text, string caption)
		{
			XtraMessageBox.Show(text, caption);
		}
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
		{
			return XtraMessageBox.Show(text, caption, buttons);
		}
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return XtraMessageBox.Show(text, caption, buttons, icon);
		}
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
		{
			return XtraMessageBox.Show(text, caption, buttons, icon, defaultButton);
		}


		public static void Show(Exception ex)
		{
			try
			{
				var error = ErrorUtils.GetMessageAndTrace(ex);

				Logger.Error(error.Message);

				using (var msgbox = new ErrorMessageBox())
				{
					msgbox.Text = "ERROR!!";
					msgbox.Message = error.Message;
					msgbox.StackTrace = error.StackTrace;
					msgbox.ShowDialog();
				}
			}
			catch
			{
			}
		}
	}
}

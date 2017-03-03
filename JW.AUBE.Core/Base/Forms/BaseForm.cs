using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Interface;
using JW.AUBE.Core.Messages;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Base.Forms
{
	public partial class BaseForm : XtraForm, IBaseForm
	{
		private int _ModifiedCount = 0;
		private BackgroundWorker _BackgroundWorker = new BackgroundWorker();

		public BaseForm()
		{
			InitializeComponent();

			_BackgroundWorker.DoWork += delegate (object sender, DoWorkEventArgs e)
			{
				childCallback();
			};
		}

		public object FormId { get; set; }
		public object MenuId { get; set; }
		public Image TabImage { get; set; }
		public string LargeIcon { get; set; }
		public string SmallIcon { get; set; }
		public object ParamsData { get; set; }
		public object OptionData { get; set; }
		public object ReturnData { get; set; }
		public string ParentFormName { get; set; }
		public bool IsModified
		{
			get
			{
				return (_ModifiedCount > 0) ? true : false;
			}
		}

		public void SetModifiedCount()
		{
			_ModifiedCount++;
		}

		public void CallChildCallback(object data = null)
		{
			Logger.Debug(string.Format("{0}.CallChildCallback.Start..{1}", Name, data.ToStringNullToEmpty()));
			_BackgroundWorker.RunWorkerAsync();
			Logger.Debug(string.Format("{0}.CallChildCallback.End", Name));
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			Logger.Debug(string.Format("{0}.OnFormClosing.Start", Name));
			try
			{
				base.OnFormClosing(e);

				if (IsModified)
				{
					DialogResult = DialogResult.OK;
					if (ParentFormName.IsNullOrEmpty() == false)
					{
						if (FormUtils.IsExistsForm(ParentFormName))
						{
							((IBaseForm)FormUtils.GetForm(ParentFormName)).CallChildCallback();
						}
					}
				}
				else
				{
					DialogResult = DialogResult.Cancel;
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
			Logger.Debug(string.Format("{0}.OnFormClosing.End", Name));
		}
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			Logger.Debug(string.Format("{0}.OnFormClosed.Start...", Name));
			base.OnFormClosed(e);
			ClosedForm();
			Logger.Debug(string.Format("{0}.OnFormClosed.End...", Name));
		}
		protected override void OnLoad(EventArgs e)
		{
			Logger.Debug(string.Format("{0}.OnLoad.Start...", Name));
			base.OnLoad(e);
			LoadForm();
			Logger.Debug(string.Format("{0}.OnLoad.End...", Name));
		}

		/// <summary>
		/// Child폼 처리 후 호출되는 콜백함수
		/// </summary>
		protected virtual void ChildCallback(object data = null)
		{
		}
		private void childCallback(object data = null)
		{
			ChildCallback(data);
		}
		protected virtual void LoadForm()
		{
		}
		protected virtual void ClosingForm()
		{
		}
		protected virtual void ClosedForm()
		{
		}
	}
}

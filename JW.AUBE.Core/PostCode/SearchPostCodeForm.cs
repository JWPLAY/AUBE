using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Messages;
using Newtonsoft.Json.Linq;

namespace JW.AUBE.Core.PostCode
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	[ComVisible(true)]
	public partial class SearchPostCodeForm : XtraForm
	{
		//private bool bOpened = false;	//중복실행방지

		public SearchPostCodeForm()
		{
			InitializeComponent();

			wb.DocumentCompleted += delegate (object sender, WebBrowserDocumentCompletedEventArgs e)
			{
				try
				{
					//if (!bOpened)
					//{
					//	wb.Document.InvokeScript("daumEmbedOpen", new object[] { });
					//	bOpened = true;
					//}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Init();
		}

		private void Init()
		{
			try
			{
				wb.ObjectForScripting = this;
				wb.AllowWebBrowserDrop = false;
				//wb.IsWebBrowserContextMenuEnabled = false;
				//wb.WebBrowserShortcutsEnabled = false;

				string curDir = Directory.GetCurrentDirectory();
				wb.Url = new Uri(string.Format("file:///{0}/PostCode/searchpostcode.html", curDir));
				//wb.Navigate(new Uri(@"http://www.dwcts.co.kr/daumpostcode.html"));
				//http://www.dwcts.co.kr/daumpostcode.html
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public DataMap ReturnData { get; set; }

		public void DaumApiCallback(object data)
		{
			try
			{
				JObject obj = JObject.Parse(data.ToString());

				DataMap returnData = new DataMap()
				{
					{"POST_NO", obj["postcode"].ToString().Replace("-","")},
					{"ZONE_NO", obj["zonecode"].ToString()},
					{"ADDRESS1", (obj["userSelectedType"].ToString()=="J")?obj["jibunAddress"].ToString():obj["roadAddress"].ToString()},		//roadAddress, jibunAddress
					{"ADDRESS2", obj["buildingName"].ToString()}
				};

				this.ReturnData = returnData;
				this.DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);			
			}
		}
	}
}
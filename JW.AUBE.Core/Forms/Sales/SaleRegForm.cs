using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Sales
{
	public partial class SaleRegForm : EditForm
	{
		public SaleRegForm()
		{
			InitializeComponent();
		}

		protected override void InitButtons()
		{
			VisibleToolbar = false;
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtCustomer.SetEnable(false);
		}
		void InitGridItems()
		{

		}
		void InitGridCategory()
		{

		}
		void InitGridProducts()
		{

		}

		protected override void DataLoad(object param = null)
		{
			base.DataLoad(param);
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			base.DataSave(arg, callback);
		}


	}
}
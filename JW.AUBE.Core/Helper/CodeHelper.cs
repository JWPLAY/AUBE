using System.Data;
using System.Windows.Forms;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Helper
{
	public static class CodeHelper
	{
		public static DataTable Lookup(string parentCodeId, DataMap parameters = null)
		{
			try
			{
				if (parameters == null)
				{
					parameters = new DataMap();
				}
				parameters.SetValue("PARENT_CODE", parentCodeId);
				return (DataTable)DBTranHelper.SingleRequest("CodeHelp", "GetCodeHelpLookup", string.Empty, parameters);
			}
			catch
			{
				throw;
			}
		}
		public static DataTable Search(string parentCodeId, DataMap parameters = null)
		{
			try
			{
				if (parameters == null)
				{
					parameters = new DataMap();
				}
				parameters.SetValue("PARENT_CODE", parentCodeId);
				return (DataTable)DBTranHelper.SingleRequest("CodeHelp", "GetCodeHelpLookup", string.Empty, parameters);
			}
			catch
			{
				throw;
			}
		}
		public static DataMap ShowForm(string parentCodeId, DataMap parameters = null, DataTable data = null)
		{
			DataMap resultMap = new DataMap();
			try
			{
				if (parameters == null)
				{
					parameters = new DataMap();
				}
				parameters.SetValue("PARENT_CODE", parentCodeId);

				string formName = "CodeHelperForm_" + parentCodeId;
				string formText = "코드검색";
				string codeField = "CODE";
				string nameField = "NAME";
				string[] displayFields = new string[] { "CODE", "NAME" };

				switch (parentCodeId)
				{
					case "ALL_PRODUCT":
						formText = "제품검색";
						codeField = "PRODUCT_ID";
						nameField = "PRODUCT_NAME";
						displayFields = new string[] { "PRODUCT_TYPE", "CATEGORY", "PRODUCT_ID", "PRODUCT_NAME", "PRODUCT_CODE" };
						break;
					case "MATERIAL":
						formText = "원부자재검색";
						codeField = "MATERIAL_ID";
						nameField = "MATERIAL_NAME";
						displayFields = new string[] { "MATERIAL_ID", "MATERIAL_NAME", "UNIT_TYPE" };
						break;
					case "PRODUCT":
					case "PROD_PRODUCT":
						formText = "제품검색";
						codeField = "PRODUCT_ID";
						nameField = "PRODUCT_NAME";
						displayFields = new string[] { "PRODUCT_ID", "PRODUCT_NAME", "PRODUCT_CODE" };
						break;
					case "PURCITEM":
						formText = "구매품목검색";
						codeField = "PRODUCT_ID";
						nameField = "PRODUCT_NAME";
						displayFields = new string[] { "PRODUCT_ID", "PRODUCT_NAME", "PRODUCT_CODE" };
						break;
					case "CUSTOMER":
						formText = "거래처검색";
						codeField = "CUSTOMER_ID";
						nameField = "CUSTOMER_NAME";
						displayFields = new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "BIZ_REG_NO", "REP_NAME" };
						break;
					case "USER":
						formText = "사용자검색";
						codeField = "USER_ID";
						nameField = "USER_NAME";
						displayFields = new string[] { "USER_ID", "USER_NAME" };
						break;
				}

				using (var form = new CodeHelperForm()
				{
					Name = formName,
					Text = formText,
					StartPosition = FormStartPosition.CenterScreen,
					CodeField = codeField,
					NameField = nameField,
					CodeGroup = parentCodeId,
					Parameters = parameters,
					DisplayFields = displayFields
				})
				{
					form.Init();
					form.BindData(data);

					if (form.ShowDialog() == DialogResult.OK)
					{
						if (form.ReturnData != null && form.ReturnData.GetType() == typeof(DataMap))
						{
							resultMap = (form.ReturnData as DataMap);
						}
					}
				}
				return resultMap;
			}
			catch
			{
				throw;
			}
		}
	}
}

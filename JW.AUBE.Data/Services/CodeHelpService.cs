using System;
using System.Collections.Generic;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Data.Mappers;

namespace JW.AUBE.Data.Services
{
	public static class CodeHelpService
	{
		public static WasRequest GetCodeHelpLookup(WasRequest req)
		{
			try
			{
				IList<DataMap> list;
				var parentCode = req.Parameter.GetValue("PARENT_CODE").ToStringNullToEmpty().ToCamelCase();
				switch (parentCode)
				{
					case "Module":
					case "View":
					case "Menu":
					case "Group":
					case "Role":
					case "Help":
					case "Code":
					case "CodeGroup":
					case "Customer":
					case "Product":
					case "ProdProduct":
					case "Material":
					case "Purcitem":
					case "Saleitem":
					case "Department":
					case "Employee":
					case "Project":
					case "Work":
					case "Task":
					case "MasterPlanResource":
					case "MasterPlan":
					case "System":
						list = DaoFactory.Instance.QueryForList<DataMap>(string.Format("GetCodeHelp{0}List", parentCode), req.Parameter);
						break;
					default:
						list = DaoFactory.Instance.QueryForList<DataMap>("GetCodeHelp", req.Parameter);
						break;
				}

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};

				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}
	}
}

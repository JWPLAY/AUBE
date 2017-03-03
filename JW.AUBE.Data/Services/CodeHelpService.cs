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
				var parentCode = req.Parameter.GetValue("PARENT_CODE").ToStringNullToEmpty();
				switch (parentCode)
				{
					case "Modules":
					case "Views":
					case "Menus":
					case "Groups":
					case "Roles":
					case "Helps":
					case "Codes":
					case "CodeGroup":
					case "Customers":
					case "Departments":
					case "Employees":
					case "Projects":
					case "Works":
					case "Tasks":
					case "MasterPlanResources":
					case "MasterPlans":
					case "Systems":
						list = DaoFactory.Instance.QueryForList<DataMap>(string.Format("GetCodeHelpLookupBy{0}", parentCode), req.Parameter);
						break;
					default:
						list = DaoFactory.Instance.QueryForList<DataMap>("GetCodeHelpLookup", req.Parameter);
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

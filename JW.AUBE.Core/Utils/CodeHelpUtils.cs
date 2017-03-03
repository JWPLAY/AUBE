using System.Data;
using JW.AUBE.Base.Map;

namespace JW.AUBE.Core.Utils
{
	public static class CodeHelpUtils
	{
		public static DataTable GetCodeHelpLookup(string parentCodeId, DataMap parameters = null)
		{
			try
			{
				if (parameters == null)
				{
					parameters = new DataMap();
				}
				parameters.SetValue("PARENT_CODE", parentCodeId);
				return ServerRequest.SingleRequest("CodeHelp", "GetCodeHelpLookup", string.Empty, parameters);
			}
			catch
			{
				throw;
			}
		}
		public static DataTable GetCodeHelpSearch(string parentCodeId, DataMap parameters = null)
		{
			try
			{
				if (parameters == null)
				{
					parameters = new DataMap();
				}
				parameters.SetValue("PARENT_CODE", parentCodeId);
				return ServerRequest.SingleRequest("CodeHelp", "GetCodeHelpLookup", string.Empty, parameters);
			}
			catch
			{
				throw;
			}
		}
	}
}

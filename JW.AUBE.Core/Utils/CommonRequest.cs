using System;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;

namespace JW.AUBE.Core.Utils
{
	public static class CommonRequest
	{
		public static int SaveAddress(DataMap map)
		{
			try
			{
				var res = DBTranHelper.Execute("Base", "Save", "Address", map);
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				if (res.TranList[0].ReturnValue == null)
					throw new Exception("반환값이 정확하지 않습니다.");

				return res.TranList[0].ReturnValue.ToIntegerNullToZero();
			}
			catch
			{
				throw;
			}
		}
	}
}

namespace JW.AUBE.Base.Utils
{
	public static class CheckDigitUtils
	{
		public static bool CheckBizCode(string strCode)
		{
			var bResult = false;
			var nBCK = 0;

			if (strCode.Length != 10)
			{
				return false;
			}
			else
			{
				nBCK += int.Parse(strCode.ToString().Substring(0, 1)) * 1;
				nBCK += int.Parse(strCode.ToString().Substring(1, 1)) * 3;
				nBCK += int.Parse(strCode.ToString().Substring(2, 1)) * 7;
				nBCK += int.Parse(strCode.ToString().Substring(3, 1)) * 1;
				nBCK += int.Parse(strCode.ToString().Substring(4, 1)) * 3;
				nBCK += int.Parse(strCode.ToString().Substring(5, 1)) * 7;
				nBCK += int.Parse(strCode.ToString().Substring(6, 1)) * 1;
				nBCK += int.Parse(strCode.ToString().Substring(7, 1)) * 3;
				nBCK += int.Parse(strCode.ToString().Substring(8, 1)) * 5 / 10;
				nBCK += int.Parse(strCode.ToString().Substring(8, 1)) * 5 % 10;
				nBCK += int.Parse(strCode.ToString().Substring(9, 1));
			}

			if (nBCK % 10 == 0)
			{
				bResult = true;
			}

			return bResult;
		}
	}
}

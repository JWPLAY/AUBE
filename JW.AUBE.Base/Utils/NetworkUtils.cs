namespace JW.AUBE.Base.Utils
{
	public static class NetworkUtils
	{
		public static bool IsConnectedToInternet()
		{
			if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
			{
				return false;
			}
			else
			{
				int Desc;
				return UnsafeNativeMethods.InternetGetConnectedState(out Desc, 0);
			}
		}

		public static bool IsConnectedToNetwork()
		{
			var networkType = UnsafeNativeMethods.NETWORK_WAN;
			return (UnsafeNativeMethods.IsNetworkAlive(ref networkType) == 1) ? true : false;
		}
	}
}

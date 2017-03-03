using System;
using System.Runtime.InteropServices;
using System.Security;

namespace JW.AUBE.Base.Utils
{
	[SuppressUnmanagedCodeSecurity]
	public static class UnsafeNativeMethods
	{
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);
		public const int EM_SETTABSTOPS = 0x00CB;

		[DllImport("wininet.dll")]
		internal extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

		[DllImport("Sensapi.dll")]
		internal static extern int IsNetworkAlive(ref int dwFlags);
		public const int NETWORK_LAN = 0x01;
		public const int NETWORK_WAN = 0x02;
		public const int NETWORK_AOL = 0x04;
	}
}

using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace JW.AUBE.Base.Utils
{
	public static class CommonUtils
	{
		public static string GetClickOnceVersion()
		{
			try
			{
#if (DEBUG)
				return "Debug Mode";
#else
				Version version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
				return string.Format("{0}.{1}.{2}.{3}", version.Major.ToString(), version.Minor.ToString(), version.Build.ToString(), version.Revision.ToString());
#endif
			}
			catch
			{
				return null;
			}
		}

		public static string GetIp()
		{
			var ipHost = Dns.GetHostEntry(Dns.GetHostName());
			var ip = String.Empty;
			for (var i = 0; i < ipHost.AddressList.Length; i++)
			{
				if (ipHost.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
				{
					ip = ipHost.AddressList[i].ToString();
				}
			}
			return ip;
		}

		public static string GetMacAddress()
		{
			var ip = GetIp();
			var rtn = string.Empty;
			var oq = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'");
			var query1 = new ManagementObjectSearcher(oq);
			foreach (ManagementObject mo in query1.Get())
			{
				var address = (string[])mo["IPAddress"];
				if (address[0] == ip && mo["MACAddress"] != null)
				{
					rtn = mo["MACAddress"].ToString();
					break;
				}
			}
			return rtn;
		}

		public static long GetObjectMerorySize(object obj)
		{
			long size = 0;
			var o = new object();
			using (Stream s = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(s, obj);
				size = s.Length;
			}
			return size;
		}

		public static void StartProcess(string path)
		{
			var process = new Process();
			try
			{
				process.StartInfo.FileName = path;
				process.Start();
				process.WaitForInputIdle();
			}
			catch
			{
				throw;
			}
		}
	}
}

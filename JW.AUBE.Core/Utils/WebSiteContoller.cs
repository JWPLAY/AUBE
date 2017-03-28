using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Management;
using JW.AUBE.Core.Messages;

namespace JW.AUBE.Core.Utils
{
	public static class WebSiteContoller
	{
		public enum SiteAction
		{
			Start = 2,
			Stop = 4,
			Pause = 6,
		}
		public static void SiteInvoke(SiteAction action)
		{
			string site = getSiteIdByName("AubeWeb");
			if (site == null)
			{
				return;
			}

			try
			{
				ConnectionOptions connectionOptions = new ConnectionOptions() { Impersonation = ImpersonationLevel.Impersonate };

				ManagementScope managementScope =
					new ManagementScope(@"\\" + "localhost" + @"\root\microsoftiisv2", connectionOptions);

				managementScope.Connect();
				if (managementScope.IsConnected == false)
				{
					MsgBox.Show("Could not connect to WMI namespace " + managementScope.Path, "Connect Failed");
				}
				else
				{
					SelectQuery selectQuery =
						new SelectQuery(string.Format("Select * From IIsWebServer Where Name = 'W3SVC/{0}'", site));
					using (ManagementObjectSearcher managementObjectSearcher =
							new ManagementObjectSearcher(managementScope, selectQuery))
					{
						foreach (ManagementObject objMgmt in managementObjectSearcher.Get())
							objMgmt.InvokeMethod(action.ToString(), new object[0]);
					}
				}
			}
			catch (Exception ex)
			{
				if (ex.ToString().Contains("Invalid namespace"))
				{
					MsgBox.Show("Invalid Namespace Exception" + Environment.NewLine + Environment.NewLine +
									"This program only works with IIS 6 and later", string.Format("Can't {0} website", action));
				}
				else
				{
					MsgBox.Show(ex.Message, string.Format("Can't {0} website", action));
				}
			}
		}

		private static string getSiteIdByName(string siteName)
		{
			DirectoryEntry root = getDirectoryEntry("IIS://localhost/W3SVC");
			foreach (DirectoryEntry e in root.Children)
			{
				if (e.SchemaClassName == "IIsWebServer")
				{
					if (e.Properties["ServerComment"].Value.ToString().Equals(siteName, StringComparison.OrdinalIgnoreCase))
					{
						return e.Name;
					}
				}
			}
			return null;
		}

		private static string[] enumerateSites()
		{
			List<string> siteNames = new List<string>();
			try
			{
				DirectoryEntry root = getDirectoryEntry("IIS://localhost/W3SVC");
				foreach (DirectoryEntry e in root.Children)
				{
					if (e.SchemaClassName == "IIsWebServer")
					{
						siteNames.Add(e.Properties["ServerComment"].Value.ToString());
					}
				}
			}
			catch { }
			return siteNames.ToArray();
		}

		private static bool findWebsite(string siteName)
		{
			string site = getSiteIdByName(siteName);
			if (site == null)
			{
				return false;
			}
			return true;
		}

		private static DirectoryEntry getDirectoryEntry(string path)
		{
			return new DirectoryEntry(path);
		}
	}
}

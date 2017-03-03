using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraNavBar;

namespace JW.AUBE.Core.Utils
{
	public static class NavBarUtils
	{
		public static void CreateNavBarItem(this NavBarControl bar, DataTable dt, ImageCollection images)
		{
			try
			{
				if (dt == null || dt.Rows.Count == 0)
				{
					return;
				}
				NavBarItem navItem = null;
				NavBarGroup navGroup = null;
				var groupName = String.Empty;

				bar.BeginUpdate();

				bar.Items.Clear();
				bar.Groups.Clear();

				foreach (DataRow dr in dt.Rows)
				{
					if (Convert.ToInt32(dr["CHILD_COUNT"]) > 0)
					{
						groupName = string.Format("navGroup_{0}", dr["MNU_ID"]);
						navGroup = bar.GetNavBarGroup(groupName, dr["MNU_NM"].ToString());
						if (images != null)
						{
							navGroup.SmallImage = images.Images[0];
						}
						navGroup.Visible = true;
					}
					else
					{
						groupName = string.Format("navGroup_{0}", dr["PARENT_MNU_ID"]);
						navGroup = bar.GetNavBarGroup(groupName, dr["PARENT_MNU_NM"].ToString());
						navItem = new NavBarItem(dr["MNU_NM"].ToString());
						navItem.Name = string.Format("navItem_{0}", dr["MNU_ID"]);
						if (images != null)
						{
							navItem.SmallImage = images.Images[2];
						}
						navItem.Visible = true;
						navItem.Enabled = true;
						navItem.Tag = dr["MNU_ID"];
						navGroup.ItemLinks.Add(navItem);
						bar.Items.Add(navItem);
					}
				}
				bar.EndUpdate();
			}
			catch
			{
				throw;
			}
		}

		private static NavBarGroup GetNavBarGroup(this NavBarControl bar, string groupName, string caption)
		{
			try
			{
				var navGroup = bar.Groups[groupName];
				if (navGroup == null)
				{
					navGroup = new NavBarGroup(caption);
					navGroup.Name = groupName;
					bar.Groups.Add(navGroup);
				}
				return navGroup;
			}
			catch
			{
				throw;
			}
		}
	}
}

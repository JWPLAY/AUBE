using JW.AUBE.Core.Utils;
using DevExpress.XtraGrid.Localization;

namespace JW.AUBE.Core.Controls.Grid
{
	public class KoreanGridLocalizer : GridLocalizer
	{
		public override string Language
		{
			get
			{
				return "Korean";
			}
		}
		public override string GetLocalizedString(GridStringId id)
		{
			try
			{
				var ret = DomainUtils.GetPopMenuValue(id.ToString().Replace("GridStringId.", string.Empty));
				if (string.IsNullOrEmpty(ret) || ret.Equals(id))
				{
					ret = base.GetLocalizedString(id);
				}
				return ret;
			}
			catch
			{
				return base.GetLocalizedString(id);
			}
		}
	}
}

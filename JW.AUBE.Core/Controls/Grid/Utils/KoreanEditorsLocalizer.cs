using JW.AUBE.Core.Utils;
using DevExpress.XtraEditors.Controls;

namespace JW.AUBE.Core.Controls.Grid
{
	public class KoreanEditorsLocalizer : Localizer
	{
		public override string Language
		{
			get
			{
				return "Korean";
			}
		}
		public override string GetLocalizedString(StringId id)
		{
			try
			{
				var ret = DomainUtils.GetPopMenuValue(id.ToString().Replace("StringId.", string.Empty));
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

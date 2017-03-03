using JW.AUBE.Base.Map;

namespace JW.AUBE.Core.Resources
{
	public static class DomainResource
	{
		public static StringMap Fields { get; set; }
		public static StringMap Messages { get; set; }
		public static StringMap PopMenus { get; set; }

		static DomainResource()
		{
			if (Fields == null)
			{
				Fields = new StringMap();
			}
			if (Messages == null)
			{
				Messages = new StringMap();
			}
			if (PopMenus == null)
			{
				PopMenus = new StringMap();
			}
		}
	}
}

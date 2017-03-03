namespace JW.AUBE.Core.Models
{
	public class ToolbarButtons : IToolbarButtons
	{
		public bool Refresh { get; set; }
		public bool New { get; set; }
		public bool Save { get; set; }
		public bool SaveAndNew { get; set; }
		public bool SaveAndClose { get; set; }
		public bool Delete { get; set; }
		public bool Cancel { get; set; }
		public bool Export { get; set; }
		public bool Print { get; set; }

		public ToolbarButtons()
		{
			Refresh =
			New =
			Save =
			SaveAndNew =
			SaveAndClose =
			Delete =
			Cancel =
			Export =
			Print = false;
		}
	}
}

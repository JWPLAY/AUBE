namespace JW.AUBE.Core.Models
{
	public interface IToolbarButtons
	{
		bool Refresh { get; set; }
		bool New { get; set; }
		bool Save { get; set; }
		bool SaveAndNew { get; set; }
		bool SaveAndClose { get; set; }
		bool Delete { get; set; }
		bool Cancel { get; set; }
		bool Export { get; set; }
		bool Print { get; set; }
	}
}

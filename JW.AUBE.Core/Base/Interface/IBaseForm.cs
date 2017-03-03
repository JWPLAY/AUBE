using System.Drawing;

namespace JW.AUBE.Core.Base.Interface
{
	public interface IBaseForm
	{
		object FormId { get; set; }
		object MenuId { get; set; }
		Image TabImage { get; set; }
		string LargeIcon { get; set; }
		string SmallIcon { get; set; }
		object ParamsData { get; set; }
		object OptionData { get; set; }
		object ReturnData { get; set; }
		string ParentFormName { get; set; }
		bool IsModified { get; }

		void SetModifiedCount();
		void CallChildCallback(object data = null);
	}
}

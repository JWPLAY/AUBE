using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;

namespace JW.AUBE.Core.Base.Interface
{
	public interface IEditForm
	{
		ToolbarButtons ToolbarButtons { get; set; }
		EditModeEnum EditMode { get; set; }
		bool VisibleToolbar { get; set; }
		bool VisibleStatusbar { get; set; }
		bool IsLoadingRefresh { get; set; }
		ElapseTime LoadingElapseTime { get; set; }
		bool IsLoaded { get; }

		bool IsDataEdit { get; set; }
		bool IsTranList { get; set; }
		FormTypeEnum FormType { get; set; }

		void SetToolbarButtons(ToolbarButtons toolbarButtons);
	}
}

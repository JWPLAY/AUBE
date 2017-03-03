using System.ComponentModel;
using System.Reflection;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;

namespace JW.AUBE.Core.Base.Forms
{
	[DefaultEvent("PropertyChanged")]
	[DefaultProperty("EditMode")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class EditFormProperties : INotifyPropertyChanged
	{
		private ToolbarButtons _ToolbarButtons;
		private EditModeEnum _EditMode;
		private bool _VisibleToolbar;
		private bool _VisibleStatusbar;
		private bool _IsLoadingRefresh;

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName.Replace("set_", string.Empty)));
		}

		public EditFormProperties()
		{
			LoadingElapseTime = new ElapseTime();
			_ToolbarButtons = new ToolbarButtons();
			_EditMode = EditModeEnum.List;
			_VisibleToolbar = true;
			_VisibleStatusbar = true;
			_IsLoadingRefresh = false;
			IsLoaded = false;
		}

		[Browsable(false)]
		[NotifyParentProperty(true)]
		public ElapseTime LoadingElapseTime { get; set; }

		[Browsable(true)]
		[NotifyParentProperty(true)]
		public ToolbarButtons ToolbarButtons
		{
			get
			{
				return _ToolbarButtons;
			}
			set
			{
				_ToolbarButtons = value;
				OnPropertyChanged(MethodBase.GetCurrentMethod().Name);
			}
		}

		[Browsable(true)]
		[NotifyParentProperty(true)]
		public EditModeEnum EditMode
		{
			get
			{
				return _EditMode;
			}
			set
			{
				_EditMode = value;
				OnPropertyChanged(MethodBase.GetCurrentMethod().Name);
			}
		}

		[Browsable(true)]
		[NotifyParentProperty(true)]
		public bool VisibleToolbar
		{
			get
			{
				return _VisibleToolbar;
			}
			set
			{
				_VisibleToolbar = value;
				OnPropertyChanged(MethodBase.GetCurrentMethod().Name);
			}
		}

		[Browsable(true)]
		[NotifyParentProperty(true)]
		public bool VisibleStatusbar
		{
			get
			{
				return _VisibleStatusbar;
			}
			set
			{
				_VisibleStatusbar = value;
				OnPropertyChanged(MethodBase.GetCurrentMethod().Name);
			}
		}

		[Browsable(true)]
		[NotifyParentProperty(true)]
		public bool IsLoadingRefresh
		{
			get
			{
				return _IsLoadingRefresh;
			}
			set
			{
				_IsLoadingRefresh = value;
				OnPropertyChanged(MethodBase.GetCurrentMethod().Name);
			}
		}

		[Browsable(false)]
		[NotifyParentProperty(true)]
		public bool IsLoaded { get; set; }
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls.Common
{
	public partial class XPeriod : XtraUserControl
	{
		public bool mIsEnable = true;

		public event EventHandler OnDateFrEditValueChanged;
		public event EventHandler OnDateToEditValueChanged;

		public XPeriod()
		{
			InitializeComponent();
			Initialize();

			datDateFr.EditValueChanged += delegate (object sender, EventArgs e)
			{
				OnDateFrEditValueChanged?.Invoke(sender, e);
			};
			datDateTo.EditValueChanged += delegate (object sender, EventArgs e)
			{
				OnDateToEditValueChanged?.Invoke(sender, e);
			};
		}

		[Browsable(false)]
		public DateEdit DateFrEdit
		{
			get
			{
				return datDateFr;
			}
		}

		[Browsable(false)]
		public DateEdit DateToEdit
		{
			get
			{
				return datDateTo;
			}
		}

		[Browsable(false)]
		public object FromEditValue
		{
			get
			{
				return datDateFr.EditValue;
			}
			set
			{
				datDateFr.EditValue = value;
			}
		}

		[Browsable(false)]
		public object ToEditValue
		{
			get
			{
				return datDateTo.EditValue;
			}
			set
			{
				datDateTo.EditValue = value;
			}
		}

		private void Initialize()
		{
			datDateFr.Left = 0;
			lbl.Left = datDateFr.Width;
			datDateTo.Left = lbl.Left + lbl.Width;
			Width = datDateFr.Width + lbl.Width + datDateTo.Width;

			Init();
		}

		public void Init()
		{
			datDateFr.Init();
			datDateTo.Init();
		}

		public void Init(CalendarViewType viewType = CalendarViewType.DayView)
		{
			datDateFr.Init(viewType);
			datDateTo.Init(viewType);
		}

		public void Clear()
		{
			datDateFr.EditValue = null;
			datDateTo.EditValue = null;
		}

		public void ClearFr()
		{
			datDateFr.EditValue = null;
		}

		public void ClearTo()
		{
			datDateTo.EditValue = null;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (datDateFr == null)
			{
				Height = 20;
				MinimumSize = new Size(220, 20);
				MaximumSize = new Size(220, 20);
			}
			else
			{
				Height = datDateFr.Height;
				MaximumSize = new Size(0, datDateFr.Height);
				MinimumSize = new Size(datDateFr.Width + lbl.Width + datDateTo.Width, datDateFr.Height);
			}
			Refresh();
		}

		public void SetEnable(bool bEnable = false)
		{
			mIsEnable = bEnable;
			datDateFr.SetEnable(bEnable);
			datDateTo.SetEnable(bEnable);
		}

		public void SetForeColor(Color color)
		{
			datDateFr.Properties.Appearance.ForeColor =
				datDateTo.Properties.Appearance.ForeColor = color;
		}
	}
}

using System;
using System.ComponentModel;
using System.Data;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Controls.Common;
using JW.AUBE.Core.Controls.Grid;
using DevExpress.XtraEditors;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Controls
{
	[ToolboxItem(true)]
	public partial class XPager : XtraUserControl
	{
		private int mPageNo = 1;
		private int mPageSize = 0;
		private int mBlockSize = 10;
		private int mTotalPages = 1;
		private int mTotalRecords = 0;
		private int mCurrentRecords = 0;

		public delegate void XPagerButtonClickEventHandler(object sender, XPagerButtonClickEventArgs e);
		public event XPagerButtonClickEventHandler XPagerButtonClickEvent;
		public event EventHandler PagingChanged;

		public XPager()
		{
			InitializeComponent();
			Init();

			btnFirst.Click += ButtonClicked;
			btnPrevBlock.Click += ButtonClicked;
			btnPrev.Click += ButtonClicked;
			btnNext.Click += ButtonClicked;
			btnNextBlock.Click += ButtonClicked;
			btnLast.Click += ButtonClicked;

			lupPageSize.EditValueChanged += delegate (object sender, EventArgs e)
			{
				var lup = sender as XLookup;
				if ((int)lup.EditValue != mPageSize)
				{
					mPageNo = 1;
					mPageSize = (int)lup.EditValue;
					SetPaging();
					PagingChanged.Invoke(sender, e);
				}
			};
			spnPageNo.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if ((int)spnPageNo.EditValue != mPageNo)
				{
					if (spnPageNo.EditValue.ToIntegerNullToZero() > spnTotalPages.EditValue.ToIntegerNullToZero())
					{
						spnPageNo.EditValue = mPageNo;
						SetPaging();
					}
					else
					{
						mPageNo = (int)spnPageNo.EditValue;
						SetPaging();
						PagingChanged.Invoke(sender, e);
					}
				}
			};
		}

		private void ButtonClicked(object sender, EventArgs e)
		{
			if (((SimpleButton)sender).Name.Equals("btnFirst"))
			{
				if (mPageNo > 1)
				{
					mPageNo = 1;

					PagingChanged.Invoke(sender, e);
				}
				XPagerButtonClickEvent.Invoke(this, new XPagerButtonClickEventArgs(XPagerButtonType.First));
			}
			else
			{
				if (((SimpleButton)sender).Name.Equals("btnPrevBlock"))
				{
					if (mPageNo > mBlockSize)
					{
						mPageNo = mPageNo - mBlockSize;

						PagingChanged.Invoke(sender, e);
					}
					XPagerButtonClickEvent.Invoke(this, new XPagerButtonClickEventArgs(XPagerButtonType.BlockPrevious));
				}
				else
				{
					if (((SimpleButton)sender).Name.Equals("btnPrev"))
					{
						if (mPageNo > 1)
						{
							mPageNo--;

							PagingChanged.Invoke(sender, e);
						}
						XPagerButtonClickEvent.Invoke(this, new XPagerButtonClickEventArgs(XPagerButtonType.Previous));
					}
					else
					{
						if (((SimpleButton)sender).Name.Equals("btnNext"))
						{
							if (mPageNo < mTotalPages)
							{
								mPageNo = mPageNo + 1;

								PagingChanged.Invoke(sender, e);
							}
							XPagerButtonClickEvent.Invoke(this, new XPagerButtonClickEventArgs(XPagerButtonType.Next));
						}
						else
						{
							if (((SimpleButton)sender).Name.Equals("btnNextBlock"))
							{
								if (((int)((mPageNo - 1) / 10) + 1) < ((int)((mTotalPages - 1) / 10) + 1))
								{
									if ((mPageNo + mBlockSize) < mTotalPages)
									{
										mPageNo = mPageNo + mBlockSize;
									}
									else
									{
										mPageNo = mTotalPages;
									}
									PagingChanged.Invoke(sender, e);
								}
								XPagerButtonClickEvent.Invoke(this, new XPagerButtonClickEventArgs(XPagerButtonType.BlockNext));
							}
							else
							{
								if (((SimpleButton)sender).Name.Equals("btnLast"))
								{
									if (mPageNo < mTotalPages)
									{
										mPageNo = mTotalPages;

										PagingChanged.Invoke(this, e);
									}
									XPagerButtonClickEvent.Invoke(this, new XPagerButtonClickEventArgs(XPagerButtonType.Last));
								}
							}
						}
					}
				}
			}
		}

		private void Init()
		{
			spnPageNo.SetFormat("N0", false);
			spnPageNo.Properties.MinValue = 1;

			spnTotalPages.SetFormat("N0", false);
			spnTotalPages.Properties.MinValue = 1;
			spnTotalPages.ReadOnly = true;

			PageNo = 1;
			PageSize = 0;
			BlockSize = 10;
			TotalPages = 0;
			TotalRecords = 0;
			CurrentRecords = 0;

			InitPageSize();
		}

		private void InitPageSize()
		{
			var dtPageSize = new DataTable();
			dtPageSize.Columns.AddRange(new DataColumn[] {
																new DataColumn("ID", typeof(string)),
																new DataColumn("NM", typeof(string))
												});
			dtPageSize.Rows.Add("0", "ALL");
			dtPageSize.Rows.Add("10", "10");
			dtPageSize.Rows.Add("50", "50");
			dtPageSize.Rows.Add("100", "100");
			dtPageSize.Rows.Add("500", "500");
			dtPageSize.Rows.Add("1000", "1000");

			lupPageSize.SetDefault();
			lupPageSize.DataSource = dtPageSize;
			lupPageSize.EditValue = "0";
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			Height = lupPageSize.Height + 6;
		}

		[Browsable(true)]
		public XGrid Grid { get; set; }

		[Browsable(false)]
		[Category("UxEntended Properties")]
		public int PageNo
		{
			get
			{
				return mPageNo;
			}
			set
			{
				mPageNo = value;
			}
		}

		[Browsable(false)]
		[Category("UxEntended Properties")]
		public int PageSize
		{
			get
			{
				return mPageSize;
			}
			set
			{
				mPageSize = value;
			}
		}

		[Browsable(true)]
		[Category("UxEntended Properties")]
		public int BlockSize
		{
			get
			{
				return mBlockSize;
			}
			set
			{
				mBlockSize = value;
			}
		}

		[Browsable(false)]
		[Category("UxEntended Properties")]
		public int TotalPages
		{
			get
			{
				return mTotalPages;
			}
			set
			{
				mTotalPages = value;
			}
		}

		[Browsable(false)]
		[Category("UxEntended Properties")]
		public int TotalRecords
		{
			get
			{
				return mTotalRecords;
			}
			set
			{
				mTotalRecords = value;

				if (value == 0)
				{
					TotalPages = 0;
				}
				else
				{
					if (PageSize == 0)
					{
						TotalPages = 1;
					}
					else
					{
						TotalPages = (int)((value - 1) / PageSize) + 1;
					}
				}
			}
		}

		[Browsable(false)]
		[Category("UxEntended Properties")]
		public int CurrentRecords
		{
			get
			{
				return mCurrentRecords;
			}
			set
			{
				mCurrentRecords = value;
			}
		}

		public void SetPaging()
		{
			btnFirst.Enabled =
																btnPrevBlock.Enabled =
																btnPrev.Enabled =
																btnNext.Enabled =
																btnNextBlock.Enabled =
																btnLast.Enabled =
																spnPageNo.Enabled =
																spnPageNo.Enabled = false;


			if (mTotalPages > 0)
			{
				spnPageNo.Enabled = true;

				if (mPageNo > 1)
				{
					btnFirst.Enabled = true;
					btnPrev.Enabled = true;
				}

				if (mPageNo < mTotalPages)
				{
					btnLast.Enabled = true;
					btnNext.Enabled = true;
				}

				if (mPageNo > mBlockSize)
				{
					btnPrevBlock.Enabled = true;
				}

				if ((int)((mPageNo - 1) / mBlockSize) < (int)((mTotalPages - 1) / mBlockSize))
				{
					btnNextBlock.Enabled = true;
				}
			}
		}
	}
}

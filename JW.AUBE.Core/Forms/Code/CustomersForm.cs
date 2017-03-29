using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using JW.AUBE.Base.DBTran.Controller;
using JW.AUBE.Base.DBTran.Model;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Base.Forms;
using JW.AUBE.Core.Controls.Grid;
using JW.AUBE.Core.Enumerations;
using JW.AUBE.Core.Models;
using JW.AUBE.Core.PostCode;
using JW.AUBE.Core.Utils;

namespace JW.AUBE.Core.Forms.Code
{
	public partial class CustomersForm : EditForm
	{
		private object mBizRegId = null;
		private object mAddressId = null;

		public CustomersForm()
		{
			InitializeComponent();

			txtPostNo.ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if(e.Button.Kind== ButtonPredefines.Ellipsis)
				{
					var postdata = SearchPostCode.Find();
					if (postdata != null && postdata.GetType() == typeof(DataMap))
					{
						txtPostNo.EditValue = postdata.GetValue("POST_NO");
						txtZoneNo.EditValue = postdata.GetValue("ZONE_NO");
						txtAddress1.EditValue = postdata.GetValue("ADDRESS1");
						txtAddress2.EditValue = postdata.GetValue("ADDRESS2");
						txtAddress2.Focus();
					}
				}
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });

			btnAddressAdd.Enabled =
				btnAddressDel.Enabled =
				btnAddressSave.Enabled =
				btnPhoneAdd.Enabled =
				btnPhoneDel.Enabled =
				btnPhoneSave.Enabled = true;

			btnAddressAdd.Click += delegate (object sender, EventArgs e)
			{
				int rowindex = gridAddress.AddNewRow();
				gridAddress.SetValue(rowindex, "ADDRESS_TYPE", "20");
				gridAddress.SetFocus(rowindex, "ADDRESS_TYPE");
			};
			btnAddressDel.Click += delegate (object sender, EventArgs e)
			{
				if (gridAddress.MainView.FocusedRowHandle < 0)
					return;
				gridAddress.MainView.DeleteRow(gridAddress.MainView.FocusedRowHandle);
			};
			btnAddressSave.Click += delegate (object sender, EventArgs e)
			{
				DataSaveAddress(true);
			};

			btnPhoneAdd.Click += delegate (object sender, EventArgs e)
			{
				int rowindex = gridPhones.AddNewRow();
				gridPhones.SetValue(rowindex, "PHONE_TYPE", "20");
				gridPhones.SetFocus(rowindex, "PHONE_TYPE");
			};
			btnPhoneDel.Click += delegate (object sender, EventArgs e)
			{
				if (gridPhones.MainView.FocusedRowHandle < 0)
					return;

				gridPhones.MainView.DeleteRow(gridPhones.MainView.FocusedRowHandle);
			};
			btnPhoneSave.Click += delegate (object sender, EventArgs e)
			{
				DataSavePhones(true);
			};
		}

		protected override void InitControls()
		{
			base.InitControls();

			lcItemCustomerName.Tag = true;

			SetFieldNames();

			txtCustomerId.SetEnable(false);
			txtInsTime.SetEnable(false);
			txtInsUserName.SetEnable(false);
			txtUpdTime.SetEnable(false);
			txtUpdUserName.SetEnable(false);
			txtZoneNo.SetEnable(false);
			txtAddress1.SetEnable(false);

			txtPostNo.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

			InitCombo();
			InitGrid();

			lcTabGroup.SelectedTabPage = lcTabGroupBiz;
		}

		void InitCombo()
		{
			lupCustomerType.BindData("CUSTOMER_TYPE", null, null, true);
		}

		void InitGrid()
		{
			#region 조회리스트
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "CUSTOMER_ID",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "CUSTOMER_NAME",
					Caption = "거래처명",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				},
				new XGridColumn()
				{
					FieldName = "CUSTOMER_TYPE",
					HorzAlignment = HorzAlignment.Center,
					Width = 80
				},
				new XGridColumn()
				{
					FieldName = "USE_YN",
					HorzAlignment = HorzAlignment.Center,
					Width = 80,
					RepositoryItem = gridList.GetRepositoryItemCheckEdit()
				}
			);

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "CUSTOMER_ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region 연락처
			gridPhones.Init();
			gridPhones.AddGridColumns(
				new XGridColumn()
				{
					FieldName = "ROW_NO",
					HorzAlignment = HorzAlignment.Center,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "REG_ID",
					HorzAlignment = HorzAlignment.Center,
					Visible = false,
					Width = 40
				},
				new XGridColumn()
				{
					FieldName = "CUSTOMER_ID",
					HorzAlignment = HorzAlignment.Center,
					Visible = false,
					Width = 50
				},
				new XGridColumn()
				{
					FieldName = "PHONE_TYPE",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "PHONE_NUMBER",
					HorzAlignment = HorzAlignment.Near,
					Width = 120
				},
				new XGridColumn()
				{
					FieldName = "REMARKS",
					HorzAlignment = HorzAlignment.Near,
					Width = 200
				},
				new XGridColumn()
				{
					FieldName = "INS_TIME",
					HorzAlignment = HorzAlignment.Center,
					Width = 150
				},
				new XGridColumn()
				{
					FieldName = "INS_USER_NAME",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				},
				new XGridColumn()
				{
					FieldName = "UPD_TIME",
					HorzAlignment = HorzAlignment.Center,
					Width = 150
				},
				new XGridColumn()
				{
					FieldName = "UPD_USER_NAME",
					HorzAlignment = HorzAlignment.Center,
					Width = 100
				});

			gridPhones.SetRepositoryItemLookUpEdit("PHONE_TYPE", "CODE", "LIST_NAME", "CodeHelp", "GetCodeHelpLookup", null, new DataMap() { { "PARENT_CODE", "PHONE_TYPE" } });
			gridPhones.SetEditable("PHONE_NUMBER", "PHONE_TYPE", "REMARKS");

			gridPhones.SetColumnBackColor(Color.Black, "ROW_NO");
			gridPhones.SetColumnForeColor(Color.Yellow, "ROW_NO");
			gridPhones.ColumnFix("ROW_NO");
			#endregion

			#region 주소록
			gridAddress.Init();
			gridAddress.AddGridColumns(
				new XGridColumn() { FieldName = "ROW_NO" },
				new XGridColumn() { FieldName = "REG_ID", HorzAlignment = HorzAlignment.Center, Visible = false, Width = 40 },
				new XGridColumn() { FieldName = "CUSTOMER_ID", HorzAlignment = HorzAlignment.Center, Visible = false, Width = 50 },
				new XGridColumn() { FieldName = "ADDRESS_TYPE", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "ADDRESS_ID", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "POST_NO", Width = 120 },
				new XGridColumn() { FieldName = "ZONE_NO", Width = 80 },
				new XGridColumn() { FieldName = "ADDRESS1", Width = 200 },
				new XGridColumn() { FieldName = "ADDRESS2", Width = 200 },
				new XGridColumn() { FieldName = "REMARKS", Width = 200 },
				new XGridColumn() { FieldName = "INS_TIME" },
				new XGridColumn() { FieldName = "INS_USER_NAME" },
				new XGridColumn() { FieldName = "UPD_TIME" },
				new XGridColumn() { FieldName = "UPD_USER_NAME" }
				);

			gridAddress.SetRepositoryItemLookUpEdit("ADDRESS_TYPE", "CODE", "LIST_NAME", "CodeHelp", "GetCodeHelpLookup", null, new DataMap() { { "PARENT_CODE", "ADDRESS_TYPE" } });
			gridAddress.SetRepositoryItemButtonEdit("POST_NO");
			(gridAddress.MainView.Columns["POST_NO"].ColumnEdit as RepositoryItemButtonEdit).TextEditStyle = TextEditStyles.DisableTextEditor;
			(gridAddress.MainView.Columns["POST_NO"].ColumnEdit as RepositoryItemButtonEdit).Buttons.Add(new EditorButton() { Caption = "삭제", Kind = ButtonPredefines.Delete });
			(gridAddress.MainView.Columns["POST_NO"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if(e.Button.Kind== ButtonPredefines.Ellipsis)
				{
					var postdata = SearchPostCode.Find();
					if (postdata != null && postdata.GetType() == typeof(DataMap))
					{
						gridAddress.SetValue(gridAddress.FocusedRowHandle, "POST_NO", postdata.GetValue("POST_NO"));
						gridAddress.SetValue(gridAddress.FocusedRowHandle, "ZONE_NO", postdata.GetValue("ZONE_NO"));
						gridAddress.SetValue(gridAddress.FocusedRowHandle, "ADDRESS1", postdata.GetValue("ADDRESS1"));
						gridAddress.SetValue(gridAddress.FocusedRowHandle, "ADDRESS2", postdata.GetValue("ADDRESS2"));
						gridAddress.SetFocus(gridAddress.FocusedRowHandle, "ADDRESS2");
					}
				}
				else if(e.Button.Kind== ButtonPredefines.Delete)
				{
					gridAddress.SetValue(gridAddress.FocusedRowHandle, "POST_NO", null);
					gridAddress.SetValue(gridAddress.FocusedRowHandle, "ZONE_NO", null);
					gridAddress.SetValue(gridAddress.FocusedRowHandle, "ADDRESS1", null);
					gridAddress.SetValue(gridAddress.FocusedRowHandle, "ADDRESS2", null);
				}
			};

			gridAddress.SetEditable("ADDRESS_TYPE", "POST_NO", "ADDRESS2", "REMARKS");

			gridAddress.SetColumnBackColor(Color.Black, "ROW_NO");
			gridAddress.SetColumnForeColor(Color.Yellow, "ROW_NO");
			gridAddress.ColumnFix("ROW_NO");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			try
			{
				txtCustomerId.Clear();
				txtCustomerName.Clear();
				txtEmail.Clear();
				txtHpage.Clear();
				chkUseYn.Checked = true;
				memRemarks.Clear();

				txtBizRegNo.Clear();
				txtRepName.Clear();
				txtBizName.Clear();
				txtBizType.Clear();
				txtBizItem.Clear();

				txtPostNo.Clear();
				txtZoneNo.Clear();
				txtAddress1.Clear();
				txtAddress2.Clear();

				txtInsTime.Clear();
				txtInsUserName.Clear();
				txtUpdTime.Clear();
				txtUpdUserName.Clear();

				mBizRegId = null;
				mAddressId = null;

				gridPhones.DataSource = null;
				gridPhones.EmptyDataTableBinding();

				gridAddress.DataSource = null;
				gridAddress.EmptyDataTableBinding();

				btnAddressSave.Enabled =
					btnPhoneSave.Enabled = false;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
				this.EditMode = EditModeEnum.New;
				txtCustomerName.Focus();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				gridList.BindData("Base", "GetList", "SelectCustomers", new DataMap() { { "FIND_TEXT", txtFindText.EditValue } });

				if (param != null)
					DetailDataLoad(param);
				else
					DataInit();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var res = DBTranHelper.GetData("Customer", new DataMap() { { "CUSTOMER_ID", id } });

				if (res == null)
					throw new Exception("처리결과를 수신하지 못했습니다.");

				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				if (res.TranList == null || res.TranList.Length == 0)
					throw new Exception("처리결과 데이터가 없습니다.");

				if (res.TranList.Length > 0)
				{
					if (res.TranList[0].Data == null)
						throw new Exception("조회할 데이터가 없습니다.");

					DataMap data = res.TranList[0].Data as DataMap;

					txtCustomerId.EditValue = data.GetValue("CUSTOMER_ID");
					txtCustomerName.EditValue = data.GetValue("CUSTOMER_NAME");
					lupCustomerType.EditValue = data.GetValue("CUSTOMER_TYPE");
					txtEmail.EditValue = data.GetValue("EMAIL");
					txtHpage.EditValue = data.GetValue("HPAGE");
					chkUseYn.EditValue = data.GetValue("USE_YN");
					memRemarks.EditValue = data.GetValue("REMARKS");

					mBizRegId = data.GetValue("BIZ_REG_ID");
					txtBizRegNo.EditValue = data.GetValue("BIZ_REG_NO");
					txtBizName.EditValue = data.GetValue("BIZ_NAME");
					txtRepName.EditValue = data.GetValue("REP_NAME");
					txtBizType.EditValue = data.GetValue("BIZ_TYPE");
					txtBizItem.EditValue = data.GetValue("BIZ_ITEM");

					mAddressId = data.GetValue("ADDRESS_ID");
					txtPostNo.EditValue = data.GetValue("POST_NO");
					txtZoneNo.EditValue = data.GetValue("ZONE_NO");
					txtAddress1.EditValue = data.GetValue("ADDRESS1");
					txtAddress2.EditValue = data.GetValue("ADDRESS2");

					txtInsTime.EditValue = data.GetValue("INS_TIME");
					txtInsUserName.EditValue = data.GetValue("INS_USER_NAME");
					txtUpdTime.EditValue = data.GetValue("UPD_TIME");
					txtUpdUserName.EditValue = data.GetValue("UPD_USER_NAME");
				}

				if (res.TranList.Length > 1)
					gridPhones.DataSource = (res.TranList[1].Data as List<DataMap>).DataMapListToDataTable();

				if (res.TranList.Length > 2)
					gridAddress.DataSource = (res.TranList[2].Data as List<DataMap>).DataMapListToDataTable();

				btnAddressSave.Enabled =
					btnPhoneSave.Enabled = true;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtCustomerName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				DataTable dt = lc.GroupToDataTable(lcGroupEdit, lcGroupBizEdit)
					.SetValue("BIZ_REG_ID", mBizRegId)
					.SetValue("ADDRESS_ID", mAddressId)
					.SetValue("ROWSTATE", (this.EditMode == EditModeEnum.New) ? "INSERT" : "UPDATE");

				var res = DBTranHelper.Execute(new DBTranSet()
				{
					ServiceId = "Customer",
					ProcessId = "Save",
					TranList = new DBTranData[]
					{
						new DBTranData() { Data = dt },
						new DBTranData() { Data = GetPhoneData() },
						new DBTranData() { Data = GetAddressData() }
					}
				});
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				txtCustomerId.EditValue = res.TranList[0].ReturnValue;

				DataSavePhones();
				DataSaveAddress();

				ShowMsgBox("저장하였습니다.");
				callback(arg, res.TranList[0].ReturnValue);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				DataMap data = new DataMap()
				{
					{ "CUSTOMER_ID", txtCustomerId.EditValue },
					{ "ROWSTATE", "DELETE" }
				};

				var res = DBTranHelper.Execute("Base", "Save", "Customer", data, "CUSTOMER_ID");
				if (res.ErrorNumber != 0)
					throw new Exception(res.ErrorMessage);

				ShowMsgBox("삭제하였습니다.");
				callback(arg, null);

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private DataTable GetPhoneData()
		{
			try
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("REG_ID", typeof(int)),
					new DataColumn("CUSTOMER_ID", typeof(int)),
					new DataColumn("PHONE_NUMBER", typeof(string)),
					new DataColumn("PHONE_TYPE", typeof(string)),
					new DataColumn("REMARKS", typeof(string)),
					new DataColumn("ROWSTATE", typeof(string))
				});

				if (gridPhones.MainView.RowCount > 0)
				{
					gridPhones.PostEditor();
					gridPhones.UpdateCurrentRow();

					foreach (DataRow row in gridPhones.GetDataTable().GetChangedData().Rows)
					{
						dt.Rows.Add(
							row["REG_ID"],
							txtCustomerId.EditValue,
							row["PHONE_NUMBER"],
							row["PHONE_TYPE"],
							row["REMARKS"],
							row["ROWSTATE"]
							);
					}
				}

				return dt;
			}
			catch
			{
				throw;
			}
		}
		private DataTable GetAddressData()
		{
			try
			{
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("REG_ID", typeof(int)),
					new DataColumn("CUSTOMER_ID", typeof(int)),
					new DataColumn("ADDRESS_ID", typeof(int)),
					new DataColumn("ADDRESS_TYPE", typeof(string)),
					new DataColumn("POST_NO", typeof(string)),
					new DataColumn("ZONE_NO", typeof(string)),
					new DataColumn("ADDRESS1", typeof(string)),
					new DataColumn("ADDRESS2", typeof(string)),
					new DataColumn("REMARKS", typeof(string)),
					new DataColumn("ROWSTATE", typeof(string))
				});

				if (gridAddress.MainView.RowCount > 0)
				{
					gridAddress.PostEditor();
					gridAddress.UpdateCurrentRow();

					foreach (DataRow row in gridAddress.GetDataTable().GetChangedData().Rows)
					{
						dt.Rows.Add(
							row.GetValue("REG_ID"),
							txtCustomerId.EditValue,
							row.GetValue("ADDRESS_ID"),
							row.GetValue("ADDRESS_TYPE"),
							row.GetValue("POST_NO"),
							row.GetValue("ZONE_NO"),
							row.GetValue("ADDRESS1"),
							row.GetValue("ADDRESS2"),
							row.GetValue("REMARKS"),
							row.GetValue("ROWSTATE")
							);
					}
				}

				return dt;
			}
			catch
			{
				throw;
			}
		}

		void DataLoadPhones()
		{
			try
			{
				gridPhones.BindData("Base", "GetList", "SelectCustomerPhones", new DataMap() { { "CUSTOMER_ID", txtCustomerId.EditValue } });
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DataSavePhones(bool reload = false)
		{
			try
			{
				DataTable dt = GetPhoneData();
				if (dt == null || dt.Rows.Count == 0)
				{
					if (reload)
						throw new Exception("저장할 건이 없습니다.");
				}
				else
				{
					var res = DBTranHelper.Execute("Base", "Save", "CustomerPhones", dt, null);
					if (res.ErrorNumber != 0)
						throw new Exception(res.ErrorMessage);

					if (reload)
					{
						ShowMsgBox("저장하였습니다.");
						DataLoadPhones();
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void DataLoadAddress()
		{
			try
			{
				gridAddress.BindData("Base", "GetList", "SelectCustomerAddress", new DataMap() { { "CUSTOMER_ID", txtCustomerId.EditValue } });
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DataSaveAddress(bool reload = false)
		{
			try
			{
				DataTable dt = GetAddressData();

				if (dt == null || dt.Rows.Count == 0)
				{
					if (reload)
						throw new Exception("저장할 건이 없습니다.");
				}
				else
				{
					var res = DBTranHelper.Execute("Customer", "SaveCustomerAddress", "CustomerAddress", dt, null);
					if (res.ErrorNumber != 0)
						throw new Exception(res.ErrorMessage);

					if (reload)
					{
						ShowMsgBox("저장하였습니다.");
						DataLoadAddress();
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using JW.AUBE.Base.Map;

namespace JW.AUBE.Base.Utils
{
	public static class DataTableUtils
	{
		public static object GetValue(this DataRow row, string columnName)
		{
			if (row.Table.Columns.Contains(columnName))
			{
				return row[columnName];
			}
			else
			{
				return null;
			}
		}

		public static DataTable SetValue(this DataTable dt, string columnName, object value)
		{
			if (dt == null)
				return null;

			if (dt.Columns.Contains(columnName) == false)
				dt.Columns.Add(columnName, value.GetType());

			foreach (DataRow dr in dt.Rows)
				dr[columnName] = value;

			return dt;
		}

		public static DataTable InputData(this DataTable dt, string columnName, object data)
		{
			if (!dt.Columns.Contains(columnName))
			{
				dt.Columns.Add(columnName);
			}
			foreach (DataRow row in dt.Rows)
			{
				row[columnName] = data;
			}

			return dt;
		}

		public static DataTable InputData(this DataTable dt, Dictionary<string, object> data)
		{
			foreach (var item in data)
			{
				dt.InputData(item.Key, item.Value);
			}
			return dt;
		}

		public static DataTable AddRow(this DataTable dt)
		{
			dt.Rows.Add(dt.NewRow());
			return dt;
		}

		public static DataMap ToDataMap(this DataTable dt)
		{
			if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0)
				return null;

			var param = new DataMap();
			foreach (DataColumn column in dt.Columns)
				param.Add(column.ColumnName, dt.Rows[0][column.ColumnName]);
			return param;
		}

		public static DataMap ToDataMap(this DataRow dr)
		{
			if (dr == null || dr.Table.Columns.Count == 0)
				return null;

			var param = new DataMap();
			foreach (DataColumn column in dr.Table.Columns)
				param.Add(column.ColumnName, dr[column.ColumnName]);

			return param;
		}

		public static IList<DataMap> ToDataMapList(this DataTable dt)
		{
			return ConvertUtils.DataTableToDataMapList(dt);
		}

		public static DataTable ChangeColumnName(this DataTable dt, string fromColumnName, string toColumnName)
		{
			if (!dt.Columns.Contains(toColumnName))
			{
				dt.Columns.Add(toColumnName, dt.Columns[fromColumnName].DataType);
			}

			foreach (DataRow row in dt.Rows)
			{
				row[toColumnName] = row[fromColumnName];
			}

			return dt;
		}

		public static DataTable GetDataByRowState(this DataTable dt, DataRowState state)
		{
			if (state == DataRowState.Deleted)
			{
				var dtNew = dt.Clone();

				foreach (DataRow row in dt.AsEnumerable().Where(row => row.RowState == state).ToList())
				{
					var newRow = dtNew.NewRow();

					foreach (DataColumn column in dt.Columns)
					{
						newRow[column.ColumnName] = row[column.ColumnName, DataRowVersion.Original];
					}

					dtNew.Rows.Add(newRow);
				}

				return dtNew;
			}
			else
			{
				if (dt.AsEnumerable().Where(row => row.RowState == state).Any())
				{
					return dt.AsEnumerable().Where(row => row.RowState == state).CopyToDataTable();
				}
				else
				{
					return null;
				}
			}
		}

		public static DataTable GetChangedData(this DataTable dt)
		{
			if (dt == null)
			{
				return dt;
			}
			if (dt.Columns.Contains("ROWSTATE"))
			{
				return dt;
			}
			var dtNew = dt.Clone();
			dtNew.Columns.Add("ROWSTATE");

			if (dt.Rows.Count > 0)
			{
				foreach (DataRow row in dt.AsEnumerable().Where(row =>
											row.RowState == DataRowState.Added ||
											row.RowState == DataRowState.Modified ||
											row.RowState == DataRowState.Deleted))
				{
					if (row.RowState == DataRowState.Deleted)
					{
						var newRow = dtNew.NewRow();
						foreach (DataColumn column in dt.Columns)
						{
							newRow[column.ColumnName] = row[column.ColumnName, DataRowVersion.Original];
						}
						newRow["ROWSTATE"] = "DELETE";
						dtNew.Rows.Add(newRow);
					}
					else
					{
						var newRow = dtNew.NewRow();
						newRow.ItemArray = row.ItemArray;
						newRow["ROWSTATE"] = (row.RowState == DataRowState.Modified) ? "UPDATE" : "INSERT";
						dtNew.Rows.Add(newRow);
					}
				}
			}

			return dtNew;
		}

		public static DataTable GetDataByColumns(this DataTable dt, List<string> columns)
		{
			if (dt == null)
			{
				return null;
			}
			if (dt.Columns.Count == 0)
			{
				return dt;
			}
			var cols = dt.Columns.OfType<DataColumn>().Where(x => !columns.Contains(x.ColumnName)).ToList();
			foreach (DataColumn col in cols)
			{
				dt.Columns.Remove(col);
			}

			return dt;
		}

		public static DataTable GetDataByChecked(this DataTable dt, string columnName = null)
		{
			if (dt == null)
			{
				return null;
			}
			if (dt.Rows.Count == 0)
			{
				return dt;
			}
			if (string.IsNullOrEmpty(columnName))
			{
				columnName = "SelYn";
			}
			var dtNew = dt.Clone();

			foreach (DataRow row in dt.AsEnumerable().Where(row => row.Field<string>(columnName).Equals("Y")).ToList())
			{
				var newRow = dtNew.NewRow();
				newRow.ItemArray = row.ItemArray;
				dtNew.Rows.Add(newRow);
			}
			return dtNew;
		}

		public static DataTable ChangeColumnType(this DataTable dt, List<KeyValuePair<string, Type>> columns)
		{
			if (dt == null)
			{
				return null;
			}
			if (dt.Columns.Count == 0)
			{
				return dt;
			}
			try
			{
				var dtNew = dt.Clone();

				foreach (var item in columns)
				{
					dtNew.Columns[item.Key].DataType = item.Value;
				}

				foreach (DataRow row in dt.Rows)
				{
					dtNew.ImportRow(row);
				}

				return dtNew;
			}
			catch
			{
				return dt;
			}
		}

		public static DataTable ChangeDateToString(this DataTable dt, string format = "yyyyMMdd")
		{
			if (dt == null)
			{
				return null;
			}
			if (dt.Columns.Count == 0)
			{
				return dt;
			}
			if (string.IsNullOrEmpty(format))
			{
				format = "yyyyMMdd";
			}
			try
			{
				var list = new List<KeyValuePair<string, Type>>();
				foreach (DataColumn col in dt.Columns)
				{
					if (col.DataType == typeof(DateTime))
					{
						list.Add(new KeyValuePair<string, Type>(col.ColumnName, typeof(String)));
					}
				}


				var dtNew = dt.ChangeColumnType(list);

				foreach (var item in list)
				{
					foreach (DataRow row in dtNew.Rows)
					{
						if (row[item.Key] != DBNull.Value && row[item.Key] != null)
						{
							row[item.Key] = Convert.ToDateTime(row[item.Key]).ToString(format);
						}
					}
				}

				return dtNew;
			}
			catch
			{
				throw;
			}
		}

		public static DataTable ChangeValue(this DataTable dt, bool isDateToString8 = false)
		{
			if (dt == null)
			{
				return null;
			}
			if (dt.Rows.Count == 0)
			{
				return dt;
			}
			foreach (DataRow row in dt.Rows)
			{
				if (isDateToString8)
				{
					row.ItemArray.Where(cellValue => cellValue.GetType() == typeof(DateTime)).ToList().ForEach(delegate (object obj)
					{
						obj = DateTime.Parse(obj.ToString()).ToShortDateString();
					});
				}
			}
			return dt;
		}

		public static DataTable CopyByColumnMapping(this DataTable dt, DataTable inputDataTable, Dictionary<string, string> columnMapping = null, Dictionary<string, string> expresstion = null)
		{
			foreach (DataRow row in inputDataTable.Rows)
			{
				var newRow = dt.NewRow();

				foreach (DataColumn col in inputDataTable.Columns)
				{
					if (dt.Columns.Contains(col.ColumnName))
					{
						newRow[col.ColumnName] = row[col];
					}
				}

				if (columnMapping != null)
				{
					foreach (KeyValuePair<string, string> kv in columnMapping)
					{
						if (dt.Columns.Contains(kv.Value) && inputDataTable.Columns.Contains(kv.Key))
						{
							newRow[kv.Value] = row[kv.Key];
						}
					}
				}

				dt.Rows.Add(newRow);
			}

			if (expresstion != null)
			{
				foreach (KeyValuePair<string, string> kv in expresstion)
				{
					if (dt.Columns.Contains(kv.Key))
					{
						dt.Columns.Remove(kv.Key);
					}

					dt.Columns.Add(kv.Key, typeof(object), kv.Value);
				}
			}

			return dt;
		}

		public static DataTable ToDataTable(this Dictionary<string, object> dic)
		{
			if (dic == null)
			{
				return null;
			}
			if (dic.Count == 0)
			{
				return null;
			}
			string colname = string.Empty;
			var dt = new DataTable();
			foreach (KeyValuePair<string, object> kv in dic)
			{
				colname = kv.Key.ToUpperUnderscoreByPattern();
				if (kv.Value == null || kv.Value == DBNull.Value)
				{
					dt.Columns.Add(colname, typeof(string));
				}
				else
				{
					dt.Columns.Add(colname, kv.Value.GetType());
				}
			}
			var newRow = dt.NewRow();
			foreach (KeyValuePair<string, object> kv in dic)
			{
				colname = kv.Key.ToUpperUnderscoreByPattern();
				newRow[colname] = (kv.Value == null) ? DBNull.Value : kv.Value;
			}
			dt.Rows.Add(newRow);
			return dt;
		}

		public static bool IsEqual(DataTable dt1, DataTable dt2)
		{
			if (dt1 == null || dt2 == null)
			{
				return false;
			}
			if (dt1.Rows.Count != dt2.Rows.Count || dt1.Columns.Count != dt2.Columns.Count)
			{
				return false;
			}
			for (var col = 0; col < dt1.Columns.Count; col++)
			{
				if (!Equals(dt1.Columns[col].ColumnName, dt2.Columns[col].ColumnName))
				{
					return false;
				}
			}


			for (var row = 0; row < dt1.Rows.Count; row++)
			{
				for (var col = 0; col < dt1.Columns.Count; col++)
				{
					if (!Equals(dt1.Rows[row][col], dt2.Rows[row][col]))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static DataTable DeleteExcelHeader(this DataTable dt)
		{
			if (dt == null)
			{
				return null;
			}
			if (dt.Columns.Count == 0)
			{
				return dt;
			}
			if (dt.Rows.Count == 0)
			{
				return dt;
			}
			foreach (DataColumn col in dt.Columns)
			{
				col.ColumnName = dt.Rows[0][col].ToString();
			}


			dt.Rows[0].Delete();
			dt.AcceptChanges();


			dt.Rows[0].Delete();
			dt.AcceptChanges();

			return dt;
		}
	}
}

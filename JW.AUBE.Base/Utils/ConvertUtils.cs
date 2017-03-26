using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using JW.AUBE.Base.Map;
using Newtonsoft.Json;

namespace JW.AUBE.Base.Utils
{
	public static class ConvertUtils
	{
		/// <summary>
		/// List<T> 데이터를 DataTable로 변환
		/// </T>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		/// </summary>
		public static DataTable ListToDataTable<T>(this IList<T> list, string tableName = null)
		{
			var table = CreateTable<T>(tableName);
			var entityType = typeof(T);
			var properties = TypeDescriptor.GetProperties(entityType);

			foreach (T item in list)
			{
				var row = table.NewRow();

				foreach (PropertyDescriptor prop in properties)
				{
					var value = prop.GetValue(item);
					row[prop.Name] = value ?? DBNull.Value;
				}
				table.Rows.Add(row);
			}
			table.AcceptChanges();
			return table;
		}

		/// <summary>
		/// List<DataRow>데이터를 List<T>로 변환
		/// </T>
		/// <typeparam name="T"></typeparam>
		/// <param name="rows"></param>
		/// <returns></returns>
		/// </DataRow></summary>
		public static IList<T> ListToList<T>(IList<DataRow> rows)
		{
			IList<T> list = null;

			if (rows != null)
			{
				list = new List<T>();

				foreach (DataRow row in rows)
				{
					var item = CreateItem<T>(row);
					list.Add(item);
				}
			}

			return list;
		}

		/// <summary>
		/// DataTable 데이터를 List<T>형식으로 변환
		/// </T>
		/// <typeparam name="T"></typeparam>
		/// <param name="table"></param>
		/// <returns></returns>
		/// </summary>
		public static IList<T> DataTableToList<T>(DataTable table)
		{
			if (table == null)
			{
				return null;
			}

			var rows = new List<DataRow>();

			foreach (DataRow row in table.Rows)
			{
				rows.Add(row);
			}

			return ListToList<T>(rows);
		}


		/// <summary>
		/// DataRow 데이터를 T형식으로 변환하여 반환한다.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="row"></param>
		/// <returns></returns>
		public static T CreateItem<T>(DataRow row)
		{
			var obj = default(T);
			if (row != null)
			{
				obj = Activator.CreateInstance<T>();

				foreach (DataColumn column in row.Table.Columns)
				{
					var prop = obj.GetType().GetProperty(column.ColumnName);
					try
					{
						var value = row[column.ColumnName];
						if (value == DBNull.Value)
						{
							value = null;
						}
						prop.SetValue(obj, value, null);
					}
					catch
					{
						throw;
					}
				}
			}

			return obj;
		}

		/// <summary>
		/// T형식의 데이터를 DataTable을 생성한다.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static DataTable CreateTable<T>(string tableName = null)
		{
			var entityType = typeof(T);
			if (string.IsNullOrEmpty(tableName))
				tableName = entityType.Name;

			var table = new DataTable(tableName);
			var properties = TypeDescriptor.GetProperties(entityType);

			foreach (PropertyDescriptor prop in properties)
			{
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			}

			return table;
		}

		/// <summary>
		/// Array 변수를 받아서 T형식 배열로 반환한다.
		/// </summary>
		/// <typeparam name="T">반환할 클래스 객체의 형식</typeparam>
		/// <param name="arr">배열변수</param>
		/// <returns>T의 배열</returns>
		public static T[] ArrayToArry<T>(Array arr)
		{
			var ret = new T[arr.Length];
			var tc = TypeDescriptor.GetConverter(typeof(T));
			if (tc.CanConvertFrom(arr.GetValue(0).GetType()))
			{
				for (var i = 0; i < arr.Length; i++)
				{
					ret[i] = (T)tc.ConvertFrom(arr.GetValue(i));
				}
			}
			else
			{
				tc = TypeDescriptor.GetConverter(arr.GetValue(0).GetType());
				if (tc.CanConvertTo(typeof(T)))
				{
					for (var i = 0; i < arr.Length; i++)
					{
						ret[i] = (T)tc.ConvertTo(arr.GetValue(i), typeof(T));
					}
				}
				else
				{
					throw new NotSupportedException();
				}
			}
			return ret;
		}

		/// <summary>
		/// 데이터테이블 파라미터를 받아서 List<DataMap>형식으로 변환하여 반환
		/// </DataMap>
		/// <param name="data">변환대상 DataTable</param>
		/// <returns>반환할 List<DataMap> 객체</DataMap>
		/// </returns></summary>
		public static IList<DataMap> DataTableToDataMapList(this DataTable data)
		{
			if (data == null)
			{
				return null;
			}
			var list = new List<DataMap>();
			foreach (DataRow dr in data.Rows)
			{
				var param = new DataMap();
				foreach (DataColumn col in data.Columns)
				{
					var value = dr[col.ColumnName];
					if (value == DBNull.Value)
					{
						value = null;
					}
					param.Add(col.ColumnName, dr[col.ColumnName]);
				}
				list.Add(param);
			}
			return list;
		}

		/// <summary>
		/// List<DataMap>객체와 테이블명을 전달받아서 DataTable로 반환함
		/// </DataMap>
		/// <param name="list">변환대상 List<DataMap>객체</DataMap>
		/// <param name="tableName">데이터테이블명</param>
		/// <returns>변환한 데이터테이블</returns>
		/// </param></summary>
		public static DataTable DataMapListToDataTable(this IList<DataMap> list, string tableName)
		{
			if (list == null || list.Count == 0)
			{
				return null;
			}
			var data = new DataTable();

			foreach (var key in list[0].Keys)
			{
				if (key.EndsWith("_QTY") || key.EndsWith("_AMT") || key.EndsWith("_RAT"))
					data.Columns.Add(key, typeof(decimal));
				else
					data.Columns.Add(key);
			}
			foreach (DataMap p in list)
			{
				var dr = data.NewRow();
				foreach (var col in p)
				{
					dr[col.Key] = col.Value ?? DBNull.Value;
				}
				data.Rows.Add(dr);
			}

			if (!string.IsNullOrEmpty(tableName))
			{
				data.TableName = tableName;
			}
			if (data != null)
				data.AcceptChanges();
			return data;
		}

		public static T JsonToAnyType<T>(object obj)
		{
			if (obj == null)
			{
				return default(T);
			}
			else
			{
				return JsonConvert.DeserializeObject<T>(obj.ToString());
			}
		}
	}
}

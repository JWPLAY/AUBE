using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;
using JW.AUBE.Base.Constants;

namespace JW.AUBE.Base.Utils
{
	public class FileUtils
	{
		public static string GetExportFilePath()
		{
			return string.Format("C:\\{0}\\ExportXls", CommonConsts.APP_PATH);
		}

		public static string GetUniqueFileName(string fileName)
		{
			var fileInfo = new FileInfo(fileName);
			return MakeUniqueFileName(fileInfo.DirectoryName, fileInfo.Name.Replace(fileInfo.Extension, string.Empty), fileInfo.Extension);
		}

		public static string GetUniqueFileName(string path, string fileName)
		{
			var fileInfo = new FileInfo(fileName);
			return MakeUniqueFileName(path, fileInfo.Name.Replace(fileInfo.Extension, string.Empty), fileInfo.Extension);
		}

		private static string MakeUniqueFileName(string path, string name, string ext)
		{
			var sb = new StringBuilder();
			var time = DateTime.Now.ToString("yyyyMMdd-HHmm_");
			var cnt = 0;
			while (true)
			{
				if (!File.Exists(sb.AppendFormat("{0}\\{1}{2}{3}{4}", path, time, name, cnt == 0 ? string.Empty : string.Format("({0})", cnt.ToString()), ext).ToString()))
				{
					return sb.ToString();
				}
				cnt++;
				sb.Clear();
			}
		}

		public static void CheckDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}

		public static string OpenExcelFile(string filter = "")
		{
			if (string.IsNullOrEmpty(filter))
			{
				filter = "Excel files|*.xlsx;*.xls|All files|*.*";
			}
			var ofd = new OpenFileDialog();
			ofd.Filter = filter;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				return ofd.FileName;
			}
			else
			{
				return null;
			}
		}
		public static string SaveExcelFile(string filter = "", string fileName = "")
		{
			if (string.IsNullOrEmpty(filter))
			{
				filter = "Excel(Xlsx) files|*.xlsx|Excel(Xls) files|*.xls|CSV files|*.csv|All files|*.*";
			}
			var sfd = new SaveFileDialog();
			sfd.Filter = filter;
			sfd.FileName = fileName;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				return sfd.FileName;
			}
			else
			{
				return null;
			}
		}
		public static void StartProcess(string fileName)
		{
			try
			{
				if (File.Exists(fileName))
				{
					StartProcess(fileName);
				}
			}
			catch
			{
			}
		}
		public static string GetExcelPath()
		{
			try
			{
				return string.Empty;
			}
			catch
			{
				throw;
			}
		}
		public static void SetExcelPath(string path)
		{
			try
			{
			}
			catch
			{
				throw;
			}
		}

		public static DataTable ReadFile(string path)
		{
			var lineNo = 0;
			var list = new DataTable();
			list.Columns.Add(new DataColumn("NO"));
			list.Columns.Add(new DataColumn("DESCRIPTION"));

			using (var sr = new StreamReader(path))
			{
				while (sr.Peek() >= 0)
				{
					var line = sr.ReadLine();
					lineNo++;
					list.Rows.Add(new object[] { lineNo, line });
				}
			}
			return list;
		}

		public static List<DataTable> ExcelToDataTable(string filePath)
		{
			try
			{
				var list = new List<DataTable>();
				var HDR = false ? "Yes" : "No";
				string strConn;
				if (filePath.Substring(filePath.LastIndexOf(".")).ToLower().Equals(".xlsx"))
				{
					strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR={1};IMEX=0\"", filePath, HDR);
				}
				else
				{
					strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1};IMEX=0\"", filePath, HDR);
				}
				var conn = new OleDbConnection(strConn);
				conn.Open();
				var schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
				foreach (DataRow schemaRow in schemaTable.Rows)
				{
					var sheet = schemaRow["TABLE_NAME"].ToString();
					if (!sheet.EndsWith("_"))
					{
						var dtTemp = new DataTable();
						var query = string.Format("SELECT * FROM {0}", sheet);
						var daExcel = new OleDbDataAdapter(query, conn);
						daExcel.Fill(dtTemp);
						list.Add(dtTemp);
					}
				}
				conn.Close();
				return list;
			}
			catch
			{
				throw;
			}
		}

		public static DataSet ExcelToDataSetleDialog(bool isFirstRowDelete = false)
		{
			try
			{
				var ofd = new OpenFileDialog() { Filter = "Excel files|*.xlsx;*.xls" };
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					return ExcelToDataSet(ofd.FileName, isFirstRowDelete);
				}
				else
				{
					return null;
				}
			}
			catch
			{
				throw;
			}
		}

		public static DataTable ExcelToDataTableDialog(bool isFirstRowDelete = false, int tableIndex = 0)
		{
			try
			{
				var ofd = new OpenFileDialog() { Filter = "Excel files|*.xlsx;*.xls" };
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					return ExcelToDataSet(ofd.FileName, isFirstRowDelete).Tables[tableIndex];
				}
				else
				{
					return null;
				}
			}
			catch
			{
				throw;
			}
		}


		public static DataSet ExcelToDataSet(string fileName, bool isFirstRowDelete = false)
		{
			var result = new DataSet();

			return result;
		}
	}
}

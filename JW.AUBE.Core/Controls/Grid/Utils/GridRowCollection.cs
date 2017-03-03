using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace JW.AUBE.Core.Controls.Grid
{
	public class GridViewRow
	{
		public GridView GridView;
		public int RowHandle;

		public GridViewRow(GridView gridView, int rowHandle)
		{
			GridView = gridView;
			RowHandle = rowHandle;
		}

		public T Field<T>(string fieldName)
		{
			return (T)GridView.GetRowCellValue(RowHandle, fieldName);
		}
		public T Field<T>(GridColumn column)
		{
			return (T)GridView.GetRowCellValue(RowHandle, column);
		}
		public T Field<T>(int index)
		{
			return (T)GridView.GetRowCellValue(RowHandle, GridView.Columns[index]);
		}


		public void SetField(string fieldName, object value)
		{
			GridView.SetRowCellValue(RowHandle, fieldName, value);
		}
		public void SetField(GridColumn column, object value)
		{
			GridView.SetRowCellValue(RowHandle, column, value);
		}
		public void SetField(int index, object value)
		{
			GridView.SetRowCellValue(RowHandle, GridView.Columns[index], value);
		}
	}

	public class EnumerableGridViewRowCollection : IEnumerable<GridViewRow>
	{
		public GridView GridView;
		public EnumerableGridViewRowCollection(GridView gridView)
		{
			GridView = gridView;
		}
		public IEnumerator<GridViewRow> GetEnumerator()
		{
			for (var i = 0; i < GridView.RowCount; i++)
			{
				yield return new GridViewRow(GridView, GridView.GetRowHandle(i));
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public static class GridViewEnumerator
	{
		public static IEnumerable<GridViewRow> AsRowEnumerable(this GridView gridView)
		{
			return new EnumerableGridViewRowCollection(gridView);
		}
	}
}

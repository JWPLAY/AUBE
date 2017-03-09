using System.Windows.Forms;
using JW.AUBE.Base.Map;

namespace JW.AUBE.Core.PostCode
{
	public static class SearchPostCode
	{
		public static DataMap Find()
		{
			using (SearchPostCodeForm form = new SearchPostCodeForm())
			{
				form.Text = "우편번호검색(다음)";
				if (form.ShowDialog() == DialogResult.OK)
				{
					return form.ReturnData;
				}
				else
					return null;
			}
		}
	}
}

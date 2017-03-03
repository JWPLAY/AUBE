using System.Drawing;

namespace JW.AUBE.Core.Controls
{
	public interface IControlExtension
	{
		void Init();
		void Clear();
		void SetEnable(bool bEnable = false, Color? backColor = null);
		void SetForeColor(Color color);
	}
}

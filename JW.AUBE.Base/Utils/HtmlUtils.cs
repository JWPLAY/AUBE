using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace JW.AUBE.Base.Utils
{
	public static class HtmlUtils
	{
		public static string GetCookieAll(string url)
		{
			var cookies = new CookieContainer();
			var handler = new HttpClientHandler() { CookieContainer = cookies };

			var client = new HttpClient(handler);

			var sb = new StringBuilder();
			var uri = new Uri(url);
			var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
			foreach (Cookie cookie in responseCookies)
			{
				sb.AppendFormat("{0}: {1}", cookie.Name, cookie.Value);
			}
			return sb.ToString();
		}
	}
}

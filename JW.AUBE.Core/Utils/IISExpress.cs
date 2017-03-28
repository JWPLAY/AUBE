using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace JW.AUBE.Core.Utils
{
	public static class IISExpress
	{
		private static readonly List<string> sites = new List<string>();
		private static readonly List<string> paths = new List<string>();

		public static void Start(string site, int port = 7329)
		{
			if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe") == false)
				return;

			if (!sites.Contains(site.ToLower()))
				sites.Add(site.ToLower());
			else return;

			var index = Environment.CurrentDirectory.LastIndexOf("\\bin\\");
			var projectDir = Environment.CurrentDirectory.Remove(index);
			var solutionDir = System.IO.Directory.GetParent(projectDir);
			var path = string.Format("{0}\\{1}", solutionDir, site);
			var arguments = new StringBuilder();
			arguments.Append(@"/path:");
			arguments.Append(path);
			arguments.Append(@" /Port:" + port);

			var process = Process.Start(new ProcessStartInfo()
			{
				FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
				Arguments = arguments.ToString(),
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			});
			Thread.Sleep(10000);
		}

		public static void StartIISExpressFromPath(string path, int port = 7329)
		{
			if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe") == false)
				return;

			if (!paths.Contains(path.ToLower()))
				paths.Add(path.ToLower());
			else return;

			var arguments = new StringBuilder();
			arguments.Append(@"/path:" + path);
			arguments.Append(@" /Port:" + port);
			var process = Process.Start(new ProcessStartInfo()
			{
				FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
				Arguments = arguments.ToString(),
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			});
			Thread.Sleep(10000);
		}
	}
}

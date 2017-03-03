using System.Diagnostics;
using System.Linq;
using JW.AUBE.Base.Constants;
using log4net;

namespace JW.AUBE.Base.Logging
{
	public static class Logger
	{
		private static readonly ILog _log;

		static Logger()
		{
			if (LogManager.GetCurrentLoggers().Count() == 0)
			{
				Init();
			}
			_log = LogManager.GetLogger(string.Empty);
		}

		private static void Init()
		{
			var hierarchy = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
			hierarchy.Configured = true;

			var rollingAppender = new log4net.Appender.RollingFileAppender()
			{
				File = LogConsts.FILE_PATH + @"\Log\log.log",
				AppendToFile = true,
				RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Date,
				LockingModel = new log4net.Appender.FileAppender.MinimalLock(),
				DatePattern = "_yyyyMMdd\".log\""
			};
			var layout = new log4net.Layout.PatternLayout("%date [%property{buildversion}] %-5level %logger - %message%newline");
			rollingAppender.Layout = layout;

			hierarchy.Root.AddAppender(rollingAppender);
			rollingAppender.ActivateOptions();

			hierarchy.Root.Level = log4net.Core.Level.All;
		}

		public static void Error(string format, params object[] args)
		{
			_log.Error(string.Format(format, args));
		}

		public static void Error(string msg)
		{
			_log.Error(msg);
		}

		public static void Debug(string format, params object[] args)
		{
			var __log = LogManager.GetLogger(GetMethodName());
			if (__log.IsDebugEnabled)
			{
				__log.Debug(string.Format(format, args));
			}
		}

		public static void Info(string format, params object[] args)
		{
			LogManager.GetLogger(GetMethodName()).Info(string.Format(format, args));
		}

		public static void Fatal(string format, params object[] args)
		{
			_log.Fatal(string.Format(format, args));
		}

		private static string GetMethodName()
		{
			var method = (new StackTrace()).GetFrame(2).GetMethod();
			var methodName = method.Name;
			var className = method.ReflectedType.FullName;

			return string.Format("{0}.{1}", className, methodName);
		}
	}
}

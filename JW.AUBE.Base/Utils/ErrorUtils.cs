using System;
using System.Text;
using JW.AUBE.Base.Logging;
using JW.AUBE.Base.Models;

namespace JW.AUBE.Base.Utils
{
	public static class ErrorUtils
	{
		public static void RaiseException(Exception ex)
		{
			var message = GetMessage(ex);
			Logger.Error(message);
			throw new Exception(message);
		}

		public static Exception GetException(Exception ex)
		{
			var message = GetMessage(ex);
			Logger.Error(message);
			return new Exception(message);
		}

		public static string GetMessage(Exception ex)
		{
			var startIndex = 0;
			var exceptionMessage = new StringBuilder();
			exceptionMessage.Append("아래와 같은 사유로 오류가 발생하였습니다.");
			do
			{
				if (!string.IsNullOrEmpty(ex.Message) || !string.IsNullOrEmpty(ex.Source) || !string.IsNullOrEmpty(ex.StackTrace))
				{
					if (startIndex == 0)
					{
						exceptionMessage.Append("\r\n========================================");
					}
					else
					{
						exceptionMessage.Append("\r\n<<<계속>>>");
					}
					startIndex++;
				}
				if (!string.IsNullOrEmpty(ex.Message))
				{
					exceptionMessage.Append(string.Format("{0}{1}", Environment.NewLine, ex.Message));
				}
				if (!string.IsNullOrEmpty(ex.Source))
				{
					exceptionMessage.Append(string.Format("{0}{0}Source : {1}", Environment.NewLine, ex.Source));
				}
				if (!string.IsNullOrEmpty(ex.StackTrace))
				{
					exceptionMessage.Append(string.Format("{0}{0}Stack Trace {0}{1}", Environment.NewLine, ex.StackTrace));
				}
				ex = ex.InnerException;
			}
			while (ex != null);
			exceptionMessage.Append("\r\n========================================");
			return exceptionMessage.ToString();
		}

		public static ErrorMessage GetMessageAndTrace(Exception ex)
		{
			var exceptionMessage = new StringBuilder();
			var exceptionStackTrace = new StringBuilder();

			do
			{
				if (!string.IsNullOrEmpty(ex.Message))
				{
					exceptionMessage.Append(string.Format("{0}{1}", ex.Message, Environment.NewLine));
				}
				if (!string.IsNullOrEmpty(ex.Source))
				{
					exceptionStackTrace.Append(string.Format("Source : {0}{1}", ex.Source, Environment.NewLine));
				}
				if (!string.IsNullOrEmpty(ex.StackTrace))
				{
					exceptionStackTrace.Append(string.Format("Stack Trace {0}{1}", ex.StackTrace, Environment.NewLine));
				}
				ex = ex.InnerException;
			}
			while (ex != null);

			return new ErrorMessage()
			{
				Message = exceptionMessage.ToString(),
				StackTrace = exceptionStackTrace.ToString()
			};
		}
	}
}

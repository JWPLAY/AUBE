using System;
using System.Reflection;

namespace JW.AUBE.Base.Utils
{
	public class TypeUtils
	{
		/// ///////////////////// InvokeStringMethod //////////////////////
        ///
        /// <summary>
        /// Calls a static public method. 
        /// Assumes that the method returns a string, and doesn't have parameters.
        /// </summary>
        /// <param name="typeName">name of the class in which the method lives.</param>
        /// <param name="methodName">name of the method itself.</param>
        /// <returns>the string returned by the called method.</returns>
        /// 
		public static object InvokeMethod(string typeName, string methodName)
		{
			var calledType = Type.GetType(typeName);
			var o = calledType.InvokeMember(
							methodName,
							BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
							null,
							null,
							null);
			return o;
		}


		/// ///////////////////// InvokeStringMethod2 //////////////////////
        ///
        /// <summary>
        /// Calls a static public method. 
        /// Assumes that the method returns a string, and takes a string parameter.
        /// </summary>
        /// <param name="typeName">name of the class in which the method lives.</param>
        /// <param name="methodName">name of the method itself.</param>
        /// <param name="stringParam">parameter passed to the method.</param>
        /// <returns>the string returned by the called method.</returns>
        /// 
		public static object InvokeMethod2(string typeName, string methodName, object param)
		{
			var calledType = Type.GetType(typeName);
			var o = calledType.InvokeMember(
							methodName,
							BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
							null,
							null,
							new object[] { param });
			return o;
		}

		/// ///////////////////// InvokeStringMethod3 //////////////////////
        ///
        /// <summary>
        /// Calls a static public method. 
        /// Assumes that the method returns a string, and doesn't have parameters.
        /// </summary>
        /// <param name="assemblyName">name of the assembly containing the class in which the method lives.</param>
        /// <param name="namespaceName">namespace of the class.</param>
        /// <param name="typeName">name of the class in which the method lives.</param>
        /// <param name="methodName">name of the method itself.</param>
        /// <returns>the string returned by the called method.</returns>
        /// 
		public static object InvokeMethod3(
								string assemblyName,
								string namespaceName,
								string typeName,
								string methodName)
		{
			var calledType = Type.GetType(string.Format("{0}.{1},{2}", namespaceName, typeName, assemblyName));
			var o = calledType.InvokeMember(
							methodName,
							BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
							null,
							null,
							null);
			return o;
		}

		/// ///////////////////// InvokeStringMethod3 //////////////////////
  ///
  /// <summary>
  /// Calls a static public method. 
  /// Assumes that the method returns a string, and doesn't have parameters.
  /// </summary>
  /// <param name="assemblyName">name of the assembly containing the class in which the method lives.</param>
  /// <param name="namespaceName">namespace of the class.</param>
  /// <param name="typeName">name of the class in which the method lives.</param>
  /// <param name="methodName">name of the method itself.</param>
  /// <returns>the string returned by the called method.</returns>
  /// 
		public static object InvokeMethodByParam(
								string assemblyName,
								string namespaceAndTypeName,
								string methodName,
								object param = null)
		{
			var calledType = Type.GetType(string.Format("{0},{1}", namespaceAndTypeName, assemblyName));

			var o = calledType.InvokeMember(
							methodName,
							BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
							null,
							null,
			(param != null) ? new object[] { param } : null);

			return o;
		}
	}
}

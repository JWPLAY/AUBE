using System;
using System.Collections;
using System.Reflection;

namespace JW.AUBE.Base.Utils
{
	public class DynamicInvoke
	{
		public static object InvokeMethodSlow(string assemblyName, string className, string methodName, object[] args)
		{
			var assembly = Assembly.LoadFrom(assemblyName);

			foreach (Type type in assembly.GetTypes())
			{
				if (type.IsClass)
				{
					if (type.FullName.EndsWith("." + className))
					{
						var classObj = Activator.CreateInstance(type);

						var result = type.InvokeMember(
										methodName,
										BindingFlags.Default | BindingFlags.InvokeMethod,
										null,
										classObj,
										args);
						return (result);
					}
				}
			}
			throw (new Exception("Could not invoke method"));
		}

		public class DynamicClassInfo
		{
			public Type type;
			public object classObject;

			public DynamicClassInfo()
			{
			}
			public DynamicClassInfo(Type t, object c)
			{
				type = t;
				classObject = c;
			}
		}

		public static Hashtable AssemblyReferences = new Hashtable();
		public static Hashtable ClassReferences = new Hashtable();

		public static DynamicClassInfo GetClassReference(string assemblyName, string className)
		{
			if (ClassReferences.ContainsKey(assemblyName) == false)
			{
				Assembly assembly;
				if (AssemblyReferences.ContainsKey(assemblyName) == false)
				{
					AssemblyReferences.Add(assemblyName, assembly = Assembly.LoadFrom(assemblyName));
				}
				else
				{
					assembly = (Assembly)AssemblyReferences[assemblyName];
				}

				foreach (Type type in assembly.GetTypes())
				{
					if (type.IsClass)
					{
						if (type.FullName.EndsWith("." + className))
						{
							var ci = new DynamicClassInfo(type, Activator.CreateInstance(type));
							ClassReferences.Add(assemblyName, ci);
							return (ci);
						}
					}
				}
				throw (new Exception("Could not instantiate class"));
			}
			return ((DynamicClassInfo)ClassReferences[assemblyName]);
		}

		public static object InvokeMethod(DynamicClassInfo ci, string methodName, object[] args)
		{
			var result = ci.type.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, ci.classObject, args);
			return (result);
		}

		public static object InvokeMethod(string assemblyName, string className, string methodName, object[] args)
		{
			var ci = GetClassReference(assemblyName, className);
			return (InvokeMethod(ci, methodName, args));
		}
	}
}

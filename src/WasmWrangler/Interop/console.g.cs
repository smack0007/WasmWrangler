// <auto-generated />
#nullable enable
using WebAssembly;

namespace WasmWrangler.Interop
{
	public static partial class console
	{
		private static JSObject? __js;

		private static JSObject _js
		{
			get
			{
				if (__js == null)
					__js = (JSObject)Runtime.GetGlobalObject(nameof(console));

				return __js;
			}
		}

		private static JSObject? _memory;

		public static JSObject memory
		{
			get => _memory ?? (_memory = _js.GetObjectProperty<JSObject>(nameof(memory)));
		}

		public static void assert(bool? condition, params object[] data)
		{
			_js.Invoke(nameof(assert), condition, data);
		}

		public static void clear()
		{
			_js.Invoke(nameof(clear));
		}

		public static void count(string? label = null)
		{
			_js.Invoke(nameof(count), label);
		}

		public static void countReset(string? label = null)
		{
			_js.Invoke(nameof(countReset), label);
		}

		public static void debug(params object[] data)
		{
			_js.Invoke(nameof(debug), data);
		}

		public static void dir(object? item = null, object? options = null)
		{
			_js.Invoke(nameof(dir), item, options);
		}

		public static void dirxml(params object[] data)
		{
			_js.Invoke(nameof(dirxml), data);
		}

		public static void error(params object[] data)
		{
			_js.Invoke(nameof(error), data);
		}

		public static void exception(string? message = null, params object[] optionalParams)
		{
			_js.Invoke(nameof(exception), message, optionalParams);
		}

		public static void group(params object[] data)
		{
			_js.Invoke(nameof(group), data);
		}

		public static void groupCollapsed(params object[] data)
		{
			_js.Invoke(nameof(groupCollapsed), data);
		}

		public static void groupEnd()
		{
			_js.Invoke(nameof(groupEnd));
		}

		public static void info(params object[] data)
		{
			_js.Invoke(nameof(info), data);
		}

		public static void log(params object[] data)
		{
			_js.Invoke(nameof(log), data);
		}

		public static void table(object? tabularData = null, string[]? properties = null)
		{
			_js.Invoke(nameof(table), tabularData, properties);
		}

		public static void time(string? label = null)
		{
			_js.Invoke(nameof(time), label);
		}

		public static void timeEnd(string? label = null)
		{
			_js.Invoke(nameof(timeEnd), label);
		}

		public static void timeLog(string? label = null, params object[] data)
		{
			_js.Invoke(nameof(timeLog), label, data);
		}

		public static void timeStamp(string? label = null)
		{
			_js.Invoke(nameof(timeStamp), label);
		}

		public static void trace(params object[] data)
		{
			_js.Invoke(nameof(trace), data);
		}

		public static void warn(params object[] data)
		{
			_js.Invoke(nameof(warn), data);
		}

	}

}

using System;
namespace AdventOf.Code.Common
{
	public static class ExtensionsString
	{
		public static string[] ToLines(this string s, bool removeEmpty = true)
		{
			return s.Split(Environment.NewLine, removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.TrimEntries);
		}
	}
}


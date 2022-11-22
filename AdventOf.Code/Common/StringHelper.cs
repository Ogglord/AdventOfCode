using System;
namespace AdventOf.Code.Common
{
	public static class StringHelper
	{
		public static string[] ToLines(this string s)
		{
			return s.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}


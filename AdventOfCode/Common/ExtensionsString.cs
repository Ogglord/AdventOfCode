using System;
namespace AdventOf.Code.Common
{
	public static class ExtensionsString
	{
		public static string[] ToLines(this string s, bool removeEmpty = true)
		{
			//if(Environment.OSVersion.Platform == PlatformID.Win32NT)				
                return s.Split("\n", removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.TrimEntries);
			//else
			//	return s.Split("\n", removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.TrimEntries);
		}
	}
}


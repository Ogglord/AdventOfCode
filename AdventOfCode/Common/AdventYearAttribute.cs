using System;
namespace AdventOf.Code.Common
{
	[AttributeUsage(validOn: AttributeTargets.Class)]
	public class AdventYearAttribute : Attribute
	{
		public AdventYearAttribute(int year)
		{
            Year = year;
        }

        public int Year { get; }
    }
}


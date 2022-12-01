using System;
namespace AdventOf.Code.Common
{
	/// <summary>
	/// Indicates which year the day belongs to.
	/// Allows Test fixture to load input data automatically
	/// </summary>
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


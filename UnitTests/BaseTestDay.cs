using System;
using AdventOf.Code.Common;
using Xunit.Abstractions;

namespace AdventOf.Test
{
	public class BaseTestDay<T> : IClassFixture<TestHelperFixture>
		where T: AdventOf.Code.IAdventDay, new()
	{
        protected readonly ITestOutputHelper output;
        protected readonly TestHelperFixture fixture;
        protected readonly T day;
		protected readonly int year;
		protected readonly int dayOfAdvent;

		public BaseTestDay(ITestOutputHelper output, TestHelperFixture fixture)
		{
			day = new T();
            this.output = output;
            this.fixture = fixture;
            (dayOfAdvent, year) = ReadMetaData();
            output.WriteLine($"Preparing test fixture for {year} {dayOfAdvent}...");
        }

		private (int,int) ReadMetaData()
		{
            var attributes = typeof(T).GetCustomAttributes(typeof(AdventYearAttribute), true);

            if (attributes.Length == 0)
                throw new ArgumentException("T does not have attribute AdventYearAttribute");

            var className = typeof(T).Name;
            var dayStr = className.ToLower().TrimStart('d', 'a', 'y');

            try
            {
                int day = Convert.ToInt32(dayStr);
                return (day, attributes.OfType<AdventYearAttribute>().Single().Year);
            }
            catch (Exception)
            {
                throw new ArgumentException("T is not named according to the convention 'dayX'");
            }

        }
    }
}


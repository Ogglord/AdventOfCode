using AdventOf.Code.Common;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOf.Code.Y2022;

[AdventYear(2022)]
public class Day4 : IAdventDay
{



	private (int partOne, int partTwo) Solve(string input)
	{

		var overlappingSchedules = input
			.ToLines()
			.Select(x => x.Split(',')
				.Select(range => range.Split('-')
					.Select(s => Int32.Parse(s))
					.ToList())
				.ToList())
			.Where(ranges => ranges[0][0] <= ranges[1][1] && ranges[1][0] <= ranges[0][1])
			.ToList();

		var one = overlappingSchedules.Count(ranges => (ranges[0][0] <= ranges[1][0] && ranges[0][1] >= ranges[1][1]) ||
			(ranges[1][0] <= ranges[0][0] && ranges[1][1] >= ranges[0][1]));

		var two = overlappingSchedules.Count();

		return (one, two);

	}


    public object PartOne(string input)
	{
		return Solve(input).partOne;
	}
		public object PartTwo(string input)
    {
		return Solve(input).partTwo;
	}
}
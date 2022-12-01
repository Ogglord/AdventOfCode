using AdventOf.Code.Common;
namespace AdventOf.Code.Y2022;

[AdventYear(2022)]
public class Day1 : IAdventDay
{
	private (int partOne, int partTwo) Solve(string input)
	{
		var elfBackpacks = new List<int>();
		var currElf = 0;
		input
			.ToLines(removeEmpty: false)
			.Select(s => Convert.ToInt32(s == "" ? "0" : s))
			.ToList()
			.ForEach((val) =>
			{
				currElf += val;
				if (val == 0)
				{
					elfBackpacks.Add((currElf));
					currElf = 0;
				}

			});

		var partOne = elfBackpacks.Max();
		var partTwo = elfBackpacks.OrderDescending().Take(3).Sum();

		return (partOne, partTwo);
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
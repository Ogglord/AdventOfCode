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
	.ToList()
	.ForEach((val) =>
	{
		if (val == "")
		{
			elfBackpacks.Add((currElf));
			currElf = 0;
		}else
			currElf += Int32.Parse(val);

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
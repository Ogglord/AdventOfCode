using AdventOf.Code.Common;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOf.Code.Y2022;


class CharComparer : IComparer<char>
{
	public int Compare(char x, char y)
	{
		var result = ((int)x).CompareTo((int)y);
		return result;
	}
}


[AdventYear(2022)]
public class Day3 : IAdventDay
{



	private (int partOne, int partTwo) Solve(string input)
	{
		var partOne = input.ToLines().Select(s => s.ToCharArray()).Select(array =>
			array.Take(array.Length / 2).Join(array.Skip(array.Length / 2)
			, key => key
			, key2 => key2
			//, (key, result) => result
			, (key, result) => (int)char.ToLower(result) + (char.IsUpper(result) ? -70 : -96)
			)
		).Select(grp => grp.ToList()).ToList();

		var partTwo = input
			.ToLines()
			.Select(row => row.ToCharArray())
			.Chunk(3)
			.Select(group => group[0]
				.Join(group[1], k => k, k => k, (k, r) => r)
				.Join(group[2], k => k, k => k, (k, r) => r))
			.SelectMany(grp => grp.Select(res => (int)char.ToLower(res) + (char.IsUpper(res) ? -70 : -96)).Distinct());

		return (partOne.Select(rugSack => rugSack.Distinct().Single()).Sum()
			, partTwo.Sum());
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
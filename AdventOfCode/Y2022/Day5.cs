using AdventOf.Code.Common;

namespace AdventOf.Code.Y2022;

[AdventYear(2022)]
public class Day5 : IAdventDay
{



	private (int partOne, int partTwo) Solve(string input)
	{
		List<Stack<char>>? stacks = null;

		var strRead = new StringReader(input);
		string? line = null;

		while(strRead.Peek() != '\n') {
			line = strRead.ReadLine()!;
			if (stacks == null)
			{
				var numOfStacks = (line.Length + 1) / 4;
                stacks = Enumerable
                    .Range(0, numOfStacks)
					.Select(i => new Stack<char>())
					.ToList();

            }
			// populate the stacks
			line
				.Chunk(4)
				.Select((ch, idx) => (index: idx, crate: ch[1]))
				.ToList()
				.ForEach(tpl => stacks[tpl.index].Prepend(tpl.crate));
		}

		// remove empty crates
		//stacks!.ForEach(s => {
		//	var crates = new String(s.ToArray()).Trim().ToList().ForEach( s.p)
		//		s.Pop();
		//});
		// process move instructions
		while((line = strRead.ReadLine()) != null)
		{
			(int nbr, int from, int to) = (line[5], line[12], line[17]);
			for(int i=nbr; i>0; i--)
			{
				stacks[to].Push(stacks[from].Pop());
			}
		}

		return (0, 0);
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
using AdventOf.Code.Common;
namespace AdventOf.Code.Y2018;

[AdventYear(2018)]
public class Day1 : IAdventDay
{

	public object PartOne(string input)
	{
		return input
			.ToLines()
			.Select(s => Convert.ToInt32(s))
			.Sum();
	}


	public object PartTwo(string input)
    {
        var _acc = 0;

        var steps = input
            .ToLines()
            .Select(s => new { step = Convert.ToInt32(s) })
            .ToList();

        var dict = new Dictionary<int, int>();
        int i = 0;

        while (i < 500)
        {
            foreach (var s in steps)
            {
                if (!dict.TryAdd(_acc += s.step, 1))
                {
                    //dict[_acc]++;
                    return _acc;
                }

            }
            i++;
        }

        throw new Exception("No result found in 500 iterations!");
          
    }
}
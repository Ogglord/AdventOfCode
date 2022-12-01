using AdventOf.Code.Common;

namespace AdventOf.Code.Y2018;

[AdventYear(2018)]
public class Day2 : IAdventDay
{

    public object PartOne(string input)
    {
        var twoCount = input.ToLines()
            .Where(s => s.ToCharArray().GroupBy(c => c).Any(grp => grp.Count() == 2))
            .DefaultIfEmpty()
            .Count();
        var threeCount = input.ToLines()
            .Where(s => s.ToCharArray().GroupBy(c => c).Any(grp => grp.Count() == 3))
            .DefaultIfEmpty()
            .Count();

        return twoCount * threeCount;
    }

    public object PartTwo(string input)
    {
        var lines = input.ToLines();

        foreach (var idx in Enumerable.Range(0, lines.First().Length - 1))
        {
            var matchingGroup = lines
                .Select(s => s.Remove(idx, 1))
                .GroupBy(s => s)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .SingleOrDefault();

            if (matchingGroup != null)
                return matchingGroup;

        }

        return null!;
    }
}
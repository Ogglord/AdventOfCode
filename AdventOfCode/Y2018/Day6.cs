using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOf.Code.Common;

namespace AdventOf.Code.Y2018;

[AdventYear(2022)]
public class Day6 : IAdventDay
{

    public object PartOne(string input)
    {
		Dictionary<char, Coord> points = new Dictionary<char, Coord>();
		

		var rx = new Regex(@"^(?<x>[0-9]*),\s*(?<y>[0-9]*)$", RegexOptions.Compiled | RegexOptions.Multiline);
		char startIndex = 'a';
		foreach(Match match in rx.Matches(input))
		{
			points.Add(startIndex++, (Int32.Parse(match.Groups["x"].Value),Int32.Parse(match.Groups["y"].Value)));
		}

		var width = points.Select(p => p.Value.X).Max();
		var height = points.Select(p => p.Value.Y).Max();
		var mat = new char[width, height];

		// remove points closes to the corners first, then remaining ones 1 by 1
		HashSet<char> infinitePoints = new HashSet<char>();
		for (int i = 0; i < width; i++)
			for (int j = 0; j < height; j++)
			{
				
				var dists = points.Select((p, id) => (dist: manhattanDist(p.Value, (i, j)), p.Key)).OrderBy(kvp => kvp.dist).ToList();
				var competitors = dists.TakeWhile(d => d.dist == dists.Select(d2 => d2.dist).Min()).ToList();
				mat[i, j] = competitors.Count == 1 ? competitors.Single().Key : '.';
				if ((i == 0 || i == width - 1 || j == 0 || j == height - 1) && competitors.Count == 1)// border
					infinitePoints.Add(competitors.Single().Key);

			}

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
				Console.Write(mat[x, y]);
			Console.Write("\n");
		}
			

				return 0;
	}

    public object PartTwo(string input)
    {
        return null!;
    }

	
	static int manhattanDist(Coord a, Coord b)
	{
		Coord diff = (a - b); // does Math.Abs(...) on coordinate differences
		var dist = diff.X + diff.Y;
		return dist;
	}


}
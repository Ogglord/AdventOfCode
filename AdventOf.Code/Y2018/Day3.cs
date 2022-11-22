using System.Drawing;
using System.Security.Claims;

namespace AdventOf.Code.Y2018;

[AdventYear(2018)]
public class Day3 : IAdventDay
{
    record Claim(int Id, Point Pos, Size Size);

    public object PartOne(string input)
    {
        var claims = input
            .ToLines()
            .Select(s => s.Split(' '))
            .Select(c => new Claim(Convert.ToInt32(c[0].TrimStart('#'))
              , StringToPoint(c[2])
              , StringToSize(c[3])))
            .ToList();

        var maxWidth = 1000;
        var maxHeight = 1000;

        int multipleClaims = 0;
        for (int x = 0; x < maxWidth; x++)
            for (int y = 0; y < maxHeight; y++)
            {
                var claimsAtThisPoint = 0;
                for (int i = claims.Count - 1; i >= 0; i--)
                {
                    var c = claims[i];
                    var deltaX = x - c.Pos.X;
                    var deltaY = y - c.Pos.Y;

                    if (deltaX >= 0 && deltaY >= 0)
                    {
                        if (deltaX < c.Size.Width && deltaY < c.Size.Height)
                            claimsAtThisPoint++;
                        else if (deltaX > c.Size.Width && deltaY > c.Size.Height) // we have passed this
                        {
                            claims.RemoveAt(i);
                            //Console.WriteLine($"We have passed claim # {c.Id}");
                        }

                    }


                    if (claimsAtThisPoint > 1)
                    {
                        multipleClaims++;
                        //Console.WriteLine($"We have found two or more claims @ {x},{y}");
                        break;
                    }


                }
            }



        return multipleClaims;
    }

    const int EMPTY = 0;
    const int OCCUPIED_TWICE = -1;

    public object PartTwo(string input)
    {
        var claims = input
           .ToLines()
           .Select(s => s.Split(' '))
           .Select(c => new Claim(Convert.ToInt32(c[0].TrimStart('#'))
             , StringToPoint(c[2])
             , StringToSize(c[3])))
           .ToList();

        var matr = new int[1000,1000];

        var untouchedClaims = new HashSet<int>();

        foreach (var c in claims)
        {
            untouchedClaims.Add(c.Id);

            for (var i = 0; i < c.Size.Width; i++)
            {
                for (var j = 0; j < c.Size.Height; j++)
                {
                    var x = c.Pos.X + i;
                    var y = c.Pos.Y + j;
                    if (matr[x, y] == EMPTY)
                    {
                        matr[x, y] = c.Id;
                    }
                    else if (matr[x, y] == OCCUPIED_TWICE)
                    {
                        untouchedClaims.Remove(c.Id);
                    }
                    else
                    {
                        // we have found another claim
                        untouchedClaims.Remove(matr[x, y]);
                        untouchedClaims.Remove(c.Id);

                        matr[x, y] = OCCUPIED_TWICE;
                    }
                }

            }

        }
        return untouchedClaims.Single();

    }


    Point StringToPoint(string c)
    {
        var split = c.TrimEnd(':').Split(',');
        return new Point(Convert.ToInt32(split.First()), Convert.ToInt32(split.Last()));
    }

    Size StringToSize(string c)
    {
        var split = c.Split('x');
        return new Size(Convert.ToInt32(split.First()), Convert.ToInt32(split.Last()));
    }
}
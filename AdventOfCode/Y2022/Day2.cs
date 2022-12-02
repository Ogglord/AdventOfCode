using AdventOf.Code.Common;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOf.Code.Y2022;

[AdventYear(2022)]
public class Day2 : IAdventDay
{
    /* 1p           2p               3p
	 * A for Rock, B for Paper, and C for Scissors
	 * 65			66				67
	 * 
	 * X for Rock, Y for Paper, and Z for Scissors
	 * 88			89				90
	 * 
	 * WIN = 6p, DRAW = 3p, LOSS = 0p
	 * 
	 * */

     /* X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. */

	private (int partOne, int partTwo) Solve(string input)
	{
        (int playerOnePoints, int playerTwoPoints) GetPoints(char p1, char p2, bool forceOutcome = false)
        {
            int p1a = (int)p1 - 64; // 1,2,3
            int p2a = (int)p2 - 87; // 1,2,3

            if (forceOutcome) // part two
            {
                p2a = p2a switch
                {
                    1 => p1a switch { 1 => 3, 2 => 1, 3 => 2, _ => 0 }, /*loss*/
                    2 => p1a, /* draw */
                    3 => p1a switch { 1 => 2, 2 => 3, 3 => 1, _ => 0 }, /*win*/
                    _ => 0
                };
            }

            switch (p1a - p2a)
            {
                case 1:
                case -2:/*win p1*/
                    return (p1a + 6, p2a + 0);
                case -1:
                case 2: /*win p2*/
                    return (p1a + 0, p2a + 6);
                default:
                case 0: /*draw*/
                    return (p1a + 3, p2a + 3);
            }

        }

        var collectionOfPoints = input
            .ToLines()
            .Select( line =>
                 /* tuple with partOne, partTwo points */
                 (GetPoints(line[0], line[2]).playerTwoPoints, GetPoints(line[0], line[2], forceOutcome: true).playerTwoPoints)
        ).ToList();

        var result_1 = collectionOfPoints.Select(players => players.Item2).Sum();
        var result_2 = collectionOfPoints.Select(players => players.Item2).Sum();

        return (result_1, result_2);
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
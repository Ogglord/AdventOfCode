using AdventOf.Code.Common;
using System.Text.RegularExpressions;

namespace AdventOf.Code.Y2018;

[AdventYear(2018)]
public class Day5 : IAdventDay
{
   
    private string React(string input)
    {
        var currPolymer = input.Trim();

        while (true)
        {
            var newPolymerArr = new char[input.Length];
            var newLength = 0;

            for (int i = 0; i < currPolymer.Length - 1; i++)
            {
                if (Math.Abs(currPolymer[i] - currPolymer[i + 1]) == 32)
                {
                    //reaction - dont keep this pair, skip to next
                    i++;
                    continue;
                }

                newPolymerArr[newLength++] = currPolymer[i];
                //newPolymerArr[newLength++] = currPolymer[i+1];
            }
            newPolymerArr[newLength++] = currPolymer.Last();
            if (newLength == currPolymer.Length)
                break; // done
            currPolymer = new string(newPolymerArr, 0, newLength);
        }

        return currPolymer;
    }

    public object PartOne(string input)
    {
        return React(input.Trim()).Length;
    }
   

    public object PartTwo(string input)
    {
        input = input.Trim();
        var unique = input.ToLower().Distinct();

        var simulations = unique.Select(unit => (unit, str: input.Replace(unit.ToString(), null, StringComparison.InvariantCultureIgnoreCase)))
            .Select(sim => (len: React(sim.str).Length, sim.unit)).Min();

        
        return simulations;
    }


  
}
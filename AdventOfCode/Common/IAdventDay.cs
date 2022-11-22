using System;
namespace AdventOf.Code
{
	/// <summary>
	/// This represents any advent day solution
	/// </summary>
	public interface IAdventDay
	{
		object PartOne(string input);
        object PartTwo(string input);
    }
}


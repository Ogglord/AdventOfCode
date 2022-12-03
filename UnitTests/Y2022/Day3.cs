namespace AdventOf.Test.y2022;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2022;

public class TestDay3 : BaseTestDay<Day3>
{
    public TestDay3(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

	[Fact]
	public void PartOneTwo_Test()
	{
        var input = "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw";
		Assert.NotNull(input);

		// Run
		var result = day.PartOne(input);

		// Write result
		output.WriteLine($"Result from part one test: {result}");

        // Run
        var result2 = day.PartTwo(input);

        // Write result
        output.WriteLine($"Result from part two test: {result2}");

    }

	[Fact]
    public async void PartOne()
    {
        var input = await fixture.GetInput(dayOfAdvent, year);
        Assert.NotNull(input);

        // Run
        var result = day.PartOne(input);

        // Write result
        output.WriteLine($"Result from part one: {result}");
        
       
    }

  

    [Fact]
    public async void PartTwo()
    {
        var input = await fixture.GetInput(dayOfAdvent, year);
        Assert.NotNull(input);

        // Run
        var result = day.PartTwo(input);

        // Write result
        output.WriteLine($"Result from part two: {result}");
    }
}

namespace AdventOf.Test.y2022;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2022;

public class TestDay2 : BaseTestDay<Day2>
{
    public TestDay2(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

	[Fact]
	public async void PartOneTwo_Test()
	{
        var input = "A Y\nB X\nC Z";
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

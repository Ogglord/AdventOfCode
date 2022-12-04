namespace AdventOf.Test.y2022;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2022;

public class TestDay4 : BaseTestDay<Day4>
{
    public TestDay4(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

	[Fact]
	public void PartOneTwo_Test()
	{
        var input = "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8";
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

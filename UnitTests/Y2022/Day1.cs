namespace AdventOf.Test.y2022;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2022;

public class TestDay1 : BaseTestDay<Day1>
{
    public TestDay1(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

	[Fact]
	public async void PartOne_Test()
	{
        var input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";
		Assert.NotNull(input);

		// Run
		var result = day.PartOne(input);

		// Write result
		output.WriteLine($"Result from part one test: {result}");


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

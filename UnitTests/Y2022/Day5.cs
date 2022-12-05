namespace AdventOf.Test.y2022;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2022;

public class TestDay5 : BaseTestDay<Day5>
{
    public TestDay5(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

	[Fact]  
	public void PartOneTwo_Test()
	{
        var input = "    [D]    \n[N] [C]    \n[Z] [M] [P]\n 1   2   3 \n\nmove 1 from 2 to 1\nmove 3 from 1 to 3\nmove 2 from 2 to 1\nmove 1 from 1 to 2";
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

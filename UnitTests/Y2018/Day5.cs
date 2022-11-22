namespace AdventOf.Test.y2018;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2018;

public class TestDay5 : BaseTestDay<Day5>
{
    public TestDay5(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

    [Fact]
    public async void PartOneTwo_Test()
    {
        var input = @"dabAcCaCBAcCcaDA";
        Assert.NotNull(input);

        // Run - 
        var result = day.PartOne(input);
        Assert.Equal(10, result);

        //result = day.PartTwo(input);
        //Assert.Equal(4455, result);

        // Write result
        output.WriteLine($"The run with test data passed!");


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

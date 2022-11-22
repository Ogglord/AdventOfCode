namespace AdventOf.Test.y2018;

using AoCHelper;
using Xunit.Abstractions;
using AdventOf.Code.Y2018;

public class TestDay4 : BaseTestDay<Day4>
{
    public TestDay4(ITestOutputHelper output, TestHelperFixture fixture) : base(output, fixture)
    {
    }

    [Fact]
    public async void PartOneTwo_Test()
    {
        var input = @"
                [1518-11-01 00:00] Guard #10 begins shift
                [1518-11-01 00:05] falls asleep
                [1518-11-01 00:25] wakes up
                [1518-11-01 00:30] falls asleep
                [1518-11-01 00:55] wakes up
                [1518-11-01 23:58] Guard #99 begins shift
                [1518-11-02 00:40] falls asleep
                [1518-11-02 00:50] wakes up
                [1518-11-03 00:05] Guard #10 begins shift
                [1518-11-03 00:24] falls asleep
                [1518-11-03 00:29] wakes up
                [1518-11-04 00:02] Guard #99 begins shift
                [1518-11-04 00:36] falls asleep
                [1518-11-04 00:46] wakes up
                [1518-11-05 00:03] Guard #99 begins shift
                [1518-11-05 00:45] falls asleep
                [1518-11-05 00:55] wakes up";
        Assert.NotNull(input);

        // Run - 
        var result = day.PartOne(input);
        Assert.Equal(240, result);

        result = day.PartTwo(input);
        Assert.Equal(4455, result);

        // Write result
        output.WriteLine($"Result from part one and two passed!");


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

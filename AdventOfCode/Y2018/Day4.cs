using AdventOf.Code.Common;
using System.Drawing;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace AdventOf.Code.Y2018;

[AdventYear(2018)]
public class Day4 : IAdventDay
{
    // [1518-02-28 00:47] falls asleep
    // [1518-10-23 23:47] Guard #1627 begins shift
    private (int PartOne, int PartTwo) Solve(string input)
    {
        var rx = new Regex(@"^\[(?<time>[0-9]{4}.*)\]\s(?<status>.*)$");
        var events = new SortedDictionary<DateTime, string>();

        foreach (var line in input.ToLines())
        {
            var parts = rx.Match(line.Trim());
            var timeStr = parts.Groups["time"].Value;
            var statusStr = parts.Groups["status"].Value;

            var time = DateTime.Parse(timeStr);

            events.Add(time, statusStr);
        }

        var guardSleepStat = new Dictionary<int, int[]>();
        int guardId = -1;
        foreach (var (time, evnt) in events)
        {
            switch (evnt[0])
            {
                case 'G': // guard switch
                    guardId = int.Parse(evnt.Split(' ').Single(s => s.Contains('#')).TrimStart('#'));
                    guardSleepStat.TryAdd(guardId, new int[60]);
                    break;
                case 'f': // falls asleep
                    int sleepMinute = time.Hour == 23 ? 00 : time.Minute;
                    for (int i = sleepMinute; i < 60; i++)
                        ++guardSleepStat[guardId][i];
                    break;
                case 'w': // wakes up
                    int wakeMinute = time.Hour == 23 ? 00 : time.Minute;
                    for (int i = wakeMinute; i < 60; i++)
                        --guardSleepStat[guardId][i];
                    break;

            }

        }
        //identify highest frequency amongst all guards
        //format: [guardId] (frequency, minute/index)
        var guardSleepHour = guardSleepStat
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Select((n, hour) => (n, hour)).Max());


        // strategy one - sum sleep hours per guard
        var guardSleepSum = guardSleepStat
            .ToDictionary(kvp => kvp.Key, kv => kv.Value.Sum());

        // rank them by maximum sleep hours
        var (topHours, gid) = guardSleepSum.Select(kvp => (kvp.Value, kvp.Key)).Max();
        var partOne = gid * guardSleepHour[gid].hour;


        //strategy two
        var (frequency,gid2,minute) = guardSleepHour.Select(kvp => (kvp.Value.n, kvp.Key, kvp.Value.hour)).Max();
        var partTwo = gid2 * minute;

        return (partOne, partTwo);
    }

    public object PartOne(string input)
    {
        return Solve(input).PartOne;
    }
   

    public object PartTwo(string input)
    {
        return Solve(input).PartTwo;
    }


  
}
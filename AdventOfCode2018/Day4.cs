using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day4
    {
        private static readonly string[] _inputs = File.ReadAllText(@"Inputs/Day4.txt").Split(new String[] { "\r\n" }, StringSplitOptions.None).ToArray();
        public void Run()
        {
            PartOne();
        }

        private void PartOne()
        {
            var guardLogs = new List<GuardLog>();

            foreach (var input in _inputs)
            {
                var spaceSplit = input.Split(' ');
                var dateSplit = spaceSplit[0].Replace("[", "").Split('-');
                var timeSplit = spaceSplit[1].Replace("]", "").Split(":");
                var guardId = 0;
                if (spaceSplit[2] == "Guard")
                {
                    guardId = int.Parse(spaceSplit[3].Replace("#", ""));
                }

                guardLogs.Add(new GuardLog
                {
                    Year = int.Parse(dateSplit[0]),
                    Month = int.Parse(dateSplit[1]),
                    Day = int.Parse(dateSplit[2]),
                    Hour = int.Parse(timeSplit[0]),
                    Minute = int.Parse(timeSplit[1]),
                    GuardId = guardId,
                    LogText = (spaceSplit[2] == "Guard" ? "begins shift" : spaceSplit[2] + " " + spaceSplit[3])
                });
            }

            guardLogs.Sort();

            var guardRecords = new List<GuardRecord>();

            var currentGuard = 0;
            var sleepMinute = 0;

            foreach(var log in guardLogs)
            {
                if(log.GuardId != 0)
                {
                    currentGuard = log.GuardId;
                    if (guardRecords.Count(x => x.GuardId == log.GuardId) == 0)
                    {
                        var minutesAsleep = new Dictionary<int, int>();
                        for(var i = 0; i < 60; i++)
                        {
                            minutesAsleep.Add(i, 0);
                        }
                        guardRecords.Add(new GuardRecord
                        {
                            GuardId = log.GuardId,
                            TotalMinutesAsleep = 0,
                            MinutesAsleep = minutesAsleep

                        });
                    }
                }
                else
                {
                    if(log.LogText == "falls asleep")
                    {
                        sleepMinute = log.Minute;
                    }
                    else if(log.LogText == "wakes up")
                    {
                        var guardRecord = guardRecords.First(x => x.GuardId == currentGuard);
                        guardRecord.TotalMinutesAsleep += log.Minute - sleepMinute;
                        for(var i = sleepMinute; i < log.Minute; i++)
                        {
                            guardRecord.MinutesAsleep[i]++;
                        }
                    }
                }
            }

            var sleepiestGuard = guardRecords.OrderByDescending(x => x.TotalMinutesAsleep).First();
            var sleepiestMinute = 0;
            var amountSlept = 0;
            for(var i = 0; i < 60; i++)
            {
                if(sleepiestGuard.MinutesAsleep[i] > amountSlept)
                {
                    amountSlept = sleepiestGuard.MinutesAsleep[i];
                    sleepiestMinute = i;
                }
            }

            Console.WriteLine(sleepiestMinute * sleepiestGuard.GuardId);
        }

        private void PartTwo()
        {

        }
    }

    class GuardLog : IComparable<GuardLog>
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int GuardId { get; set; }
        public string LogText { get; set; }

        public int CompareTo(GuardLog otherLog)
        {
            int result = Year.CompareTo(otherLog.Year);
            if (result == 0)
            {
                result = Month.CompareTo(otherLog.Month);
            }
            if(result == 0)
            {
                result = Day.CompareTo(otherLog.Day);
            }
            if(result == 0)
            {
                result = Hour.CompareTo(otherLog.Hour);
            }
            if(result == 0)
            {
                result = Minute.CompareTo(otherLog.Minute);
            }

            return result;
        }
    }

    class GuardRecord
    {
        public int GuardId { get; set; }
        public int TotalMinutesAsleep { get; set; }
        public Dictionary<int, int> MinutesAsleep { get; set; }
    }
}

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

            var guardData = new List<Tuple<int, int, int[]>>();

            foreach(var log in guardLogs)
            {

            }
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
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day6
    {
        private static readonly string[] _inputs = File.ReadAllText(@"Inputs/Day6.txt").Split("\n").ToArray();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var coordinates = new List<Coordinate>();

            for (var i = 0; i < _inputs.Length; i++)
            {
                var split = _inputs[i].Split(", ");
                coordinates.Add(new Coordinate
                {
                    Id = i,
                    XCoord = int.Parse(split[0]),
                    YCoord = int.Parse(split[1]),
                    ClosestArea = 0,
                    Infinite = false
                });
            }

            var maxX = coordinates.OrderByDescending(x => x.XCoord).First().XCoord;
            var maxY = coordinates.OrderByDescending(x => x.YCoord).First().YCoord;

            for (var i = 0; i <= maxY; i++)
            {
                for (var j = 0; j <= maxX; j++)
                {
                    var currentDistance = 9999;
                    var coordinateToIncrement = 0;
                    var increment = true;

                    foreach (var coordinate in coordinates)
                    {
                        if (coordinate.ManhattanDistance(j, i) == currentDistance)
                        {
                            increment = false;
                        }
                        else if (coordinate.ManhattanDistance(j, i) < currentDistance)
                        {
                            currentDistance = coordinate.ManhattanDistance(j, i);
                            coordinateToIncrement = coordinate.Id;
                            increment = true;
                        }
                    }

                    if (increment)
                    {
                        coordinates.First(x => x.Id == coordinateToIncrement).ClosestArea++;
                    }

                    if (i == 0 || j == 0 || i == maxY || j == maxX)
                    {
                        coordinates.First(x => x.Id == coordinateToIncrement).Infinite = true;
                    }
                }
            }

            Console.WriteLine(coordinates.OrderByDescending(x => x.ClosestArea).Where(y => y.Infinite == false).First().ClosestArea);
        }

        private void PartTwo()
        {
            var coordinates = new List<Coordinate>();

            for (var i = 0; i < _inputs.Length; i++)
            {
                var split = _inputs[i].Split(", ");
                coordinates.Add(new Coordinate
                {
                    Id = i,
                    XCoord = int.Parse(split[0]),
                    YCoord = int.Parse(split[1]),
                    ClosestArea = 0,
                    Infinite = false
                });
            }

            var maxX = coordinates.OrderByDescending(x => x.XCoord).First().XCoord;
            var maxY = coordinates.OrderByDescending(x => x.YCoord).First().YCoord;

            var area = 0;

            for (var i = 0; i <= maxY; i++)
            {
                for (var j = 0; j <= maxX; j++)
                {
                    var currentDistanceToAll = 0;

                    foreach (var coordinate in coordinates)
                    {
                        currentDistanceToAll += coordinate.ManhattanDistance(j, i);
                    }

                    if(currentDistanceToAll < 10000)
                    {
                        area++;
                    }
                }
            }

            Console.WriteLine(area);
        }
    }

    class Coordinate
    {
        public int Id { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public int ClosestArea { get; set; }
        public bool Infinite { get; set; }

        public int ManhattanDistance(int x, int y)
        {
            return Math.Abs(XCoord - x) + Math.Abs(YCoord - y);
        }
    }
}

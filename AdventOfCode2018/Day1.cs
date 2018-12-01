using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day1
    {
        private static readonly int[] _inputs = File.ReadAllText(@"Inputs/Day1.txt").Split('\n').Select(int.Parse).ToArray();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var frequency = 0;
            foreach (var input in _inputs)
            {
                frequency += input;
            }

            Console.WriteLine(frequency);
        }

        private void PartTwo()
        {
            var frequency = 0;
            var seenFrequencies = new List<int>();
            var inputCounter = 0;

            while (!seenFrequencies.Contains(frequency))
            {
                seenFrequencies.Add(frequency);
                frequency += _inputs[inputCounter % _inputs.Length];

                inputCounter++;
            }

            Console.WriteLine(frequency);
        }
    }
}

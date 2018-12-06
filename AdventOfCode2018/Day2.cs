using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day2
    {
        private static readonly string[] _inputs = File.ReadAllText(@"Inputs/Day2.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var twos = 0;
            var threes = 0;

            foreach (var input in _inputs)
            {
                var characterCounts = input.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());

                if (characterCounts.ContainsValue(2))
                {
                    twos++;
                }

                if (characterCounts.ContainsValue(3))
                {
                    threes++;
                }
            }

            Console.WriteLine(twos * threes);
        }

        private void PartTwo()
        {
            Array.Sort(_inputs, StringComparer.InvariantCulture);
            
            for (var i = 0; i < _inputs.Length; i++)
            {
                var input = _inputs[i].ToCharArray();
                var secondInput = _inputs[i + 1].ToCharArray();

                var differenceCount = 0;
                var differenceIndex = 0;

                for (var j = 0; j < input.Length; j++)
                {
                    if(differenceCount > 1)
                    {
                        break;
                    }

                    if(input[j] != secondInput[j])
                    {
                        differenceCount++;
                        differenceIndex = j;
                    }
                }

                if(differenceCount == 1)
                {
                    Console.WriteLine(_inputs[i].Remove(differenceIndex, 1));
                    break;
                }
            }
        }
    }
}

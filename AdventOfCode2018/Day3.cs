using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day3
    {
        private static readonly string[] _inputs = File.ReadAllText(@"Inputs/Day3.txt").Split(new String[] { "\r\n" }, StringSplitOptions.None).ToArray();
        public void Run()
        {
            PartOneAndTwo();
        }

        private void PartOneAndTwo()
        {
            var cloth = new string[1000, 1000];
            var count = 0;
            var intactClaimIds = new List<int>();

            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    cloth[i,j] = ".";
                }
            }

            foreach (var input in _inputs)
            {
                var splitInput = input.Split(' ');
                var currentClaim = int.Parse(splitInput[0].Replace("#", ""));

                intactClaimIds.Add(currentClaim);

                var coordSplit = splitInput[2].Replace(":", "").Split(',');
                var xCoord = int.Parse(coordSplit[1]);
                var yCoord = int.Parse(coordSplit[0]);

                var dimensionSplit = splitInput[3].Split('x');
                var width = int.Parse(dimensionSplit[0]);
                var height = int.Parse(dimensionSplit[1]);

                for (var i = 0; i < height; i++)
                {
                    for (var j = 0; j < width; j++)
                    {
                        if (cloth[i + xCoord, j + yCoord] == ".")
                        {
                            cloth[i + xCoord, j + yCoord] = currentClaim.ToString();
                        }
                        else if (cloth[i + xCoord, j + yCoord] != "X")
                        {
                            if (intactClaimIds.Contains(currentClaim))
                            {
                                intactClaimIds.Remove(currentClaim);
                            }
                            if (intactClaimIds.Contains(int.Parse(cloth[i + xCoord, j + yCoord])))
                            {
                                intactClaimIds.Remove(int.Parse(cloth[i + xCoord, j + yCoord]));
                            }

                            cloth[i + xCoord, j + yCoord] = "X";
                            count++;
                        }
                        else
                        {
                            if (intactClaimIds.Contains(currentClaim))
                            {
                                intactClaimIds.Remove(currentClaim);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Total number of overlapping spaces: " + count);
            Console.WriteLine("Id of claim that doesn't overlap: " + intactClaimIds.First());
        }
    }
}

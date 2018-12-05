using System;
using System.IO;

namespace AdventOfCode2018
{
    public class Day5
    {
        private static string _input = File.ReadAllText(@"Inputs/Day5.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var polymer = _input;

            Console.WriteLine(ReducePolymer(polymer).Length);
        }

        private void PartTwo()
        {
            var polymer = _input;
            var letters = "abcdefghijklmnopqrstuvwxyz";

            var shortestLength = 50000;

            foreach (var letter in letters)
            {
                var newPolymer = polymer.Replace(letter.ToString().ToLower(), "").Replace(letter.ToString().ToUpper(), "");
                var length = ReducePolymer(newPolymer).Length;

                if(length < shortestLength)
                {
                    shortestLength = length;
                }
            }

            Console.WriteLine(shortestLength);
        }

        private string ReducePolymer(string polymer)
        {
            var canReduce = true;

            while (canReduce)
            {
                canReduce = false;
                var counter = 0;

                while (counter < polymer.Length - 1)
                {

                    var temp = polymer[counter];
                    if ((char.IsLower(polymer[counter]) && char.IsUpper(polymer[counter + 1]) && polymer[counter].ToString().ToUpper() == polymer[counter + 1].ToString().ToUpper())
                        || (char.IsUpper(polymer[counter]) && char.IsLower(polymer[counter + 1]) && polymer[counter].ToString().ToUpper() == polymer[counter + 1].ToString().ToUpper()))
                    {
                        polymer = polymer.Remove(counter, 2);
                        canReduce = true;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }

            return polymer;
        }
    }
}

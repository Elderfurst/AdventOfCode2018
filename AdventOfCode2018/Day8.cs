using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day8
    {
        private static readonly string _input = File.ReadAllText(@"Inputs/Day8.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var split = _input.Split(" ");

            var nodes = new List<Node>();

            var buildingTree = true;
            var pointer = 0;

            while (buildingTree)
            {
                var node = new Node();

                node.Id = int.Parse(split[pointer]);
            }
        }

        private void PartTwo()
        {

        }
    }

    class Node
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildNodeCount { get; set; }
        public int MetadataEntryCount { get; set; }
        public List<Node> ChildNodes { get; set; } = new List<Node>();
        public List<int> MetadataEntries { get; set; } = new List<int>();
    }
}

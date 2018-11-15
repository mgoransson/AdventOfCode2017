using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day07
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            // Console.WriteLine("Part II");
            // Console.WriteLine(Part02(input));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day07.input.txt");
        }

        public static string Part01(string[] input)
        {
            var towers = new List<string>();
            foreach (var row in input)
            {
                towers.AddRange(Regex.Matches(row, @"[a-z]\w*").Cast<Match>().ToList().Select(x => x.Value));
            }

            var sorted = towers.ToList().GroupBy(info => info)
                .Select(group => new
                {
                    Key = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.Count);

            return sorted.Any() ? sorted.FirstOrDefault().Key : string.Empty;
        }

        // public static string Part02(string[] input)
        // {
        // }
    }
}

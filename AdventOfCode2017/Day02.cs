using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day02
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day02.input.txt");
        }

        public static int Part01(string[] input)
        {
            return GetChecksum(input, true);
        }

        public static int Part02(string[] input)
        {
            return GetChecksum(input, false);
        }

        private static int GetChecksum(string[] input, bool calcDiff) 
        {
            var differences = new List<int>();
            var formattedInput = input.Select(x => x.Split('\t').Select(s => int.Parse(s)).ToArray()).ToList();
            differences.AddRange(formattedInput.Select(x => calcDiff ? GetDifferencesChecksum(x.ToList()) : GetEvenlyDivisibleChecksum(x.ToList())));

            return differences.Sum();
        }

        private static int GetDifferencesChecksum(List<int> list) 
        {
            return list.Max() - list.Min();
        }

        private static int GetEvenlyDivisibleChecksum(List<int> list) 
        {
            return int.Parse((from l1 in list
                    from l2 in list
                    where l1 != l2 && l1 % l2 == 0
                    select l1/l2).Single().ToString());
        }
    }
}

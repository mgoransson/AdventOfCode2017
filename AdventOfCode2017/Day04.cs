using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day04
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
            return File.ReadAllLines(@"Inputs/Day04.input.txt");
        }

        public static int Part01(string[] input)
        {
            return GetPassphraseCount(input, false);
        }

        public static int Part02(string[] input)
        {
            return GetPassphraseCount(input, true);
        }

        public static int GetPassphraseCount(string[] input, bool checkForAnagrams) 
        {
            var validCount = 0;

            foreach (var row in input)
            {
                var arrayToValidate = row.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (checkForAnagrams) 
                {
                    var sortedList = new List<string>();
                    foreach (var str in arrayToValidate)
                    {
                        var sorted = str.ToCharArray().OrderBy(x => x).ToArray();
                        sortedList.Add(new string(sorted));
                    }
                    arrayToValidate = sortedList.ToArray();
                }
                 
                if (isValid(arrayToValidate))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        private static bool isValid(string[] input)
        {
            foreach (var word in input)
            {
                var count = input.Count(x => x == word);
                if (count > 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using System;
using System.IO;

namespace AdventOfCode2017
{
    public class Day01
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static string ReadInput() 
        {
            return File.ReadAllText(@"Inputs/Day01.input.txt");
        }

        public static int Part01(string input)
        {
            return GetSum(input, 1);
        }

        public static int Part02(string input)
        {
            return GetSum(input, input.Length/2);
        }

        private static int GetSum(string input, int jump) 
        {
            var sum = 0;
            for(var i = 0; i < input.Length; i++) 
            {
                var currentIndex = (i + input.Length) % input.Length;
                var nextIndex = ((currentIndex + jump) + input.Length) % input.Length;

                sum += (input[nextIndex] == input[currentIndex] ? int.Parse(input[currentIndex].ToString()) : 0);
            }
            return sum;
        }
    }
}

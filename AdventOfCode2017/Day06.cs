using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day06
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static int[] ReadInput() 
        {
            var input = File.ReadAllText(@"Inputs/Day06.input.txt");
            return Array.ConvertAll(input.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));            
        }

        public static int Part01(int[] input)
        {
            return GetCycles(input);
        }

        public static int Part02(int[] input)
        {
            var cycles = GetCycles(input);
            return GetCycles(input);
        }

        private static int GetCycles(int[] input) 
        {
            var scearios = new List<string>();
            scearios.Add(String.Join("", input));

            var cycles = 0;

            while (true)
            {
                var largestValue = input.Max();
                var largestIndex = input.ToList().IndexOf(largestValue);

                input[largestIndex] = 0;

                var currentIndex = largestIndex == input.Length - 1 ? 0 : largestIndex + 1;

                for (var i = 1; i <= largestValue; i++)
                {
                    input[currentIndex] += 1;

                    currentIndex = (currentIndex == input.Length - 1) ? 0 : (currentIndex + 1);
                }

                cycles++;
                var currentScenario = String.Join("", input);
                if (scearios.Contains(currentScenario))
                {
                    break;
                }

                scearios.Add(currentScenario);
            }

            return cycles;
        }
    }
}

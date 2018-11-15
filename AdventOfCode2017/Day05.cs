using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day05
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
            var input = File.ReadAllLines(@"Inputs/Day05.input.txt");
            return Array.ConvertAll(input, s => int.Parse(s));
        }

        public static int Part01(int[] input)
        {
            return GetSteps(input, true);
        }

        public static int Part02(int[] input)
        {
            return GetSteps(input, false);
        }

        private static int GetSteps(int[] input, bool part1) 
        {
            var currentIndex = 0;
            var stepsTaken = 0;

            while(true) 
            {
                var stepsToTake = input[currentIndex];
                input[currentIndex] += part1 ? 1 : (stepsToTake >= 3 ? -1 : 1);

                currentIndex += stepsToTake;
                stepsTaken++;
                
                if (currentIndex < 0 || currentIndex > input.Length - 1)
                {
                    break;
                }
            }

            return stepsTaken;
        }
    }
}

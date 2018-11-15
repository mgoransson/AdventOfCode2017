using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day17
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
            return File.ReadAllText(@"Inputs/Day17.input.txt");
        }

        public static int Part01(string input) 
        {
            var stepsToMoveForward = int.Parse(input);

            var buffer = new List<int>();
            buffer.Insert(0, 0);
            var current_index = 1;

            for(var i = 1; i <= 2017; i++)
            {
                current_index = (current_index + stepsToMoveForward) % buffer.Count;

                buffer.Insert(current_index, i);

                current_index += 1;
            }

            var next = buffer[buffer.IndexOf(2017) + 1];
            return next;
        }

        public static int Part02(string input) 
        {
            var stepsToMoveForward = int.Parse(input);

            int current_index = 0;
            int valueAtPos1 = -1;

            for (int i = 1; i <= 50000000; i++)
            {
                current_index = ((current_index + stepsToMoveForward) % i);
                if (current_index == 0) 
                {
                    valueAtPos1 = i;
                }

                current_index += 1;
            }

            return valueAtPos1;
        }
    }
}

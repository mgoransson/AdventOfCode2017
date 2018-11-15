using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day15
    {
        public static void Run()
        {
            var input = ReadInput();
            var formattedInput = FormatInput(input);

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(formattedInput.GeneratorA, formattedInput.GeneratorB));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(formattedInput.GeneratorA, formattedInput.GeneratorB));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day15.input.txt");
        }

        public static int Part01(long valueGeneratorA, long valueGeneratorB) 
        {
            return GetMatchCount(valueGeneratorA, valueGeneratorB, 40000000, 1, 1);
        }

        public static int Part02(long valueGeneratorA, long valueGeneratorB) 
        {
            return GetMatchCount(valueGeneratorA, valueGeneratorB, 5000000, 4, 8);
        }

        static int GetMatchCount(long valueGeneratorA, long valueGeneratorB, long loopCount, int multipliesOfA, int multipliesOfB) 
        {
            var count = 0;
            for( int i = 0; i < loopCount; i++) 
            {
                valueGeneratorA = GeneratorA(valueGeneratorA, multipliesOfA);
                valueGeneratorB = GeneratorB(valueGeneratorB, multipliesOfB);

                var binary_Generator_A = Convert.ToString(valueGeneratorA, 2).PadLeft(32, '0');
                var binary_Generator_B = Convert.ToString(valueGeneratorB, 2).PadLeft(32, '0');

                if (binary_Generator_A.Substring(binary_Generator_A.Length - 16, 16) == 
                    binary_Generator_B.Substring(binary_Generator_B.Length - 16, 16)){
                    count++;
                }
            }

            return count;
        }

        public static GeneratorValues FormatInput(string[] input)
        {
            return new GeneratorValues()
            {
                GeneratorA = int.Parse(input[0].Split(" ").Last()),
                GeneratorB = int.Parse(input[1].Split(" ").Last())
            };
        }

        static long GeneratorA(long previousValue, int multipliesOf) 
        {
            var factor = 16807;

            var reminder = (previousValue * factor) % 2147483647;
            if (reminder % multipliesOf != 0) 
            {
                reminder = GeneratorA(reminder, multipliesOf);
            } 
            return reminder;
        }

        static long GeneratorB(long previousValue, int multipliesOf) 
        {
            var factor = 48271;

            var reminder = (previousValue * factor) % 2147483647;
            if (reminder % multipliesOf != 0) 
            {
                reminder = GeneratorB(reminder, multipliesOf);
            } 
            return reminder;
        }

        public class GeneratorValues
        {
            public int GeneratorA { get; set; }
            public int GeneratorB { get; set; }
        }
    }
}

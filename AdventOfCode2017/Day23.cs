using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day23
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
            return File.ReadAllLines(@"Inputs/Day23.input.txt");
        }

        public static int Part01(string[] input) 
        {
            var registers = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var instruction = input[i].Split(" ");
                if(! int.TryParse(instruction[1], out int X) && ! registers.ContainsKey(instruction[1]))
                {
                    registers.Add(instruction[1], 0);
                }
                if(! int.TryParse(instruction[2], out int Y) && ! registers.ContainsKey(instruction[2]))
                {
                    registers.Add(instruction[2], 0);
                }
            }

            var mulCount = 0;

            var index = 0;
            while (index < input.Length)
            {
                var instruction = input[index].Split(" ");

                var isNumericX = int.TryParse(instruction[1], out int X);
                var isNumericY = int.TryParse(instruction[2], out int Y);

                var Xvalue = isNumericX ? X : registers[instruction[1]];
                var Yvalue = isNumericY ? Y : registers[instruction[2]];

                switch (instruction[0])
                {
                    case "set":
                        registers[instruction[1]] = Yvalue;
                        index++;
                    break;
                    case "sub":
                        registers[instruction[1]] -= Yvalue;
                        index++;
                    break;
                    case "mul":
                        registers[instruction[1]] *= Yvalue;
                        index++;
                        mulCount++;
                    break;
                    case "jnz":
                        if (Xvalue != 0)
                        {
                            index += Yvalue;
                        }
                        else 
                        {
                            index++;
                        }
                    break;
                }
            }

            return mulCount;
        }

        // public static int Part02(string[] input) 
        // {
        // }

    }
}

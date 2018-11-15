using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day08
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
            return File.ReadAllLines(@"Inputs/Day08.input.txt");
        }

        public static int Part01(string[] input)
        {
            return GetHighestValue(input, true);
        }

        public static int Part02(string[] input)
        {
            return GetHighestValue(input, false);
        }

        static int GetHighestValue(string[] input, bool highestAtEnd) 
        {
            var registers = new Dictionary<string, int>();

            var highestNumber = 0;

            registers = input
                .GroupBy(x => x.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)[0])
                .ToDictionary(x => x.FirstOrDefault().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)[0], x => 0);

            foreach (var row in input)
            {
                var instruction = row.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var registerToModify = instruction[0];
                var operation = instruction[1].ToLower();
                var val = int.Parse(instruction[2]);
                var conditionRegister = instruction[4];
                var conditionOperator = instruction[5];
                var conditionValue = int.Parse(instruction[6]);

                if ((conditionOperator == ">" && registers[conditionRegister] > conditionValue) ||
                    (conditionOperator == ">=" && registers[conditionRegister] >= conditionValue) ||
                    (conditionOperator == "<" && registers[conditionRegister] < conditionValue) ||
                    (conditionOperator == "<=" && registers[conditionRegister] <= conditionValue) ||
                    (conditionOperator == "==" && registers[conditionRegister] == conditionValue) ||
                    (conditionOperator == "!=" && registers[conditionRegister] != conditionValue))
                {
                    registers[registerToModify] = operation == "inc" ?
                    registers[registerToModify] + val :
                    registers[registerToModify] - val;
                }

                var currentHighestNumber = registers.OrderByDescending(x => x.Value).ToList()[0].Value;
                highestNumber = currentHighestNumber > highestNumber ? currentHighestNumber : highestNumber;
            }

            return highestAtEnd ? registers.OrderByDescending(x => x.Value).ToList()[0].Value : highestNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day18
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
            return File.ReadAllLines(@"Inputs/Day18.input.txt");
        }

        public static long Part01(string[] input) 
        {
            var registers = new Dictionary<string, long>();
            foreach(var row in input) 
            {
                var register = row.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                if (!registers.ContainsKey(register)) 
                {
                    registers.Add(register, 0);
                }            
            }

            var lastPlayedSound = 0L;
            var currentInstruction = 0L;
            while(true) 
            {
                var instruction = input[currentInstruction].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var instructionType = instruction[0];
                var register = instruction[1];
                var val = instruction.Length > 2 ? GetValue(instruction[2], registers) : GetValue(instruction[1], registers);

                if (instructionType == "set") 
                {
                    registers[register] = val;
                    currentInstruction++;
                } 
                else if (instructionType == "add") 
                {
                    registers[register] += val;
                    currentInstruction++;
                } 
                else if (instructionType == "mul") 
                {
                    registers[register] *= val;
                    currentInstruction++;
                } 
                else if (instructionType == "mod") 
                {
                    registers[register] %= val;
                    currentInstruction++;
                } 
                else if (instructionType == "snd") 
                {
                    lastPlayedSound = val;
                    currentInstruction++;
                } 
                else if (instructionType == "rcv") 
                {
                    if (registers[register] != 0) 
                    {
                        registers[register] = lastPlayedSound;
                        break;
                    }
                    currentInstruction++;
                } 
                else if (instructionType == "jgz") 
                {
                    if (registers[register] > 0) 
                    {
                        currentInstruction += val;
                    } else {
                        currentInstruction++;
                    }               
                }
            }
    
            return lastPlayedSound;
        }

        // public static long Part02(string[] input) 
        // {
        // }

       static long GetValue(string register, Dictionary<string, long> registers) 
       {
            if (long.TryParse(register, out var n)) 
            {
                return n;
            }
            return registers[register];
        }
    }
}

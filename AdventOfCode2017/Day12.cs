using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day12
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
            return File.ReadAllLines(@"Inputs/Day12.input.txt");
        }

        public static int Part01(string[] input) 
        {
            var programs = FormatInput(input);

            var programsInGroupZero = new List<int>();
            var programZeroCommunicateWith = programs.GetValueOrDefault(0);

            programsInGroupZero.Add(0);
            foreach(var programId in programZeroCommunicateWith) 
            {
                if (!programsInGroupZero.Contains(programId)) 
                {
                    programsInGroupZero.Add(programId);
                }
                GetProgramsInGroup(programId, programs, programsInGroupZero);
            }

            return programsInGroupZero.Count();
        }

        public static int Part02(string[] input) 
        {
            var programs = FormatInput(input);

            var groups = new List<string>();

            foreach(var program in programs) 
            {
                var programsInGroup = new List<int>();
                var programCommunicateWith = programs.GetValueOrDefault(program.Key);

                foreach(var programId in programCommunicateWith) 
                {
                    if (!programsInGroup.Contains(programId)) 
                    {
                        programsInGroup.Add(programId);
                    }
                    GetProgramsInGroup(programId, programs, programsInGroup);
                }

                var sorted = string.Join(",", programsInGroup.OrderBy(x => x));
                if (!groups.Contains(sorted)) 
                {
                    groups.Add(sorted);
                }
            }

            return groups.Count();
        }

        static Dictionary<int, int[]> FormatInput(string[] input) 
        {
            var programs = new Dictionary<int, int[]>();
            foreach(var row in input) 
            {
                var splittedRow = row.Split("<->", StringSplitOptions.RemoveEmptyEntries);

                var programId = int.Parse(splittedRow[0].Trim());
                var communicateWith = splittedRow[1].Split(",").Select(x => int.Parse(x.Trim())).ToArray();

                programs.Add(programId, communicateWith);
            }
            return programs;
        }

        static void GetProgramsInGroup(int programId, Dictionary<int, int[]> programs, List<int> programsInGroup) 
        {
            var communicateWith = programs.GetValueOrDefault(programId);
            foreach(var program in communicateWith) 
            {
                if (!programsInGroup.Contains(program)) 
                {
                    programsInGroup.Add(program);
                    if (program != programId) 
                    {
                        GetProgramsInGroup(program, programs, programsInGroup);
                    }
                }
            }
        }
    }
}

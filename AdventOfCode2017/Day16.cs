using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day16
    {
        public static void Run()
        {
            var input = ReadInput();
            var programs = "abcdefghijklmnop";

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input, programs));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input, programs));
        }

        public static string ReadInput() 
        {
            return File.ReadAllText(@"Inputs/Day16.input.txt");
        }

        public static string Part01(string input, string programs) 
        {
            var commands = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return Dance(programs, commands);
        }

        public static string Part02(string input, string programs) 
        {
            var commands = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var part01 = Part01(programs, programs);
            var cycleRes = part01;

            // Find next cycle
            var cycle = 0;
            while (true) 
            {
                cycleRes = Dance(cycleRes, commands);
                cycle++;

                if (cycleRes == part01)
                break;
            }

            for(var i = 0; i < 1_000_000_000 % cycle; i++) 
            {
                programs = Dance(programs, commands);
            }

            return programs;
        }

        static string Dance(string programs, string[] commands) 
        {
            foreach(var command in commands) 
            {
                if (command.StartsWith("s")) 
                {
                    programs = Spin(int.Parse(command.Substring(1, command.Length - 1)), programs);
                } 
                else if (command.StartsWith("x")) 
                {
                    var positions = command.Substring(1, command.Length - 1).Split("/", StringSplitOptions.RemoveEmptyEntries);
                    var a = int.Parse(positions[0]);
                    var b = int.Parse(positions[1]);
                    programs = Exchange(a, b, programs);
                } 
                else if (command.StartsWith("p")) 
                {
                    var swap = command.Substring(1, command.Length - 1).Split("/", StringSplitOptions.RemoveEmptyEntries);                   
                    programs = Partner(swap[0], swap[1], programs);
                }
            }
            return programs;
        }

        static string Spin(int programsToMove, string programs) 
        {
            return programs.Substring(programs.Length - programsToMove, programsToMove) + programs.Substring(0, programs.Length - programsToMove);; 
        }

        static string Exchange(int a, int b, string programs) 
        {
            StringBuilder sb = new StringBuilder(programs);
            
            var valPosA = programs[a];
            var valPosB = programs[b];
            
            sb[a] = valPosB;
            sb[b] = valPosA;

            return sb.ToString();
        }

        static string Partner(string a, string b, string programs) 
        {
            return Exchange(programs.IndexOf(a), programs.IndexOf(b), programs);
        }
    }
}

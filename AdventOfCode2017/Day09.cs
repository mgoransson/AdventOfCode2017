using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day09
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
            return File.ReadAllText(@"Inputs/Day09.input.txt");
        }

        public static int Part01(string input)
        {
            return ProcessStream(input).score;
        }

        public static int Part02(string input)
        {
            return ProcessStream(input).garbageCharacters;
        }

        private static (int score, int garbageCharacters) ProcessStream(string input)
        {
            var score = 0;
            var garbageCharacters = 0;
            var level = 0;
            var insideGarbage = false;

            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i];

                switch (character)
                {
                    case '{':
                        if (insideGarbage)
                        {
                            garbageCharacters++;
                        } 
                        else
                        {
                            level++;
                            score += level;
                        }
                    break;
                    case '}':
                        if (insideGarbage)
                        {
                            garbageCharacters++;
                        } 
                        else
                        {
                            level--;
                        }
                    break;
                    case '<':
                        if (insideGarbage)
                        {
                            garbageCharacters++;
                        } 
                        else
                        {
                            insideGarbage = true;
                        }
                    break;
                    case '>':
                        insideGarbage = false;
                    break;
                    case '!':
                        i++;
                    break;
                    default:
                        if (insideGarbage)
                        {
                            garbageCharacters++;
                        }
                    break;
                }
            }

            return (score, garbageCharacters);
        }
    }
}

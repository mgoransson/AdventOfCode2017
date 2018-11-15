using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day19
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
            return File.ReadAllLines(@"Inputs/Day19.input.txt");
        }

        public static string Part01(string[] input) 
        {
            return FollowDiagram(input).text;
        }

        public static int Part02(string[] input) 
        {
            return FollowDiagram(input).steps;
        }

        private static (string text, int steps) FollowDiagram(string[] input)
        {
             var row = 0;
            var rowIndex = input[0].IndexOf('|');
            var direction = Direction.Down;

            var doLoop = true;
            var letters = string.Empty;
            var steps = 0;
            while (doLoop)
            {
                var c = input[row][rowIndex];
                steps ++;
                switch (c)
                {
                    case '|':
                        if (direction == Direction.Down)
                            row++;
                        else if (direction == Direction.Up)
                            row --;
                        else if (direction == Direction.Left)
                            rowIndex--;
                        else if (direction == Direction.Right)
                            rowIndex++;                            
                    break;
                    case '-':
                        if (direction == Direction.Left)
                            rowIndex--;
                        else if (direction == Direction.Right)
                            rowIndex++;
                        else if (direction == Direction.Up)
                            row--;
                        else if (direction == Direction.Down)
                            row++;
                    break;
                    case '+':
                        if (direction != Direction.Left && input[row][rowIndex + 1] != ' ')
                        {
                            rowIndex++;
                            direction = Direction.Right;
                        }
                        else if (direction != Direction.Right && input[row][rowIndex - 1] != ' ')
                        {
                            rowIndex--;
                            direction = Direction.Left;
                        }
                        else if (direction != Direction.Up && (row + 1) < input.Length && input[row + 1][rowIndex] != ' ')
                        {
                            row++;
                            direction = Direction.Down;
                        }
                        else if (direction != Direction.Down && input[row - 1][rowIndex] != ' ')
                        {
                            row--;
                            direction = Direction.Up;
                        }
                    break;
                    case ' ':
                        doLoop = false;
                        steps--;
                    break;
                    default:
                        letters += c.ToString();
                        if (direction == Direction.Down)
                            row++;
                        else if (direction == Direction.Up)
                            row--;
                        else if (direction == Direction.Left)
                            rowIndex--;
                        else if (direction == Direction.Right)
                            rowIndex++;
                    break;

                }
            }

            return (letters, steps);
        }

        private enum Direction
        {
            Down,
            Up,
            Left,
            Right
        }
    }
}

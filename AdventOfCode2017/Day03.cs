using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day03
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static int ReadInput() 
        {
            var input = 0;
            Int32.TryParse(File.ReadAllText(@"Inputs/Day03.input.txt"), out input);
            return input;
        }

        public static int Part01(int input)
        {
            return GetSteps(input);
        }

        public static int Part02(int input)
        {
            return GetFirstLargestWrittenValue(input);
        }

        private static int GetSteps(int goal) 
        {           
            var spiral = new List<Point>();

            var currentPoint = new Point(0, 0);
            var step = 1;
            var direction = "R";
            var numb = 0;

            spiral.Add(currentPoint);

            while (true) 
            {
                if (numb == goal - 1)
                {
                    break;
                }

                for (var j = 1; j <= step; j++)
                {
                    numb++;
                    UpdateCurrentPoint(direction, ref currentPoint);
                    
                    spiral.Add(new Point(currentPoint.X, currentPoint.Y));

                    if (numb == goal - 1)
                    {
                        break;
                    }
                }

                ChangeDirection(ref direction, ref step);               
            }

            var goalPoint = spiral.Last();
            var requiredSteps = ManhattanDistance(0, goalPoint.X, 0, goalPoint.Y);
            return requiredSteps;
        }

        private static int GetFirstLargestWrittenValue(int goal) 
        {
            var spiral = new Dictionary<Point, int>();

            var currentPoint = new Point(0, 0);
            var step = 1;
            var direction = "R";
            var currentSum = 1;

            spiral.Add(currentPoint, 1);

            while (true)
            {
                if (currentSum > goal)
                {
                    break;
                }

                for (var j = 1; j <= step; j++)
                {
                     UpdateCurrentPoint(direction, ref currentPoint);

                     // Find all adjacent squares, including diagonals.
                    var adjacentSquares = GetAdjacentSquares(currentPoint);
                    // Loop through them and see if Point exists in coords
                    // if they do, add to sum.
                    // Add sum as Key when adding new coord
                    currentSum = GetSumOfAdjacentSquares(adjacentSquares, spiral);

                    spiral.Add(new Point(currentPoint.X, currentPoint.Y), currentSum);

                    if (currentSum > goal)
                    {
                        break;
                    }
                }

                ChangeDirection(ref direction, ref step);
            }

            return currentSum;
        }

        private static void UpdateCurrentPoint(string direction, ref Point currentPoint) 
        {
            switch (direction) 
            {
                case "R":
                currentPoint.X += 1;
                break;
                case "U":
                currentPoint.Y += 1;
                break;
                case "L":
                currentPoint.X -= 1;
                break;
                case "D":
                currentPoint.Y -= 1;
                break;
            }
        }

        private static void ChangeDirection(ref string direction, ref int step) 
        {
            switch (direction) 
            {
                case "R":
                direction = "U";
                break;
                case "U":
                direction = "L";
                step++;
                break;
                case "L":
                direction = "D";
                break;
                case "D":
                direction = "R";
                step++;
                break;
            }
        }

        private static List<Point> GetAdjacentSquares(Point p)
        {
            var result = new List<Point>();

            result.Add(new Point(p.X + 1, p.Y));
            result.Add(new Point(p.X + 1, p.Y + 1));
            result.Add(new Point(p.X, p.Y + 1));
            result.Add(new Point(p.X - 1, p.Y + 1));
            result.Add(new Point(p.X - 1, p.Y));
            result.Add(new Point(p.X - 1, p.Y - 1));
            result.Add(new Point(p.X, p.Y - 1));
            result.Add(new Point(p.X + 1, p.Y - 1));

            return result;
        }

        private static int GetSumOfAdjacentSquares(List<Point> list, Dictionary<Point, int> values)
        {
            var sum = 0;

            foreach (var point in list)
            {
                if (values.Any(x => x.Key == point))
                {
                    sum += values.FirstOrDefault(x => x.Key == point).Value;
                }
            }

            return sum;
        }

        private static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
    }
}

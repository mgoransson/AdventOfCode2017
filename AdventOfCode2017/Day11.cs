using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day11
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
            return File.ReadAllText(@"Inputs/Day11.input.txt");
        }

        public static int Part01(string input)
        {
            var steps = input.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var startCoord = new Coord(0, 0, 0); 
            var endCoord = GetEndCoord(steps);

            return GetDistance(startCoord, endCoord);
        }

        public static int Part02(string input)
        {
            var steps = input.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var furthest = FindFurthest(steps);

            return furthest;
        }

        static int GetDistance(Coord start, Coord end)
        {
            return (Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y) + Math.Abs(start.Z - end.Z))/2;
        }

        static void GoTo(string direction, Coord coord)
        {
            switch (direction)
            {
                case "n":
                    coord.Y++;
                    coord.Z--;
                    break;
                case "ne":
                    coord.X++;
                    coord.Z--;
                    break;
                case "se":
                    coord.X++;
                    coord.Y--;
                    break;
                case "s":
                    coord.Y--;
                    coord.Z++;
                    break;
                case "sw":
                    coord.X--;
                    coord.Z++;
                    break;
                case "nw":
                    coord.Y++;
                    coord.X--;
                    break;
            }
        }

        static Coord GetEndCoord(string[] steps)
        {
            var coord = new Coord(0, 0, 0);

            foreach (var step in steps)
            {
                GoTo(step, coord);
            }

            return coord;
        }

        static int FindFurthest(string[] steps)
        {
            var start = new Coord(0, 0, 0);
            var coord = new Coord(0, 0, 0);

            var furthest = 0;

            foreach (var step in steps)
            {
                GoTo(step, coord);

                var distance = GetDistance(start, coord);
                furthest = (distance > furthest) ? distance : furthest;
            }

            return furthest;
        }

        class Coord
        {
            public Coord(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

    }
}

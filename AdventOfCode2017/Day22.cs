using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day22
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input, 10000));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input, 10000000));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day22.input.txt");
        }

        public static int Part01(string[] input, int bursts) 
        {
            var cells = GetCells(input);

            var x = (input[0].Length / 2);
            var y = (input.Length / 2);

            var currentDirection = Direction.Up;
            var causedInfections = 0;
            var currentCellState = CellState.Clean;

            for (var i = 0; i < bursts; i++)
            {
                if (!cells.TryGetValue((x, y), out currentCellState))
                {
                    cells.Add((x, y), CellState.Clean);
                    currentCellState = CellState.Clean;
                }

                if (currentCellState == CellState.Clean)
                {
                    ChangeCellState_Part01(ref cells, x, y);
                    causedInfections++;
                    
                    TurnLeft(ref currentDirection);
                }
                else
                {
                    ChangeCellState_Part01(ref cells, x, y);

                    TurnRight(ref currentDirection);
                }
                Move(currentDirection, ref x, ref y);
            }

            return causedInfections;
        }

        public static int Part02(string[] input, int bursts) 
        {
            var cells = GetCells(input);

            var x = (input[0].Length / 2);
            var y = (input.Length / 2);

            var currentDirection = Direction.Up;
            var causedInfections = 0;
            var currentCellState = CellState.Clean;

            for (var i = 0; i < bursts; i++)
            {
                if (!cells.TryGetValue((x, y), out currentCellState))
                {
                    cells.Add((x, y), CellState.Clean);
                    currentCellState = CellState.Clean;
                }

                switch(currentCellState)
                {
                    case CellState.Clean:
                        ChangeCellState_Part02(ref cells, x, y);
                        TurnLeft(ref currentDirection);
                    break;
                    case CellState.Weakened:
                        ChangeCellState_Part02(ref cells, x, y);
                        causedInfections++;
                    break;
                    case CellState.Infected:
                        ChangeCellState_Part02(ref cells, x, y);
                        TurnRight(ref currentDirection);
                    break;
                    case CellState.Flagged:
                        ChangeCellState_Part02(ref cells, x, y);
                        ReverseDirection(ref currentDirection);
                    break;
                }
                Move(currentDirection, ref x, ref y);
            }

            return causedInfections;
        }

        private static Dictionary<(int, int), CellState> GetCells(string[] input)
        {
            var cells = new Dictionary<(int, int), CellState>();
            //var cells = new HashSet<Cell>();
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    cells.Add((j, i), input[i][j].ToString() == "#" ? CellState.Infected : CellState.Clean);
                }
            }

            return cells;
        }

        private static void ChangeCellState_Part01(ref Dictionary<(int, int), CellState> cells, int x, int y)
        {
            var cellState = CellState.Clean;
            cells.TryGetValue((x, y), out cellState);
            switch(cellState)
            {
                case CellState.Clean:
                    cells[(x, y)] = CellState.Infected;
                    break;
                case CellState.Infected:
                    cells[(x, y)] = CellState.Clean;
                break;
            }
        }

        private static void ChangeCellState_Part02(ref Dictionary<(int, int), CellState> cells, int x, int y)
        {
            var cellState = CellState.Clean;
            cells.TryGetValue((x, y), out cellState);
            switch(cellState)
            {
                case CellState.Clean:
                    cells[(x, y)] = CellState.Weakened;
                    break;
                case CellState.Weakened:
                    cells[(x, y)] = CellState.Infected;
                break;
                case CellState.Infected:
                    cells[(x, y)] = CellState.Flagged;
                break;
                case CellState.Flagged:
                    cells[(x, y)] = CellState.Clean;
                break;
            }
        }

        private static void ReverseDirection(ref Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentDirection = Direction.Down;
                    break;
                case Direction.Down:
                    currentDirection =  Direction.Up;
                    break;
                case Direction.Right:
                    currentDirection =  Direction.Left;
                    break;
                case Direction.Left:
                    currentDirection =  Direction.Right;
                    break;
            }
        }

        private static void TurnLeft(ref Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    currentDirection =  Direction.Right;
                    break;
                case Direction.Right:
                    currentDirection =  Direction.Up;
                    break;
                case Direction.Left:
                    currentDirection =  Direction.Down;
                    break;
            }
        }

        private static void TurnRight(ref Direction currentDirection)
        {
            switch(currentDirection)
            {
                case Direction.Up:
                    currentDirection =  Direction.Right;
                    break;
                case Direction.Down:
                    currentDirection =  Direction.Left;
                    break;
                case Direction.Right:
                    currentDirection =  Direction.Down;
                    break;
                case Direction.Left:
                    currentDirection =  Direction.Up;
                    break;
            }
        }

        private static void Move(Direction currentDirection, ref int x, ref int y)
        {
            switch(currentDirection)
            {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Left:
                    x--;
                    break;
            }
        }

        private enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        private enum CellState
        {
            Clean,
            Weakened,
            Infected,
            Flagged
        }
    }
}

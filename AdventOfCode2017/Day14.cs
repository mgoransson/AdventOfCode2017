using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day14
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            // Console.WriteLine("Part II");
            // Console.WriteLine(Part02(input));
        }

        public static string ReadInput() 
        {
            return File.ReadAllText(@"Inputs/Day14.input.txt");
        }

        public static int Part01(string input) 
        {
            var grid = new List<string>();
            var free = 0;
            var used = 0;
            for (var i = 0; i < 128; i++)
            {
                var elements = Enumerable.Range(0, 256).ToArray();
                var res = KnotHash($"{input}-{i}", elements);

                var binaryString = String.Join(String.Empty, res.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

                grid.Add(binaryString);

                free += binaryString.Count(x => x == '0');
                used += binaryString.Count(x => x == '1');
            }

            return used;
        }

        // public static int Part02(string[] input) 
        // {

        // }

        private static string KnotHash(string input, int[] elements) 
        {
            var asciiList = new List<int>();
            foreach( char c in input)
            {
                asciiList.Add(System.Convert.ToInt32(c));
            }

            var ascii = string.Join(",", asciiList) + ",17,31,73,47,23";
            ascii = ascii.Trim(',');

            var roundCount = 64;
            var currentPositionInElements = 0;
            var skipSize = 0;

            var formattedAscii = ascii.Split(",").Select(x => int.Parse(x));

            for(var i = 0; i < roundCount; i++) {
                foreach(var length in formattedAscii) {
                    var listToReverse = new List<int>();

                    var currentPageIndex = currentPositionInElements;
                    for(var a = 0; a < length; a++) {                    
                        currentPageIndex = (currentPageIndex + elements.Length) % elements.Length;
                        listToReverse.Add(elements[currentPageIndex]);
                        currentPageIndex++;
                    }

                    listToReverse.Reverse();

                    //Put back
                    currentPageIndex = currentPositionInElements;
                    for(var a = 0; a < listToReverse.Count; a++) {                    
                        currentPageIndex = (currentPageIndex + elements.Length) % elements.Length;
                        elements[currentPageIndex] = listToReverse[a];
                        currentPageIndex++;
                    }
    
                    currentPositionInElements = ((currentPositionInElements + length) + skipSize) % elements.Length;
                    skipSize++;
                }                
            }

            var denseHash = new List<int>();
            for (int i=0; i < elements.Length; i+= 16) 
            { 
                var subList = elements.ToList().GetRange(i, Math.Min(16, elements.Length - i)); 
                var sum = 0;
                foreach (int value in subList)
                {
                    sum ^= value;
                }

                denseHash.Add(sum);
            } 


            var hash = "";
            foreach(var n in denseHash) {
                hash += n.ToString("X").Length == 1 ? $"0{n.ToString("X")}" : n.ToString("X");
            }

            return hash.ToLower();
        }
    }
}

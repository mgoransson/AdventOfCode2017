using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day10
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input, Enumerable.Range(0, 256).ToArray()));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input, Enumerable.Range(0, 256).ToArray()));
        }

        public static string ReadInput() 
        {
            return File.ReadAllText(@"Inputs/Day10.input.txt");
        }

        public static int Part01(string input, int[] elementList)
        {
            var elements = (int[])elementList.Clone();
            var formattedInput = input.Split(",").Select(x => int.Parse(x)).ToArray();

            Hash(elements, formattedInput, 1);

            return elements[0] * elements[1];
        }

        public static string Part02(string input, int[] elementList)
        {
            var elements = (int[])elementList.Clone();

            var ascii = string.Join(",", input.Select(x => System.Convert.ToInt32(x)));
            ascii = string.IsNullOrEmpty(ascii) ? "17,31,73,47,23" : $"{ascii},17,31,73,47,23";
            var formattedAscii = ascii.Split(",").Select(x => int.Parse(x)).ToArray();
            
            Hash(elements, formattedAscii, 64);

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

            var knotHash = string.Join("", denseHash.Select(x => x.ToString("X").Length == 1 ? $"0{x.ToString("X")}" : x.ToString("X")));

            return knotHash.ToLower();
        }

        static void Hash(int[] elements, int[] input, int loopCount) 
        {
            var currentPositionInElements = 0;
            var skipSize = 0;
            
            for(var i = 0; i < loopCount; i++) 
            {
                foreach(var length in input) 
                {
                    var listToReverse = new List<int>();

                    var currentPageIndex = currentPositionInElements;
                    for(var a = 0; a < length; a++) 
                    {                    
                        currentPageIndex = (currentPageIndex + elements.Length) % elements.Length;
                        listToReverse.Add(elements[currentPageIndex]);
                        currentPageIndex++;
                    }

                    listToReverse.Reverse();

                    //Put back
                    currentPageIndex = currentPositionInElements;
                    for(var a = 0; a < listToReverse.Count; a++) 
                    {                    
                        currentPageIndex = (currentPageIndex + elements.Length) % elements.Length;
                        elements[currentPageIndex] = listToReverse[a];
                        currentPageIndex++;
                    }
    
                    currentPositionInElements = ((currentPositionInElements + length) + skipSize) % elements.Length;
                    skipSize++;
                }
            }
        }
    }
}

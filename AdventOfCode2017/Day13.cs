using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day13
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
            return File.ReadAllLines(@"Inputs/Day13.input.txt");
        }

        public static int Part01(string[] input) 
        {
            var layers = BuildLayers(input);

            var maxLayer = layers.OrderByDescending(x => x.Key).FirstOrDefault().Key;

            var packet = -1;
            var caugh = new Dictionary<int, Layer>();
            for(var i = 0; i <= maxLayer; i++) 
            {
                // Move packet
                packet++;

                // Check if caught
                var x = layers.GetValueOrDefault(packet);
                if(x != null && x.CurrentDepth == 1) 
                {
                    caugh.Add(packet, x);
                }

                // Move
                MoveScanners(layers);
            }

            var severity = 0;
            foreach(var c in caugh)
            {
                severity += (c.Key * c.Value.Depth);
            }

            return severity;
        }

        public static int Part02(string[] input) 
        {
            var layers = BuildLayers(input);
            var maxLayer = layers.OrderByDescending(x => x.Key).FirstOrDefault().Key;

            var packet = -1;
            var caught = false;

            var delay = 0;
            while(true) 
            {
                caught = false;
                packet = -1;

                var cpyLayers = layers.ToDictionary(k => k.Key, k => k.Value.Clone());
                for(var i = 0; i <= maxLayer; i++) 
                {
                    // Move packet
                    packet++;

                    // Check if caught
                    var x = cpyLayers.GetValueOrDefault(packet);
                    if(x != null && x.CurrentDepth == 1) 
                    {
                        caught = true;
                        break;
                    }

                    // Move
                    MoveScanners(cpyLayers);
                }

                if (!caught) 
                {
                    break;
                }

                delay++;

                MoveScanners(layers);
            }

            return delay;
        }

        static Dictionary<int, Layer> BuildLayers(string[] input) 
        {
            var layers = new Dictionary<int, Layer>();
            // Build
            foreach(var row in input) 
            {
                var splitted = row.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(splitted[0].Trim());
                var depth = int.Parse(splitted[1].Trim());

                layers.Add(id, new Layer() 
                    { 
                        Depth = depth,
                        CurrentDepth = 1, 
                        Direction = "Down" 
                    }
                );
            }
            return layers;
        }  

         static void MoveScanners(Dictionary<int, Layer> layers) 
         {
            foreach(var layer in layers) 
            {

                if (layer.Value.Direction == "Down") 
                {
                    layer.Value.CurrentDepth++;
                    if (layer.Value.CurrentDepth == layer.Value.Depth) 
                    {
                        layer.Value.Direction = "Up";
                    }
                } else {
                    layer.Value.CurrentDepth--;
                    if (layer.Value.CurrentDepth == 1) 
                    {
                        layer.Value.Direction = "Down";
                    }
                }
            }
        }
        
        class Layer {
            public int Depth { get; set; }
            public int CurrentDepth { get; set; }
            public string Direction { get; set; }

            public Layer Clone()
            {
                return new Layer() 
                {
                    Depth = this.Depth,
                    CurrentDepth = this.CurrentDepth,
                    Direction = this.Direction
                };
            }
        }

    }
}

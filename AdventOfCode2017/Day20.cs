using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day20
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
            return File.ReadAllLines(@"Inputs/Day20.input.txt");
        }

        public static int Part01(string[] input) 
        {
            var particles = new List<Particle>();
            for (var i = 0; i < input.Length; i++)
            {
                particles.Add(new Particle(input[i], i));
            }

            for (var i = 0; i < 1000; i++)
            {
                foreach (var particle in particles)
                {
                    particle.Update();
                }
            }

            var orderedDistances = particles.OrderBy(p => p.ManhattanDistance()).ToList();
            return orderedDistances[0].Id;
        }

        public static int Part02(string[] input) 
        {
            var particles = new List<Particle>();
            for (var i = 0; i < input.Length; i++)
            {
                particles.Add(new Particle(input[i], i));
            }

            for (var i = 0; i < 1000; i++)
            {
                foreach (var particle in particles)
                {
                    particle.Update();
                }

                RemoveCollided(ref particles);
            }

            return particles.Count;
        }

        private static void RemoveCollided(ref List<Particle> particles)
        {

            var collided = particles.GroupBy(x => $"{x.Position.X}{x.Position.Y}{x.Position.Z}")
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key).ToArray();

            foreach (string key in collided)
            {
                particles.RemoveAll(p => $"{p.Position.X}{p.Position.Y}{p.Position.Z}" == key);
            }            
        }

        class Particle
        {
            public int Id { get; set; }
            public Coordinates Position { get; set; }
            public Coordinates Velocity { get; set; }
            public Coordinates Acceleration { get; set; }

            public Particle(string particleLine, int id)
            {
                this.Id = id;
                this.Position = Parse(particleLine, "p");
                this.Velocity = Parse(particleLine, "v");
                this.Acceleration = Parse(particleLine, "a");
            }

            public void Update()
            {
                Velocity.X += Acceleration.X;
                Velocity.Y += Acceleration.Y;
                Velocity.Z += Acceleration.Z;

                Position.X += Velocity.X;
                Position.Y += Velocity.Y;
                Position.Z += Velocity.Z;
            }

            public long ManhattanDistance()
            {
                return Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
            }

            private Coordinates Parse(string input, string type)
            {
                var start = input.IndexOf(type + "=<") + 3;
                var end = input.IndexOf('>', start);
                var values = input.Substring(start, end - start).Split(',');
                return new Coordinates(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            }
        }

        class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public Coordinates(int x, int y, int z)            
            {
                this.X = x;
                this.Y = y;
                this.Z = z;                
            }
        }

    }
}

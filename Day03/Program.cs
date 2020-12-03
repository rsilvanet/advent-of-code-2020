using System;
using System.Linq;

namespace Day03
{
    public class Program
    {
        public static void Main(string[] _)
        {
            Console.WriteLine($"Part 1: {Part1()}");
            Console.WriteLine($"Part 2: {Part2()}");
            Console.ReadLine();
        }

        public static long Part1()
        {
            return CountTrees(3, 1);
        }

        public static long Part2()
        {
            return CountTrees(1, 1) * CountTrees(3, 1) * CountTrees(5, 1) * CountTrees(7, 1) * CountTrees(1, 2);
        }

        private static long CountTrees(int right, int down)
        {
            var x = right;
            var amountOfTrees = 0;

            for (var y = down; y < Input.Entries.Length; y += down)
            {
                var entry = Input.Entries.ElementAt(y);

                if (entry[x] == '#')
                {
                    amountOfTrees++;
                }

                x = (x + right) % entry.Length;
            }

            return amountOfTrees;
        }
    }
}

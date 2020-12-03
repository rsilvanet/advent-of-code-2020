using System;
using System.Linq;

namespace Day01
{
    public class Program
    {
        public static void Main(string[] _)
        {
            Console.WriteLine($"Part 1: {Part1()}");
            Console.WriteLine($"Part 2: {Part2()}");
            Console.ReadLine();
        }

        public static int Part1()
        {
            foreach (var entry1 in Input.Entries)
                foreach (var entry2 in Input.Entries)
                    if (CheckSum(entry1, entry2))
                        return Multiply(entry1, entry2);

            throw new Exception();
        }

        public static int Part2()
        {
            foreach (var entry1 in Input.Entries)
                foreach (var entry2 in Input.Entries)
                    foreach (var entry3 in Input.Entries)
                        if (CheckSum(entry1, entry2, entry3))
                            return Multiply(entry1, entry2, entry3);

            throw new Exception();
        }

        private static bool CheckSum(params int[] entries)
        {
            return entries.Sum() == 2020;
        }

        private static int Multiply(params int[] entries)
        {
            return entries.Aggregate((x, y) => x * y);
        }
    }
}

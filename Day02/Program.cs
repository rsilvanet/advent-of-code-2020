using System;
using System.Linq;

namespace Day02
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
            return Input.Entries.Where(x => new EntryDTO(x).IsValidForRange()).Count();
        }

        public static int Part2()
        {
            return Input.Entries.Where(x => new EntryDTO(x).IsValidForPosition()).Count();
        }

        public class EntryDTO
        {
            public EntryDTO(string entry)
            {
                var entryParts = entry.Split(":");
                var fullRule = entryParts.First();
                var ruleParts = fullRule.Split(" ");
                var ruleAmounts = ruleParts.First();
                var ruleAmountParts = ruleAmounts.Split("-");

                FirstNumber = int.Parse(ruleAmountParts.First());
                SecondNumber = int.Parse(ruleAmountParts.Last());
                Letter = char.Parse(ruleParts.Last());
                Password = entryParts.Last();
            }

            private int FirstNumber { get; set; }
            private int SecondNumber { get; set; }
            private char Letter { get; set; }
            private string Password { get; set; }

            public bool IsValidForRange()
            {
                var letterAmount = Password.Count(x => x == Letter);
                var isInsideRange = letterAmount >= FirstNumber && letterAmount <= SecondNumber;

                return isInsideRange;
            }

            public bool IsValidForPosition()
            {
                var firstPositionValid = Password[FirstNumber] == Letter;
                var secondPositionValid = Password[SecondNumber] == Letter;

                return firstPositionValid ^ secondPositionValid;
            }
        }
    }
}

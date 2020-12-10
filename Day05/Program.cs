using System;
using System.Linq;

namespace Day05
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
            return Input.Entries.Select(x => new EntryDTO(x).GetSeatId()).Max();
        }

        public static long Part2()
        {
            var orderedSeatIds = Input.Entries.Select(x => new EntryDTO(x).GetSeatId()).OrderBy(x => x);
            var previousSeatId = orderedSeatIds.First();

            foreach (var seatId in orderedSeatIds.Skip(1))
            {
                if (seatId - previousSeatId > 1)
                {
                    return previousSeatId + 1;
                }

                previousSeatId = seatId;
            }

            return 0;
        }

        public class EntryDTO
        {
            private readonly string _binarySeatValue;

            private readonly static int[] binaryValueMap = new int[] { 1, 2, 4, 8, 16, 32, 64 };

            public EntryDTO(string binarySeatValue)
            {
                _binarySeatValue = binarySeatValue;
            }

            public int GetSeatId()
            {
                var row = GetRow();
                var column = GetColumn();

                return (row * 8) + column;
            }

            private int GetRow()
            {
                var row = 0;
                var rowBinaryString = _binarySeatValue.Substring(0, 7);

                for (int i = 0; i < rowBinaryString.Count(); i++)
                {
                    if (rowBinaryString[i] == 'B')
                    {
                        row += binaryValueMap[rowBinaryString.Length - 1 - i];
                    }
                }

                return row;
            }

            private int GetColumn()
            {
                var column = 0;
                var columnBinaryString = _binarySeatValue.Substring(7, 3);

                for (int i = 0; i < columnBinaryString.Count(); i++)
                {
                    if (columnBinaryString[i] == 'R')
                    {
                        column += binaryValueMap[columnBinaryString.Length - 1 - i];
                    }
                }

                return column;
            }
        }
    }
}

using System.Text.RegularExpressions;

namespace AdventOfCode2025
{
    public static class Day6
    {
        public static string InputFile = "../../../Inputs/Day6Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 6 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 6 Challenge Complete.");
        }
        public static string Part1()
        {
            List<Col> cols = new List<Col>();
            foreach (var line in File.ReadLines(InputFile).Reverse())
            {
                var lineNormalized = Regex.Replace(line, " +", " ");
                var lineChars = lineNormalized.Trim().Split(" ");
                if (lineChars[0] == "+" || lineChars[0] == "*")
                {
                    foreach (var symbol in lineChars.Where(x => x != ""))
                    {
                        cols.Add(new Col { Action = symbol[0], Sum = symbol == "+" ? 0 : 1 });
                    }
                }
                else
                {
                    for (int i = 0; i < lineChars.Length; i++)
                    {
                        cols[i].Add(long.Parse(lineChars[i]));
                    }
                }
            }
            return "Part 1 Solution: " + cols.Sum(x => x.Sum);
        }
        public static string? Part2()
        {
            List<Col> cols = new List<Col>();
            char[][] grid = File.ReadAllLines(InputFile)
            .Select(line => line.ToCharArray())
            .ToArray();
            var colcounter = 0;
            for (int c = 0; c < grid[1].Length; c++)
            {
                if (c < grid[4].Length && (grid[4][c] == '+' || grid[4][c] == '*'))
                {
                    cols.Add(new Col { Action = grid[4][c], Sum = grid[4][c] == '+' ? 0 : 1 });
                }
                var num = $"{grid[0][c]}{grid[1][c]}{grid[2][c]}{grid[3][c]}";
                if (string.IsNullOrWhiteSpace(num))
                {
                    colcounter++;
                }
                else
                {
                    cols[colcounter].Add(long.Parse(num));
                }
            }
            return "Part 2 Solution: " + cols.Sum(x => x.Sum);
        }

        public class Col
        {
            public long Sum;
            public char Action;

            public void Add(long value)
            {
                if (Action == '+')
                {
                    Sum += value;
                }
                else if (Action == '*')
                {

                    Sum *= value;
                }
            }
        }
    }
}

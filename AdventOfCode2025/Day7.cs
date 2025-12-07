namespace AdventOfCode2025
{
    public static class Day7
    {
        public static string InputFile = "../../../Inputs/Day7Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 7 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 7 Challenge Complete.");
        }
        public static string Part1()
        {
            long splits = 0;
            char[][] grid = File.ReadAllLines(InputFile)
            .Select(line => line.ToCharArray())
            .ToArray();
            for (long r = 0; r < grid.Length; r++)
            {
                for (long c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 'S')
                    {
                        grid[r][c] = '|';
                    }
                    else if (grid[r][c] == '^' && grid[r - 1][c] == '|')
                    {
                        grid[r][c - 1] = '|';
                        grid[r][c + 1] = '|';
                        splits++;
                    }
                    else if (r != 0 && grid[r][c] == '.' && grid[r - 1][c] == '|')
                    {
                        grid[r][c] = '|';
                    }
                }
            }
            return "Part 1 Solution: " + splits;
        }
        public static string Part2()
        {
            string[][] grid = File.ReadAllLines(InputFile)
                .Select(line => line.Select(c => c.ToString()).ToArray())
                .ToArray();
            for (long r = 0; r < grid.Length; r++)
            {
                for (long c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == "S")
                    {
                        grid[r][c] = "1";
                    }
                    else if (grid[r][c] == "^" && long.TryParse(grid[r - 1][c], out long num))
                    {
                        if (grid[r][c - 1] == ".")
                        {
                            grid[r][c - 1] = num.ToString();
                        }
                        else
                        {
                            if (long.TryParse(grid[r][c - 1], out long leftNum))
                            {
                                grid[r][c - 1] = (leftNum + num).ToString();
                            }
                        }
                        if (grid[r][c + 1] == ".")
                        {
                            grid[r][c + 1] = num.ToString();
                        }
                        else
                        {
                            if (long.TryParse(grid[r][c + 1], out long rightNum))
                            {
                                grid[r][c + 1] = (rightNum + num).ToString();
                            }
                        }
                    }
                    else if (r != 0 && grid[r][c] == "." && long.TryParse(grid[r - 1][c], out long num2))
                    {
                        grid[r][c] = num2.ToString();
                    }
                    else if (r != 0 && long.TryParse(grid[r][c], out long current) && long.TryParse(grid[r - 1][c], out long prev))
                    {
                        grid[r][c] = (current + prev).ToString();
                    }
                }
            }
            long sum = 0;
            var lastLine = grid[grid.Length - 1];
            for (long i = 0; i < lastLine.Length; i++)
            {
                if (long.TryParse(lastLine[i], out long finalNum))
                {
                    sum += finalNum;
                }
            }
            return "Part 2 Solution: " + sum;
        }
    }
}

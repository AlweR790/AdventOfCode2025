namespace AdventOfCode2025
{
    public static class Day4
    {
        public static string InputFile = "../../../Inputs/Day4Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 4 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 4 Challenge Complete.");
        }
        public static string Part1()
        {
            char[][] grid = File.ReadAllLines(InputFile)
                .Select(line => line.ToCharArray())
                .ToArray();
            var deletable = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == '@')
                    {
                        if (IsDeletable(grid, r, c))
                        {
                            deletable++;
                            //grid[r][c] = 'x';
                        }
                    }
                }
            }
            return "Part 1 Solution: " + deletable; ;
        }


        public static string Part2()
        {
            char[][] grid = File.ReadAllLines(InputFile)
            .Select(line => line.ToCharArray())
            .ToArray();
            var deletable = 0;
            var lastDeleted = 0;
            do
            {
                lastDeleted = 0;
                for (int r = 0; r < grid.Length; r++)
                {
                    for (int c = 0; c < grid[r].Length; c++)
                    {
                        if (grid[r][c] == '@')
                        {
                            if (IsDeletable(grid, r, c))
                            {
                                lastDeleted++;
                                grid[r][c] = 'x';
                            }
                        }
                    }
                }
                deletable += lastDeleted;
            } while (lastDeleted > 0);
            return "Part 2 Solution: " + deletable;
        }

        public static bool IsDeletable(char[][] grid, int r, int c)
        {
            List<char> adjacent = new List<char>();
            if (r > 0)
            {
                adjacent.Add(grid[r - 1][c]); // Up
            }
            if (r < grid.Length - 1)
            {
                adjacent.Add(grid[r + 1][c]); // Down
            }
            if (c > 0)
            {
                adjacent.Add(grid[r][c - 1]); // Left
            }
            if (c < grid[r].Length - 1)
            {
                adjacent.Add(grid[r][c + 1]); // Right
            }
            if (r > 0 && c > 0)
            {
                adjacent.Add(grid[r - 1][c - 1]); // Up-Left
            }
            if (r > 0 && c < grid[r].Length - 1)
            {
                adjacent.Add(grid[r - 1][c + 1]); // Up-Right
            }
            if (r < grid.Length - 1 && c > 0)
            {
                adjacent.Add(grid[r + 1][c - 1]); // Down-Left
            }
            if (r < grid.Length - 1 && c < grid[r].Length - 1)
            {
                adjacent.Add(grid[r + 1][c + 1]); // Down-Right
            }
            if (adjacent.Where(x => x == '@').Count() > 3)
            {
                return false;
            }

            return true;
        }
    }
}

namespace AdventOfCode2025
{
    public static class Day1
    {
        public static string InputFile = "../../../Inputs/Day1Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 1 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 1 Challenge Complete.");
        }

        public static string Part1()
        {
            int zeroes = 0;
            short position = 50;

            foreach (var line in File.ReadLines(InputFile))
            {
                var direction = line[0] == 'R';
                var steps = int.Parse(line[1..]);
                position = Move(position, direction, steps, 0).Item1;
                if (position == 0) zeroes++;
            }

            return "Part 1 Solution:" + zeroes;
        }
        public static string Part2()
        {
            int zeroes = 0;
            short position = 50;
            foreach (var line in File.ReadLines(InputFile))
            {
                var direction = line[0] == 'R';
                var steps = int.Parse(line[1..]);
                var result = Move(position, direction, steps, zeroes);
                position = result.Item1;
                zeroes = result.Item2;
            }
            return "Part 2 Solution:" + zeroes;
        }

        public static (short, int) Move(short input, bool right, int positions, int zeroes)
        {
            while (positions > 0)
            {
                if (right)
                {
                    input++;
                    if (input > 99)
                    {
                        input = 0;
                    }
                }
                else
                {
                    input--;
                    if (input < 0)
                    {
                        input = 99;
                    }
                }
                positions--;
                if (input == 0)
                {
                    zeroes++;
                }
            }
            return (input, zeroes);
        }
    }
}

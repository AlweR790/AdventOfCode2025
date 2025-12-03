namespace AdventOfCode2025
{
    public static class Day3
    {
        public static string InputFile = "../../../Inputs/Day3Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 3 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 3 Challenge Complete.");
        }
        public static string Part1()
        {
            var finalSum = 0;
            foreach (var line in File.ReadAllLines(InputFile))
            {
                var numbers = line.Select(c => c.ToString()).ToArray();
                int[] ints = new int[numbers.Length];
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] = int.Parse(numbers[i]);
                }
                int largest = 0;
                int secondLargest = ints[^1];
                for (int i = 0; i < ints.Length - 1; i++)
                {
                    if (ints[i] > largest)
                    {
                        secondLargest = ints[^1];
                        largest = ints[i];
                    }
                    else if (ints[i] > secondLargest)
                    {
                        secondLargest = ints[i];
                    }
                }
                finalSum += (largest * 10) + secondLargest;
            }
            return "Part 1 Solution: " + finalSum;
        }
        public static string Part2()
        {
            // Implement Part 2 logic here
            return "Part 2 Solution: TBD";
        }
    }
}

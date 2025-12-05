namespace AdventOfCode2025
{
    public static class Day5
    {
        public static string InputFile = "../../../Inputs/Day5Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 5 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 5 Challenge Complete.");
        }
        public static string Part1()
        {
            List<Range> ranges = new List<Range>();
            List<long> valuesToCheck = new List<long>();
            bool afterBlank = false;
            foreach (var line in File.ReadLines(InputFile))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    afterBlank = true;
                    continue;
                }
                if (afterBlank)
                {
                    valuesToCheck.Add(long.Parse(line));
                }
                else
                {
                    var parts = line.Split('-');
                    ranges.Add(new Range
                    {
                        Start = long.Parse(parts[0]),
                        End = long.Parse(parts[1])
                    });
                }
            }
            int insideCount = 0;
            foreach (var value in valuesToCheck)
            {
                if (ranges.Any(r => r.IsInside(value)))
                {
                    insideCount++;
                }
            }
            return "Part 1 Solution: " + insideCount;
        }
        public static string? Part2()
        {
            List<Range> ranges = new List<Range>();
            List<long> freshes = new List<long>();

            foreach (var line in File.ReadLines(InputFile))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
                var parts = line.Split('-');
                var range = new Range
                {
                    Start = long.Parse(parts[0]),
                    End = long.Parse(parts[1])
                };
                var overlaps = ranges.Where(r => r.Overlaps(range)).ToList();

                if (overlaps.Count == 0)
                {
                    ranges.Add(range);
                }
                else
                {
                    foreach (var r in overlaps)
                    {
                        range.Start = Math.Min(range.Start, r.Start);
                        range.End = Math.Max(range.End, r.End);
                        ranges.Remove(r);
                    }

                    ranges.Add(range);
                }
            }
            var count = ranges.Sum(x => x.IdsCount());
            return "Part 2 Solution: " + count;
        }
        public class Range
        {
            public long Start { get; set; }
            public long End { get; set; }
            public bool IsInside(long value)
            {
                return value >= Start && value <= End;
            }
            public bool Overlaps(Range other)
            {
                return Start <= other.End && End >= other.Start;
            }
            public long IdsCount()
            {
                return End - Start + 1;
            }

        }
    }
}

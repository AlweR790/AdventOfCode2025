using System.Text.RegularExpressions;

namespace AdventOfCode2025
{
    public static class Day2
    {
        public static string InputFile = "../../../Inputs/Day2Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 2 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 2 Challenge Complete.");
        }

        public static string Part1()
        {
            long invalidsSum = 0;
            var ranges = File.ReadAllText(InputFile).Split(',');
            foreach (var range in ranges)
            {
                var bounds = range.Split('-');
                var r = new Range()
                {
                    Start = long.Parse(bounds[0]),
                    End = long.Parse(bounds[1])
                };
                r.CheckInvalids();
                invalidsSum += r.invalids.Sum();
            }
            return "Part 1 Solution:" + invalidsSum;
        }
        public static string Part2()
        {
            long invalidsSum = 0;
            var ranges = File.ReadAllText(InputFile).Split(',');
            foreach (var range in ranges)
            {
                var bounds = range.Split('-');
                var r = new Range()
                {
                    Start = long.Parse(bounds[0]),
                    End = long.Parse(bounds[1])
                };
                r.CheckInvalidPart2();
                invalidsSum += r.invalids.Sum();
            }
            return "Part 2 Solution:" + invalidsSum;
        }

        public class Range
        {
            public long Start { get; set; }
            public long End { get; set; }
            public List<long> invalids = new List<long>();
            public void CheckInvalids()
            {
                for (long i = Start; i <= End; i++)
                {
                    string iStr = i.ToString();
                    if (iStr.Length % 2 == 0)
                    {
                        if (iStr.Substring(0, iStr.Length / 2) == iStr.Substring(iStr.Length / 2))
                            invalids.Add(i);
                    }
                }
            }
            public void CheckInvalidPart2()
            {
                for (long i = Start; i <= End; i++)
                {
                    string iStr = i.ToString();
                    Regex regex = new Regex("^(.+)\\1+$");
                    Match match = regex.Match(iStr);
                    if (match.Success)
                    {
                        invalids.Add(i);
                    }
                }
            }
        }
    }
}

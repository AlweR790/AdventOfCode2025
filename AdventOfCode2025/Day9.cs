namespace AdventOfCode2025
{
    public static class Day9
    {
        public static string InputFile = "../../../Inputs/Day9Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 9 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 9 Challenge Complete.");
        }
        public static string Part1()
        {
            var points = File.ReadAllLines(InputFile)
                .Select(line =>
                {
                    var c = line.Split(',').Select(long.Parse).ToArray();
                    return new Point(c[0], c[1]);
                })
                .ToList();

            long maxArea = 0;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    long area = RectangleArea(points[i], points[j]);
                    if (area > maxArea)
                        maxArea = area;
                }
            }

            return "Part 1 Solution: " + maxArea;
        }
        public static string Part2()
        {
            // Placeholder for Part 2 logic
            return "Part 2 Solution: Not Implemented";
        }

        public class Point
        {
            public long X { get; set; }
            public long Y { get; set; }
            public Point(long x, long y)
            {
                X = x;
                Y = y;
            }
        }
        public static long RectangleArea(Point p1, Point p2)
        {
            long width = (int)Math.Abs(p1.X - p2.X) + 1;
            long height = (int)Math.Abs(p1.Y - p2.Y) + 1;
            return width * height;
        }
    }
}

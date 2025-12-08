namespace AdventOfCode2025
{
    public static class Day8
    {
        public static string InputFile = "../../../Inputs/Day8Input.txt";
        public static void Run()
        {
            Console.WriteLine("Running Day 8 Challenge...");
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.WriteLine("Day 8 Challenge Complete.");
        }
        public static string Part1()
        {
            List<Point> points = new List<Point>();
            List<List<Point>> components = new List<List<Point>>();
            foreach (var line in File.ReadAllLines(InputFile))
            {
                var coords = line.Split(',').Select(long.Parse).ToArray();
                points.Add(new Point(coords[0], coords[1], coords[2]));
            }
            var distanceMap = new Dictionary<(Point, Point), long>();

            foreach (var point in points)
            {
                foreach (var otherPoint in points)
                {
                    if (point != otherPoint)
                    {
                        distanceMap[(point, otherPoint)] = EuclideanDistance(point, otherPoint);
                    }
                }
            }
            distanceMap.OrderBy(kv => kv.Value);
            while (points.Any(p => !p.IsConnected))
            {
                while (distanceMap.Any())
                {
                    var kvp = distanceMap.First();
                    var p1 = kvp.Key.Item1;
                    var p2 = kvp.Key.Item2;
                    if (!p1.IsConnected || !p2.IsConnected)
                    {
                        distanceMap.Remove(kvp.Key);
                        if (!p1.IsConnected && !p2.IsConnected)
                        {
                            components.Add(new List<Point> { p1, p2 });
                        }
                        else if (p1.IsConnected && !p2.IsConnected)
                        {
                            var comp = components.First(c => c.Any(p => p.ID == p1.ID));
                            comp.Add(p2);
                        }
                        else if (!p1.IsConnected && p2.IsConnected)
                        {
                            var comp = components.First(c => c.Any(p => p.ID == p2.ID));
                            comp.Add(p1);
                        }
                        points.First(p => p.ID == p1.ID).IsConnected = true;
                        points.First(p => p.ID == p2.ID).IsConnected = true;
                        break;
                    }
                    distanceMap.Remove(kvp.Key);
                }
            }
            components.OrderByDescending(c => c.Count);
            var sum = components[0].Count() * components[1].Count() * components[2].Count();
            return "Part 1 Solution: " + sum;
        }
        public static string Part2()
        {
            // Implement Part 2 logic here
            return "Part 2 Solution: ";
        }

        public class Point
        {
            public int ID { get; set; }
            public long X { get; set; }
            public long Y { get; set; }
            public long Z { get; set; }
            public bool IsConnected { get; set; } = false;
            public Point(long x, long y, long z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
        public static long EuclideanDistance(Point p1, Point p2)
        {
            return (long)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2) + Math.Pow(p2.Z - p1.Z, 2));
        }
    }
}

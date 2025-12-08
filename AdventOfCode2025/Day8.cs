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
            List<List<int>> components = new List<List<int>>();
            int c = 0;
            foreach (var line in File.ReadAllLines(InputFile))
            {
                var coords = line.Split(',').Select(long.Parse).ToArray();
                points.Add(new Point(c++, coords[0], coords[1], coords[2]));
            }
            var distanceMap = new Dictionary<(int, int), long>();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var p1 = points[i];
                    var p2 = points[j];
                    distanceMap[(p1.ID, p2.ID)] = EuclideanDistance(p1, p2);
                }
            }
            var orderedMap = distanceMap.ToList().OrderBy(kv => kv.Value).ToList();
            for (int i = 0; i < 1000; i++)
            {
                var pair = orderedMap[i];
                var p1 = points.Find(p => p.ID == pair.Key.Item1)!;
                var p2 = points.Find(p => p.ID == pair.Key.Item2)!;

                var comp1 = components.Find(comp => comp.Contains(p1.ID));
                var comp2 = components.Find(comp => comp.Contains(p2.ID));

                if (comp1 == null && comp2 == null)
                {
                    components.Add(new List<int> { p1.ID, p2.ID });
                }
                else if (comp1 != null && comp2 == null)
                {
                    if (!comp1.Contains(p2.ID))
                        comp1.Add(p2.ID);
                }
                else if (comp1 == null && comp2 != null)
                {
                    if (!comp2.Contains(p1.ID))
                        comp2.Add(p1.ID);
                }
                else if (comp1 != comp2)
                {
                    foreach (var id in comp2)
                        if (!comp1.Contains(id))
                            comp1.Add(id);

                    components.Remove(comp2);
                }
            }

            components = components.OrderByDescending(c => c.Count).ToList();
            var sum = components[0].Count() * components[1].Count() * components[2].Count();
            return "Part 1 Solution: " + sum;
        }
        public static string Part2()
        {
            List<Point> points = new List<Point>();
            List<List<int>> components = new List<List<int>>();
            int c = 0;
            foreach (var line in File.ReadAllLines(InputFile))
            {
                var coords = line.Split(',').Select(long.Parse).ToArray();
                points.Add(new Point(c++, coords[0], coords[1], coords[2]));
            }
            var distanceMap = new Dictionary<(int, int), long>();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var p1 = points[i];
                    var p2 = points[j];
                    distanceMap[(p1.ID, p2.ID)] = EuclideanDistance(p1, p2);
                }
            }
            var orderedMap = distanceMap.ToList().OrderBy(kv => kv.Value).ToList();
            bool keepConnecting = true;
            var lastPair = new ValueTuple<Point, Point>();
            int y = 0;
            while (keepConnecting)
            {
                var pair = orderedMap[y++];
                var p1 = points.Find(p => p.ID == pair.Key.Item1)!;
                var p2 = points.Find(p => p.ID == pair.Key.Item2)!;

                var comp1 = components.Find(comp => comp.Contains(p1.ID));
                var comp2 = components.Find(comp => comp.Contains(p2.ID));

                bool merged = false;

                if (comp1 == null && comp2 == null)
                {
                    components.Add(new List<int> { p1.ID, p2.ID });
                    merged = true;
                }
                else if (comp1 != null && comp2 == null)
                {
                    if (!comp1.Contains(p2.ID))
                    {
                        comp1.Add(p2.ID);
                        merged = true;
                    }
                }
                else if (comp1 == null && comp2 != null)
                {
                    if (!comp2.Contains(p1.ID))
                    {
                        comp2.Add(p1.ID);
                        merged = true;
                    }
                }
                else if (comp1 != null && comp2 != null && comp1 != comp2)
                {
                    foreach (var id in comp2)
                        if (!comp1.Contains(id))
                            comp1.Add(id);

                    components.Remove(comp2);
                    merged = true;
                }

                if (merged)
                    lastPair = (p1, p2);

                if (components.Count == 1 && components[0].Count == points.Count)
                    keepConnecting = false;
            }

            long prod = lastPair.Item1.X * lastPair.Item2.X;
            return "Part 2 Solution: " + prod;
        }

        public class Point
        {
            public int ID { get; set; }
            public long X { get; set; }
            public long Y { get; set; }
            public long Z { get; set; }
            public bool IsConnected { get; set; } = false;
            public Point(int id, long x, long y, long z)
            {
                ID = id;
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

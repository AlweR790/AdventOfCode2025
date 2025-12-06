public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2025");
        Console.WriteLine("-------------------");
    DaySelect:
        Console.WriteLine("Select day to run :");
        switch (Console.ReadLine())
        {
            case "1":
                AdventOfCode2025.Day1.Run();
                break;
            case "2":
                AdventOfCode2025.Day2.Run();
                break;
            case "3":
                AdventOfCode2025.Day3.Run();
                break;
            case "4":
                AdventOfCode2025.Day4.Run();
                break;
            case "5":
                AdventOfCode2025.Day5.Run();
                break;
            case "6":
                AdventOfCode2025.Day6.Run();
                break;
            default:
                Console.WriteLine("Invalid day selected. Please try again."); break;
        }
        Console.WriteLine("-------------------");
        goto DaySelect; // :)) 292
    }
}
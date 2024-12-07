namespace AoC2024;

class Program
{
    static void Main(string[] args)
    {
        // var input = File.ReadAllLines("Inputs/day2.txt");
        // var day2 = new Day2();
        // day2.GetSafeReports(input);
        
        // var input = File.ReadAllText("Inputs/day3.txt");
        // var day3 = new Day3();
        // day3.GetSum(input);

        // Part 1
        // var input = File.ReadAllLines("Inputs/day4.txt");
        // var chars = input.Select(l => l.ToCharArray()).ToArray();
        // var day4 = new Day4();
        // day4.FindXmas(chars);
        
        // Part 2
        // day4.FindMasX(chars);
        
        // Part 1
        var input = File.ReadAllLines("Inputs/day6.txt");
        var chars = input.Select(l => l.ToArray()).ToArray();
        var day6  = new Day6();
        day6.FindGuardsMovement(chars);
        
    }
}
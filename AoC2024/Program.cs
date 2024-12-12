namespace AoC2024;

class Program
{
    static void Main(string[] args)
    {
        // Day 2
        // var input = File.ReadAllLines("Inputs/day2.txt");
        // var day2 = new Day2();
        // day2.GetSafeReports(input);
        
        // Day 3 
        // var input = File.ReadAllText("Inputs/day3.txt");
        // var day3 = new Day3();
        // day3.GetSum(input);

        // Day 4 - Part 1
        // var input = File.ReadAllLines("Inputs/day4.txt");
        // var chars = input.Select(l => l.ToCharArray()).ToArray();
        // var day4 = new Day4();
        // day4.FindXmas(chars);
        
        // Day 4 - Part 2
        // day4.FindMasX(chars);
        
        // Day 6 - Part 1
        // var input = File.ReadAllLines("Inputs/day6.txt");
        // var chars = input.Select(l => l.ToArray()).ToArray();
        // var day6  = new Day6();
        // day6.FindGuardsMovement(chars);
        
        // Day7 - Part 1 & 2
        // var input = File.ReadAllLines("Inputs/day7.txt");
        // var day7 = new Day7();
        // day7.SolveEquations(input);
        
        // Day9 - Part 1
        var input = File.ReadAllText("Inputs/day9.txt").ToArray().Select(c => int.Parse(c.ToString())).ToArray();
        var day9 = new Day9();
        // day9.GetChecksum(input);
        
        // Day9 - Part 2
        day9.GetChecksumPart2(input);
    }
}
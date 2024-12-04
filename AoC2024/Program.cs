namespace AoC2024;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllLines("Inputs/day2.txt");
        var day2 = new Day2();
        day2.GetSafeReports(input);
    }
}
using System.Text.RegularExpressions;

namespace AoC2024;

public class Day3
{
    public void GetSum(string input)
    {
        var enabled = true;
        var regex = new Regex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)|do\(\)|don't\(\)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        var matches = regex.Matches(input).ToList();
        long sum = 0;
        foreach (var match in matches)
        {
            // Console.WriteLine(match.ToString());
            if (match.ToString() == "do()")
            {
                enabled = true;
                continue;
            }

            if (match.ToString() == "don't()")
            {
                enabled = false;
                continue;
            }

            if (!enabled)
            {
                continue;
            }
            
            // foreach (Group group in match.Groups)
            // {
            //     Console.WriteLine(group.Value);
            // }
            //
            sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        }
        
        Console.WriteLine(sum);
    }
}
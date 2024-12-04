namespace AoC2024;

public class Day2
{
    public void GetSafeReports(string[] input)
    {
        var safeReports = 0;
        foreach (var report in input)
        {
            var levels = report.Split(" ").Select(int.Parse).ToList();
            var result = CheckReport(levels);
            if (result == -1)
            {
                safeReports++;
                continue;
            }

            if (BruteForce(levels))
            {
                safeReports++;
            }

            // var removedNumber = levels[result];
            // var removedIndex = result;
            // levels.RemoveAt(result);
            // result = CheckReport(levels);
            // if (result == -1)
            // {
            //     safeReports++;
            //     continue;
            // }
            //
            // levels.Insert(removedIndex, removedNumber);
            // levels.RemoveAt(0);
            // result = CheckReport(levels);
            // if (result == -1)
            // {
            //     safeReports++;
            // }
        }
        
        
        Console.WriteLine(safeReports);
    }

    private int CheckReport(List<int> levels)
    {
        var direction = levels[0] > levels[1] ? Directions.Decrease : Directions.Increase;
            
        var previousLevel = levels[0];
        for (int i = 1; i < levels.Count; i++)
        {
            var currentLevel = levels[i];
            var currentDirection = previousLevel > currentLevel ? Directions.Decrease : Directions.Increase;
            if (currentDirection != direction || !IsSafeDiff(previousLevel, currentLevel))
            {
                return i;
            }
            
            previousLevel = currentLevel;
        }

        return -1;
    }

    private bool BruteForce(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var temp = new List<int>(levels);
            temp.RemoveAt(i);
            var result = CheckReport(temp);
            if (result == -1)
            {
                return true;
            }
        }

        return false;
    }
    
    private static bool IsSafeDiff(int a, int b)
    {
        var diff = Math.Abs(a - b);
        return diff is >= 1 and <= 3;
    }
    
    public enum Directions
    {
        Increase,
        Decrease,
    }
}
namespace AoC2024;

public class Day7
{
    public void SolveEquations(string[] input)
    {
        long result = 0;
        foreach (var equation in input)
        {
            var parts = equation.Split(':');
            var expectedResult = long.Parse(parts[0]);
            var numbers = parts[1].TrimStart().Split(' ').Select(n => long.Parse(n)).ToArray();
            if (CanSolve(expectedResult, numbers, 0, numbers[0]))
            {
                result += expectedResult;
            }
        }
        
        Console.WriteLine(result);
    }

    private bool CanSolve(long expectedResult, long[] numbers, int currentIndex, long currentResult)
    {
        if (expectedResult < currentResult)
        {
            return false;
        }

        if (currentIndex == numbers.Length - 1)
        {
            return expectedResult == currentResult;
        }

        if (CanSolve(expectedResult, numbers, currentIndex + 1, currentResult + numbers[currentIndex + 1]))
        {
            return true;
        }
        
        if (CanSolve(expectedResult, numbers, currentIndex + 1, currentResult * numbers[currentIndex + 1]))
        {
            return true;
        }
        
        if (CanSolve(expectedResult, numbers, currentIndex + 1, long.Parse($"{currentResult}{numbers[currentIndex + 1]}")))
        {
            return true;
        }

        return false;
    }
}
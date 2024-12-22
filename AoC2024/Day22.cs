namespace AoC2024;

public class Day22
{
    private readonly int _iterations = 2000;
    
    public void GetSumOfSecretNumbers(string[] input)
    {
        long result = 0;
        foreach (var secretNumber in input)
        {
            result += GetNextPrice(long.Parse(secretNumber), _iterations);
        }
        
        Console.WriteLine(result);
    }

    public void Part2(string[] input)
    {
        var summarizedBuyingOptions = new Dictionary<string, long>();
        foreach (var secretNumber in input)
        {
            var prices = Prices(long.Parse(secretNumber)).ToArray();
            var uniqueSequences = new List<string>();
            for (var i = 5; i < prices.Length; i++)
            {
                var part = prices[(i - 5)..i];
                var sequence = string.Join(",", part.Zip(part.Skip(1)).Select(t => t.Second - t.First).ToArray());
                if (!uniqueSequences.Contains(sequence))
                {
                    summarizedBuyingOptions[sequence] = summarizedBuyingOptions.GetValueOrDefault(sequence) + part.Last();
                    uniqueSequences.Add(sequence);
                }
            }
        }

        var max = summarizedBuyingOptions.Values.Max();
        
        Console.WriteLine(max);
    }

    private IEnumerable<long> Prices(long secretNumber)
    {
        yield return secretNumber % 10;

        for (int i = 0; i < _iterations; i++)
        {
            secretNumber = GetNextPrice(secretNumber, 1);
            yield return secretNumber % 10;
        }
    }
    
    public long GetNextPrice(long secretNumber, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            var tempValue = secretNumber * 64;
            secretNumber = Mix(secretNumber, tempValue);
            secretNumber = Prune(secretNumber);

            tempValue = long.Parse(Math.Floor((double)secretNumber / 32).ToString());
            secretNumber = Mix(secretNumber, tempValue);
            secretNumber = Prune(secretNumber);

            tempValue = secretNumber * 2048;
            secretNumber = Mix(secretNumber, tempValue);
            secretNumber = Prune(secretNumber);
        }

        return secretNumber;

    }

    private long Mix(long secretNumber, long currentValue)
    {
        return secretNumber ^ currentValue;
    }

    private long Prune(long secretNumber)
    {
        return secretNumber % 16777216;
    }
}
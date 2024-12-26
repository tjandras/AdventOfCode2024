namespace AoC2024;

public class Day1
{
    public void CountDistance(string[] input)
    {
        var (leftList, rightList) = ParseLists(input);

        leftList.Sort();
        rightList.Sort();

        var sum = 0;

        for (int i = 0; i < leftList.Count; i++)
        {
            sum += Math.Abs(leftList[i] - rightList[i]);
        }
        
        Console.WriteLine(sum);
    }

    public void GetSimilarityScore(string[] input)
    {
        var (leftList, rightList) = ParseLists(input);
        var similarity = 0;
        
        foreach (var number in leftList)
        {
            similarity += number * rightList.Count(x => x == number);
        }
        
        Console.WriteLine(similarity);
    }

    private (List<int> leftList, List<int> rightList) ParseLists(string[] input)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var line in input)
        {
            var numbers = line.Split("   ");
            leftList.Add(int.Parse(numbers.First()));
            rightList.Add(int.Parse(numbers.Last()));
        }
        
        return (leftList, rightList);
    }
}
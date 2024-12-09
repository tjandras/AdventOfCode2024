namespace AoC2024;

public class Day9
{
    public void GetChecksum(int[] input)
    {
        long checksum = 0;

        var backPosition = input.Length - 1;
        var largestId = (int)Math.Floor(backPosition / 2.0);
        var largestIdSize = input.Last();
        var currentId = 0;
        var expandedPosition = 0;

        for (int i = 0; i < backPosition; i++)
        {
            var size = input[i];
            
            if (i % 2 == 0) // File
            {
                for (int j = 0; j < size; j++)
                {
                    var subResult = expandedPosition++ * currentId;
                    checksum += subResult;
                }
            }
            else // Space
            {
                currentId++;
                while (size > 0)
                {
                    var subResult = expandedPosition++ * largestId;
                    checksum += subResult;

                    largestIdSize--;
                    size--;

                    if (largestIdSize == 0)
                    {
                        largestId--;
                        backPosition -= 2;
                        largestIdSize = input[backPosition];

                        if (backPosition < i)
                        {
                            break;
                        }
                    }
                }
            }
        }

        while (largestIdSize > 0)
        {
            var subResult = expandedPosition++ * largestId;
            checksum += subResult;
            largestIdSize--;
        }

        Console.WriteLine(checksum);
    }
}
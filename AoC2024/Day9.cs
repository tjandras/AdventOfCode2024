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

    public void GetChecksumPart2(int[] input)
    {
        var data = new List<(int size, int id)>();
        var id = 0;
        for (var i = 0; i < input.Length; i++)
        {
            data.Add((input[i], i % 2 == 0 ? id++ : -1));
        }
        
        long checksum = 0;

        var backPosition = data.Count - 1;

        for (; backPosition >= 0; backPosition -= 2)
        {
            var item = data[backPosition];
            for (var j = 1; j < backPosition; j += 2)
            {
                var size = data[j].size;
                if (size >= item.size)
                {
                    data[j] = (0, -1);
                    data.Insert(j + 1, (item.size, item.id));
                    data.Insert(j + 2, (size > item.size ? size - item.size : 0, -1));
                    backPosition += 2;

                    var space = data[backPosition - 1];
                    space.size += item.size;
                    if (backPosition + 1 < data.Count)
                    {
                        space.size += data[backPosition + 1].size;
                        data.RemoveAt(backPosition + 1);
                    }

                    data[backPosition - 1] = space;
                    data.RemoveAt(backPosition);
                    
                    break;
                }
            }
        }

        var position = 0;
        for (var i = 0; i < data.Count; i++)
        {
            var item = data[i];
            
            if (i % 2 != 0)
            {
                position += item.size;
                continue;
            }

            for (var j = 0; j < item.size; j++)
            {
                var subResult = position++ * item.id;
                checksum += subResult;
            }
        }
        
        Console.WriteLine(checksum);
    }
}
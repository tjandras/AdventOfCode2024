namespace AoC2024;

public class Day6
{
    private char[][] _input;
    public void FindGuardsMovement(char[][] input)
    {
        _input = input;
        
        // Find guard
        var guardX = 0;
        var guardY = 0;
        var guardDirection = '^';
        bool guardFound = false;
        for (; guardX < input.Length; guardX++)
        {
            for (guardY = 0; guardY < input[guardX].Length; guardY++)
            {
                if (input[guardX][guardY] == '^')
                {
                    guardFound = true;
                    break;
                }
            }

            if (guardFound)
            {
                break;
            }
        }
        
        // Find guard's path
        var distinctPositions = 0;
        var finished = false;
        while (true)
        {
            Console.WriteLine($"Guard position: {guardX}, {guardY}; Direction: {guardDirection}; Distinct positions: {distinctPositions}");
            switch (guardDirection)
            {
                case '^':
                    if (guardX - 1 < 0) // leaves the board at the top
                    {
                        finished = true;
                        distinctPositions++;
                        Console.WriteLine("Leaves at top");
                    }
                    else if (input[guardX - 1][guardY] == '#')
                    {
                        Turn(guardX, guardY, guardDirection = '>');
                    }
                    else if (input[guardX - 1][guardY] != 'X')
                    {
                        input[guardX - 1][guardY] = 'X';
                        distinctPositions++;
                        guardX--;
                        Console.WriteLine("Moved up");
                    }
                    else
                    {
                        guardX--;
                    }
                    
                    break;
                case '>':
                    if (guardY + 1 < 0)
                    {
                        finished = true;
                        distinctPositions++;
                        Console.WriteLine("Leaves at right side");
                    }
                    else if (input[guardX][guardY + 1] == '#')
                    {
                        Turn(guardX, guardY, guardDirection = 'v');
                    }
                    else if (input[guardX][guardY + 1] != 'X')
                    {
                        input[guardX][guardY + 1] = 'X';
                        distinctPositions++;
                        guardY++;
                        Console.WriteLine("Moved right");
                    }
                    else
                    {
                        guardY++;
                    }
                    
                    break;
                case 'v':
                    if (guardX + 1 > input.Length - 1)
                    {
                        finished = true;
                        distinctPositions++;
                        Console.WriteLine("Leaves at bottom");
                    }
                    else if (input[guardX + 1][guardY] == '#')
                    {
                        Turn(guardX, guardY, guardDirection = '<');
                    }
                    else if (input[guardX + 1][guardY] != 'X')
                    {
                        input[guardX + 1][guardY] = 'X';
                        distinctPositions++;
                        guardX++;
                        Console.WriteLine("Moved down");
                    }
                    else
                    {
                        guardX++;
                    }

                    break;
                case '<':
                    if (guardY - 1 < 0) // leaves the board at the top
                    {
                        finished = true;
                        distinctPositions++;
                        Console.WriteLine("Leaves at the left side");
                    }
                    else if (input[guardX][guardY - 1] == '#')
                    {
                        Turn(guardX, guardY, guardDirection = '^');
                    }
                    else if (input[guardX][guardY - 1] != 'X')
                    {
                        input[guardX][guardY - 1] = 'X';
                        distinctPositions++;
                        guardY--;
                        Console.WriteLine("Moved left");
                    }
                    else
                    {
                        guardY--;
                    }

                    break;
            }

            if (finished)
            {
                break;
            }
        }
        
        Console.WriteLine(distinctPositions);
    }

    private void Turn(int x, int y, char direction)
    {
        _input[x][y] = direction;
        Console.WriteLine("Turned to " + direction);
    }
}
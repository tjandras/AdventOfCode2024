namespace AoC2024;

public class Day4
{
    private char[][] _input;

    public void FindXmas(char[][] input)
    {
        var result = 0;
        _input = input;
        for (var column = 0; column < input.Length; column++)
        {
            for (var row = 0; row < input[column].Length; row++)
            {
                if (input[column][row] is 'X')
                {
                    if (FindInLine(column, row))
                    {
                        result++;
                    }
                    
                    if (FindBackInLine(column, row))
                    {
                        result++;
                    }
                    
                    if (FindUp(column, row))
                    {
                        result++;
                    }
                    
                    if (FindDown(column, row))
                    {
                        result++;
                    }
                    
                    if (FindUpForward(column, row))
                    {
                        result++;
                    }
                    
                    if (FindUpBackward(column, row))
                    {
                        result++;
                    }
                    
                    if (FindDownForward(column, row))
                    {
                        result++;
                    }
                    
                    if (FindDownBackward(column, row))
                    {
                        result++;
                    }
                }
            }
        }
        
        Console.WriteLine(result);
    }
    
    private bool FindInLine(int column, int row)
    {
        if (column + 3 >= _input.Length)
        {
            return false;
        }

        if (_input[column + 1][row] is not 'M')
        {
            return false;
        }

        if (_input[column + 2][row] is not 'A')
        {
            return false;
        }
        
        if (_input[column + 3][row] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindBackInLine(int column, int row)
    {
        if (column - 3 < 0)
        {
            return false;
        }

        if (_input[column - 1][row] is not 'M')
        {
            return false;
        }

        if (_input[column - 2][row] is not 'A')
        {
            return false;
        }
        
        if (_input[column - 3][row] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindUp(int column, int row)
    {
        if (row - 3 < 0)
        {
            return false;
        }

        if (_input[column][row - 1] is not 'M')
        {
            return false;
        }

        if (_input[column][row - 2] is not 'A')
        {
            return false;
        }
        
        if (_input[column][row - 3] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindDown(int column, int row)
    {
        if (row + 3 >= _input[column].Length)
        {
            return false;
        }

        if (_input[column][row + 1] is not 'M')
        {
            return false;
        }

        if (_input[column][row + 2] is not 'A')
        {
            return false;
        }
        
        if (_input[column][row + 3] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindUpForward(int column, int row)
    {
        if (row - 3 < 0 || column + 3 >= _input.Length)
        {
            return false;
        }

        if (_input[column + 1][row - 1] is not 'M')
        {
            return false;
        }

        if (_input[column + 2][row - 2] is not 'A')
        {
            return false;
        }
        
        if (_input[column + 3][row - 3] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindUpBackward(int column, int row)
    {
        if (row - 3 < 0 || column - 3 < 0)
        {
            return false;
        }

        if (_input[column - 1][row - 1] is not 'M')
        {
            return false;
        }

        if (_input[column - 2][row - 2] is not 'A')
        {
            return false;
        }
        
        if (_input[column - 3][row - 3] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindDownForward(int column, int row)
    {
        if (row + 3 >= _input[column].Length || column + 3 >= _input.Length)
        {
            return false;
        }

        if (_input[column + 1][row + 1] is not 'M')
        {
            return false;
        }

        if (_input[column + 2][row + 2] is not 'A')
        {
            return false;
        }
        
        if (_input[column + 3][row + 3] is not 'S')
        {
            return false;
        }

        return true;
    }
    
    private bool FindDownBackward(int column, int row)
    {
        if (row + 3 >= _input[column].Length || column - 3 < 0)
        {
            return false;
        }

        if (_input[column - 1][row + 1] is not 'M')
        {
            return false;
        }

        if (_input[column - 2][row + 2] is not 'A')
        {
            return false;
        }
        
        if (_input[column - 3][row + 3] is not 'S')
        {
            return false;
        }

        return true;
    }
}
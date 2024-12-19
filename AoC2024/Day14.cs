namespace AoC2024;

public class Day14
{
    private int _width = 101;
    private int _height = 103;
    private int _numberOfRounds = 100;

    public void GetSafetyNumber(string[] input)
    {
        var robots = new List<Robot>();
        foreach (var line in input)
        {
            var parts = line.Split(' ');
            var position = parts[0].Split('=').Last().Split(',');
            var velocity = parts[1].Split('=').Last().Split(',');
            robots.Add(new Robot
            {
                PositionX = int.Parse(position[0]),
                PositionY = int.Parse(position[1]),
                VelocityX = int.Parse(velocity[0]),
                VelocityY = int.Parse(velocity[1]),
            });
        }

        foreach (var robot in robots)
        {
            // Console.WriteLine($"{robot.PositionX}, {robot.PositionY}, {robot.VelocityX}, {robot.VelocityY}");
            var absoluteDisplacementX = robot.VelocityX * _numberOfRounds % _width;
            if (robot.PositionX + absoluteDisplacementX >= _width)
            {
                robot.PositionX = (robot.PositionX + absoluteDisplacementX) % _width;
            }
            else if (robot.PositionX + absoluteDisplacementX < 0)
            {
                robot.PositionX = _width - (Math.Abs(absoluteDisplacementX) - robot.PositionX);
            }
            else
            {
                robot.PositionX += absoluteDisplacementX;
            }
            
            var absoluteDisplacementY = robot.VelocityY * _numberOfRounds % _height;
            if (robot.PositionY + absoluteDisplacementY >= _height)
            {
                robot.PositionY = (robot.PositionY + absoluteDisplacementY) % _height;
            }
            else if (robot.PositionY + absoluteDisplacementY < 0)
            {
                robot.PositionY = _height - (Math.Abs(absoluteDisplacementY) - robot.PositionY);
            }
            else
            {
                robot.PositionY += absoluteDisplacementY;
            }
            
            // var diffX = (robot.VelocityX * _numberOfRounds + robot.PositionX) % _width;
            // robot.PositionX = diffX;
            // var diffY = (robot.VelocityY * _numberOfRounds + robot.PositionY) % _height;
            // robot.PositionY += diffY;
            //
            // Console.WriteLine(diffX + " " + diffY);

            Console.WriteLine($"Robot: {robot.PositionX}, {robot.PositionY}");
        }

        var board = new int[_width, _height];
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                board[i, j] = 0;
            }
        }
        foreach (var robot in robots)
        {
            board[robot.PositionX,robot.PositionY]++;
        }

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Console.Write(board[i,j]);
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
        
        var middleX = (_width - 1) / 2;
        var middleY = (_height - 1) / 2;
        
        Console.WriteLine($"Middle: {middleX}, {middleY}");

        var tlQuadrantRobotCount = robots.Count(r => r.PositionX < middleX && r.PositionY < middleY);
        var trQuadrantRobotCount = robots.Count(r => r.PositionX > middleX && r.PositionY < middleY);
        var blQuadrantRobotCount = robots.Count(r => r.PositionX < middleX && r.PositionY > middleY);
        var brQuadrantRobotCount = robots.Count(r => r.PositionX > middleX && r.PositionY > middleY);
        Console.WriteLine(tlQuadrantRobotCount);
        Console.WriteLine(trQuadrantRobotCount);
        Console.WriteLine(blQuadrantRobotCount);
        Console.WriteLine(brQuadrantRobotCount);
        
        Console.WriteLine(tlQuadrantRobotCount * trQuadrantRobotCount * blQuadrantRobotCount * brQuadrantRobotCount);
        
    }
}

public class Robot
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    
    public int VelocityX { get; set; }
    public int VelocityY { get; set; }
}
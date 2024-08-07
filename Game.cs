using System.Drawing;

enum MapCell
{
    None,
    Wall,
}

class Game
{
    Point PlayerPos;
    Point MapSize;
    readonly MapCell[,] Map;

    public Game(int mapSizeX, int mapSizeY, Point[] walls)
    {
        MapSize = new Point(mapSizeX, mapSizeY);
        Map = new MapCell[mapSizeX, mapSizeY];
        InitMap(walls);

        PlayerPos = new Point(0, 0);
    }

    // TODO: add openable doors!
    private void InitMap(Point[] walls)
    {
        foreach (Point wall in walls)
        {
            Map[wall.Y, wall.X] = MapCell.Wall;
        }
    }

    // TODO: add colors!
    public void Render()
    {
        Char[,] buffer = new Char[MapSize.Y, MapSize.X];

        Console.Clear();

        for (int y = 0; y < MapSize.Y; y++)
        {
            for (int x = 0; x < MapSize.X; x++)
            {
                if (Map[y, x] == MapCell.Wall)
                {
                    buffer[y, x] = '#';
                }
                else
                {
                    buffer[y, x] = '.';
                }
            }
        }

        // TODO: handle invalid player position
        buffer[PlayerPos.Y, PlayerPos.X] = '@';

        for (int y = 0; y < MapSize.Y; y++)
        {
            for (int x = 0; x < MapSize.X; x++)
            {
                Console.Write(buffer[y, x]);
            }
            Console.WriteLine();
        }
    }

    public void HandleInput(ConsoleKey input)
    {
        int moveX;
        int moveY;

        switch (input)
        {
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                moveX = -1;
                moveY = 0;
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                moveX = 1;
                moveY = 0;
                break;
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                moveX = 0;
                moveY = -1;
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                moveX = 0;
                moveY = 1;
                break;
            default:
                moveX = 0;
                moveY = 0;
                break;
        }

        MovePlayer(moveX, moveY);
    }

    private void MovePlayer(int dX, int dY)
    {
        int newX = PlayerPos.X + dX;
        int newY = PlayerPos.Y + dY;

        if (newX < 0 || newX >= MapSize.X || newY < 0 || newY >= MapSize.Y)
        {
            return;
        }

        if (Map[newX, newY] == MapCell.Wall)
        {
            return;
        }

        PlayerPos = new Point(newX, newY);
    }
}
using System.Drawing;

enum MapCell
{
    None,
    Wall,
}

class Game
{
    Point MapSize;
    readonly MapCell[,] Map;
    readonly WorldObject Player;
    readonly List<WorldObject> Things;

    public Game(int mapSizeX, int mapSizeY, Point[] walls)
    {
        MapSize = new Point(mapSizeX, mapSizeY);
        Map = new MapCell[mapSizeX, mapSizeY];
        Things = new List<WorldObject>();
        InitMap(walls);

        // TODO: handle invalid player position
        Player = new WorldObject(WorldObjectType.PLAYER, new Point(0, 0));
        Things.Add(Player);
    }

    // TODO: add openable doors!
    private void InitMap(Point[] walls)
    {
        foreach (Point wall in walls)
        {
            Map[wall.Y, wall.X] = MapCell.Wall;
        }
    }

    public void Render()
    {
        Renderer.DrawScreen(MapSize.X, MapSize.Y, Map, Things);
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
        int newX = Player.Position.X + dX;
        int newY = Player.Position.Y + dY;

        if (newX < 0 || newX >= MapSize.X || newY < 0 || newY >= MapSize.Y)
        {
            return;
        }

        if (Map[newX, newY] == MapCell.Wall)
        {
            return;
        }

        Player.Position = new Point(newX, newY);
    }
}
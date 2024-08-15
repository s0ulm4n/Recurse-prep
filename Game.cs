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
    // TODO: create methods for adding and deleting things
    readonly List<WorldObject> Things;

    public Game(int mapSizeX, int mapSizeY, Point[] walls)
    {
        MapSize = new Point(mapSizeX, mapSizeY);
        Map = new MapCell[mapSizeY, mapSizeX];
        InitMap(walls);

        Things = new List<WorldObject>();
        Things.Add(new Door(WorldObjectType.DOOR, new Point(3, 3)));
        // TODO: handle invalid player position
        Player = new WorldObject(WorldObjectType.PLAYER, new Point(0, 0));
        Things.Add(Player);
    }

    private void InitMap(Point[] walls)
    {
        foreach (Point wall in walls)
        {
            SetMapCell(wall.X, wall.Y, MapCell.Wall);
        }
    }

    public void Render()
    {
        Renderer.DrawScreen(MapSize.X, MapSize.Y, Map, Things);
        // TODO: add GUI
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

    // TODO: WorldObject should handle moving
    private void MovePlayer(int dX, int dY)
    {
        int newX = Player.Position.X + dX;
        int newY = Player.Position.Y + dY;

        if (newX < 0 || newX >= MapSize.X || newY < 0 || newY >= MapSize.Y)
        {
            return;
        }

        if (GetMapCell(newX, newY) == MapCell.Wall)
        {
            return;
        }

        foreach (WorldObject thing in Things)
        {
            if (thing.Position.X == newX && thing.Position.Y == newY && !thing.PassThrough)
            {
                thing.OnCollision(Player);
                return;
            }
        }

        Player.Position = new Point(newX, newY);
    }

    // X and Y coordinates are confusing in our situation.
    // Normally, you would write the coordinates as (X,Y).
    // But because we're storing the map the same way we are displaying it,
    // the Y coordinate actually goes before the X when accessing a 
    // map cell: Map[y,x]
    private MapCell GetMapCell(int x, int y)
    {
        return Map[y, x];
    }

    private void SetMapCell(int x, int y, MapCell mapCell)
    {
        Map[y, x] = mapCell;
    }
}
struct DisplayCharacter
{
    public Char Symbol;
    public ConsoleColor Color;
}

class Renderer
{
    const ConsoleColor FLOOR_COLOR = ConsoleColor.DarkBlue;
    const ConsoleColor WALL_COLOR = ConsoleColor.White;
    const ConsoleColor PLAYER_COLOR = ConsoleColor.Yellow;
    const ConsoleColor DOOR_COLOR = ConsoleColor.DarkRed;

    public static void DrawScreen(int sizeX, int sizeY, MapCell[,] map, List<WorldObject> things)
    {
        DisplayCharacter[,] buffer = new DisplayCharacter[sizeY, sizeX];

        Console.Clear();
        Console.ResetColor();

        DrawMap(sizeX, sizeY, map, buffer);
        DrawThings(things, buffer);

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                Console.ForegroundColor = buffer[y, x].Color;
                Console.Write(buffer[y, x].Symbol);
            }
            Console.WriteLine();
        }
    }

    private static void DrawMap(int sizeX, int sizeY, MapCell[,] map, DisplayCharacter[,] buffer)
    {
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                if (map[y, x] == MapCell.Wall)
                {
                    buffer[y, x].Symbol = '#';
                    buffer[y, x].Color = WALL_COLOR;
                }
                else
                {
                    buffer[y, x].Symbol = '.';
                    buffer[y, x].Color = FLOOR_COLOR;
                }
            }
        }
    }

    private static void DrawThings(List<WorldObject> things, DisplayCharacter[,] buffer)
    {
        // TODO: figure out rendering order in case things occupy the same position
        foreach (WorldObject thing in things)
        {
            buffer[thing.Position.Y, thing.Position.X] = DrawWorldObject(thing);
        }
    }

    private static DisplayCharacter DrawWorldObject(WorldObject thing)
    {
        DisplayCharacter output;

        switch (thing.Type)
        {
            case WorldObjectType.PLAYER:
                output.Symbol = '@';
                output.Color = PLAYER_COLOR;
                break;
            case WorldObjectType.DOOR:
                Door? door = thing as Door;
                if (door is not null)
                {
                    if (door.IsOpen)
                    {
                        output.Symbol = '/';
                    }
                    else
                    {
                        output.Symbol = '+';
                    }
                    output.Color = DOOR_COLOR;
                }
                else
                {
                    throw new ArgumentException($"WorldObject with type DOOR was not a door!");
                }
                break;
            default:
                throw new ArgumentException($"Unexpected world object type: {thing.Type}");
        }

        return output;
    }
}
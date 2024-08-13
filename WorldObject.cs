using System.Drawing;

enum WorldObjectType
{
    NONE,
    PLAYER,
}

// TODO: add ID + comparator
// TODO: add HP
// TODO: add collision
class WorldObject
{
    public WorldObjectType Type;
    public Point Position;

    public WorldObject(WorldObjectType objectType, Point pos)
    {
        this.Type = objectType;
        this.Position = pos;
    }
}
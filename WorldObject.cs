using System.Drawing;

enum WorldObjectType
{
    NONE,
    PLAYER,
    DOOR,
}

// TODO: add ID + comparator
// TODO: add HP
// TODO: add collision
class WorldObject
{
    public WorldObjectType Type;
    public Point Position;
    public bool PassThrough;

    public WorldObject(WorldObjectType objectType, Point pos)
    {
        this.Type = objectType;
        this.Position = pos;
        this.PassThrough = true;
    }

    public virtual void OnCollision(WorldObject other) { }
}
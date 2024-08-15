using System.Drawing;

class Door : WorldObject
{
    public Door(WorldObjectType objectType, Point pos) : base(objectType, pos)
    {
        IsOpen = false;
        PassThrough = false;
    }

    public bool IsOpen;

    public override void OnCollision(WorldObject other)
    {
        if (other.Type == WorldObjectType.PLAYER)
        {
            IsOpen = true;
            PassThrough = true;
        }
    }
}
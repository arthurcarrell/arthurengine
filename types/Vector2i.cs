namespace arthurengine.Types;
using Microsoft.Xna.Framework;
public struct Vector2i
{
    public int X;
    public int Y;

    public Vector2i(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector2i operator +(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2i operator -(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2i operator *(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X * b.X, a.Y * b.Y);
    }

    public static Vector2i operator /(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.X / b.X, a.Y / b.Y);
    }

    public static implicit operator Vector2(Vector2i v) => new Vector2(v.X, v.Y);
    public static explicit operator Vector2i(Vector2 v) => new Vector2i((int)v.X, (int)v.Y);
}

namespace arthurengine.Components;
using Microsoft.Xna.Framework;

/// <summary>
/// Adds Position, Rotation and Scale to be used for an entity.
/// </summary>
public class TransformComponent : Component
{
    public Vector2 position = new Vector2(0, 0);
    public float rotation = 0;
    public float scale = 1;
}
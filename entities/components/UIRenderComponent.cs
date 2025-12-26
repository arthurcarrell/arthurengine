namespace arthurengine.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
/// <summary>
/// Allows the entity to be rendered. 
/// Does not respect the Camera, CameraRenderComponent should be used for that instead.
/// </summary>
/// <param name="transformComponent">The Entity's TransformComponent - Required for this component</param>
/// <param name="texture">The Entity's texture</param>
public class UIRenderComponent : Component
{
    public Texture2D texture;
    public bool visible;
    public TransformComponent transformComponent;
    public Color color;

    public UIRenderComponent(TransformComponent transformComponent, Texture2D texture)
    {
        this.transformComponent = transformComponent;
        this.texture = texture;
    }

    public virtual void Render(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.Draw(texture, transformComponent.position, null, color);
    }
}

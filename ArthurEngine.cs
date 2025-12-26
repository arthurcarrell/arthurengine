using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using arthurengine.Scenes;
using arthurengine.Entities;
using arthurengine.Components;
using arthurengine.Types;
namespace arthurengine;


public class ArthurEngine : Game
{
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;
    protected Vector2i ScreenSize = new Vector2i(0, 0);


    public ArthurEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        InitializeGameContent();

        _graphics.PreferredBackBufferWidth = ScreenSize.X;
        _graphics.PreferredBackBufferHeight = ScreenSize.Y;
        base.Initialize();
    }

    protected virtual void InitializeGameContent()
    {
        // TODO:  Create and Load a scene here
    }

    protected virtual void LoadGameAssets(SpriteBatch spriteBatch)
    {
        // TODO: Load your game content using the MonoGame content system.
        // WARN: This is soon going to be depreciated and replaced with a AssetManager class
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        LoadGameAssets(_spriteBatch);

    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        if (SceneManager.GetLoadedScene() != null)
        {
            if (SceneManager.GetLoadedScene().GetCamera() != null)
            {
                UpdateScene(gameTime, SceneManager.GetLoadedScene());
            }
            else
            {
                Logger.Error("No camera attached to scene!");
            }
        }
        else
        {
            // complain
            Logger.Error("No scene loaded!");
        }
        base.Update(gameTime);
    }

    private void UpdateScene(GameTime gameTime, Scene scene)
    {
        List<Entity> entities = new List<Entity>(scene.GetEntities());
        foreach (Entity entity in entities)
        {
            entity.Update(gameTime);
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        if (SceneManager.GetLoadedScene() != null)
        {
            DrawScene(_spriteBatch, gameTime, SceneManager.GetLoadedScene());
        }
        else
        {
            // complain
            Logger.Error("No scene loaded!");
        }

        base.Draw(gameTime);
    }

    protected virtual void DrawScene(SpriteBatch spriteBatch, GameTime gameTime, Scene scene)
    {
        List<Entity> entities = new List<Entity>(scene.GetEntities());
        foreach (Entity entity in entities)
        {
            HandleEntityRendering(spriteBatch, gameTime, scene, entity);
        }
    }

    protected virtual void HandleEntityRendering(SpriteBatch spriteBatch, GameTime gameTime, Scene scene, Entity entity)
    {
        // This is ran for each entity during the Rendering step.
        // If you instead want complete control of the scene, override DrawScene!
        if (entity.HasComponent<UIRenderComponent>())
        {
            entity.GetComponent<UIRenderComponent>().Render(spriteBatch, gameTime);
        }
        else if (entity.HasComponent<RenderComponent>())
        {
            entity.GetComponent<RenderComponent>().Render(spriteBatch, gameTime, scene.GetCamera().GetComponent<TransformComponent>());
        }
    }

    public Vector2i GetScreenDimensions()
    {
        return ScreenSize;
    }
}

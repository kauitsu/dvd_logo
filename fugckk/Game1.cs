using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace fugckk;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Vector2 Position = new(100f, 100f);
    private Vector2 Size = new(50f, 50f);
    private Vector2 Velocity;
    private Vector2 Direction;
    private float speed;
    private bool shot = false;
    

    private Random random = new();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        speed = 5f;
        Direction = new(random.Next(0, 360), random.Next(0, 360));
        Velocity = Direction * speed;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        Position += Velocity;
        
        if(Position.Y < 0 || Position.Y + Size.Y > GraphicsDevice.Viewport.Height)
        { 
            Velocity.Y = -Velocity.Y;
            
        } else if (Position.X < 0 || Position.X + Size.X > GraphicsDevice.Viewport.Width)
        {
            Velocity.X = -Velocity.X;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        _spriteBatch.Begin();
        _spriteBatch.DrawRectangle(Position, Size, Color.Black,2);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
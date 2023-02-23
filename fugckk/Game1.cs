using System;
using System.Collections.Generic;
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
    private int index = 0;
    private List<Color> colors = new List<Color> {Color.Black, Color.Red, Color.Blue, Color.Gold, Color.Green,
        Color.HotPink, Color.Purple, Color.Orange};
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        speed = 0.5f;
        Direction = new(5, 5);
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
            Velocity.Y *= -1;
            index = random.Next(colors.Count);
            if (index == index)
            {
                index = random.Next(colors.Count);
            }
            
        } else if (Position.X < 0 || Position.X + Size.X > GraphicsDevice.Viewport.Width)
        {
            Velocity.X *= -1;
            index = random.Next(colors.Count);
            if (index == index)
            {
                index = random.Next(colors.Count);
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        _spriteBatch.Begin();
        _spriteBatch.DrawRectangle(Position, Size, colors[index],2);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
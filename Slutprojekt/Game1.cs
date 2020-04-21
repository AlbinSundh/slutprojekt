using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D bild;

        Rectangle boll = new Rectangle(100, 100, 20, 20);
        Rectangle spelare1 = new Rectangle(10, 150, 20, 150);
        Rectangle spelare2 = new Rectangle(770, 150, 20, 150);

        int x_speed = 10;
        int y_speed = 2;
        private SpriteFont font;
        private int score = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bild = Content.Load<Texture2D>("Bild");
            font = Content.Load<SpriteFont>("Score");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState kstate = Keyboard.GetState();

            boll.X += x_speed;
            boll.Y += y_speed;

            if (kstate.IsKeyDown(Keys.W))
                spelare1.Y -= 5;
            if (kstate.IsKeyDown(Keys.S))
                spelare1.Y += 5;
            if (kstate.IsKeyDown(Keys.Up))
                spelare2.Y -= 5;
            if (kstate.IsKeyDown(Keys.Down))
                spelare2.Y += 5;

            if (spelare2.Y < 0)
                spelare2.Y = 0;
            if (spelare2.Y > Window.ClientBounds.Height - spelare2.Height)
                spelare2.Y = Window.ClientBounds.Height - spelare2.Height;
            if (spelare1.Y < 0)
                spelare1.Y = 0;
            if (spelare1.Y > Window.ClientBounds.Height - spelare1.Height)
                spelare1.Y = Window.ClientBounds.Height - spelare1.Height;

            if (boll.Y < 0 || boll.Y > Window.ClientBounds.Height - boll.Height)
                y_speed *=-1;
            
            if (boll.Intersects(spelare1) || boll.Intersects(spelare2))
                x_speed *=-1;

            
           if(boll.X < 0 || boll.X > Window.ClientBounds.Width - boll.Width) 
            Exit();

        


            
               

            // TODO: Add your update logic here

            base.Update(gameTime);
            score++;
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(bild, boll, Color.White);
            spriteBatch.Draw(bild, spelare1, Color.White);
            spriteBatch.Draw(bild, spelare2, Color.White);
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

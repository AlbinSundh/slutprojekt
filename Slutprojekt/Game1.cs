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

        Rectangle boll = new Rectangle(400, 200, 20, 20);//Skapar bollen och sätter denns koordinater samt bestämmer hur stor den ska vara
        Rectangle spelare1 = new Rectangle(10, 150, 20, 150);//Skapar Spelare 1 och sätter denns koordinater samt bestämmer hur stor den ska vara
        Rectangle spelare2 = new Rectangle(770, 150, 20, 150);//Skapar Spelare 2 och sätter denns koordinater samt bestämmer hur stor den ska vara

        SpriteFont scorefont;
        int score1 = 0;//nollsätter poängen till 0
        int score2 = 0;//nollsätter poängen till 0

        int x_speed = 10;//Sätter hastigheten i x-led
        int y_speed = 2;//Sätter hastigheten i y-led

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
            bild = Content.Load<Texture2D>("Bild"); // Laddar in bild till mina spelar och bollen
            scorefont = Content.Load<SpriteFont>("scorefont"); // Laddar in hur texten ska se ut till poängen.


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
            KeyboardState kstate = Keyboard.GetState();//Kollar tangetbordets status

            boll.X += x_speed;//Omvandlar hastigheten till bollens hastighet i X-led
            boll.Y += y_speed;//Omvandlar hastigheten till bollens hastighet i Y-led

            if (kstate.IsKeyDown(Keys.W))//Bestämmer vad som händer när W är ner tryckt
                spelare1.Y -= 5;//Sätter hastigheten av Spelaren när W är ner tryckt
            if (kstate.IsKeyDown(Keys.S))//Bestämmer vad som händer när S är ner tryckt
                spelare1.Y += 5;//Sätter hastigheten av Spelaren när S är ner tryckt
            if (kstate.IsKeyDown(Keys.Up))//Bestämmer vad som händer när piltangeten uppåt är ner tryckt
                spelare2.Y -= 5;//Sätter hastigheten av Spelaren när piltangeten uppåt är ner tryckt
            if (kstate.IsKeyDown(Keys.Down))//Bestämmer vad som händer när piltangeten neråt är ner tryckt.
                spelare2.Y += 5;//Sätter hastigheten av Spelaren när piltangeten neråt är ner tryckt

            if (spelare2.Y < 0)//Det här gör så att inte paddlen kan gå utanför skärmen uppåt
                spelare2.Y = 0;//Detta ändrar så den inte ta paddlens koordinatier från denns vänsta hörnet där upp till hela
            if (spelare2.Y > Window.ClientBounds.Height - spelare2.Height)//Det här gör så att inte paddlen kan gå utanför skärmen neråt
                spelare2.Y = Window.ClientBounds.Height - spelare2.Height;
            if (spelare1.Y < 0)//Det här gör så att inte paddlen kan gå utanför skärmen uppåt
                spelare1.Y = 0;//Detta ändrar så den inte ta paddlens koordinatier från denns vänsta hörnet där upp till hela
            if (spelare1.Y > Window.ClientBounds.Height - spelare1.Height)//Det här gör så att inte paddlen kan gå utanför skärmen neråt
                spelare1.Y = Window.ClientBounds.Height - spelare1.Height;

            if (boll.Y < 0 || boll.Y > Window.ClientBounds.Height - boll.Height)//Detta Gör så att inte bollen kan studsa ut på långsidorna
                y_speed *=-1; //Den ändra riktningen på bollen
            
            if (boll.Intersects(spelare1) || boll.Intersects(spelare2))// Detta göra så att bollen ka kolldera med spelarena
                x_speed *=-1; //Den ändra riktningen på bollen


            if (boll.X > Window.ClientBounds.Width - boll.Width)// Kollar om bollen åker ut på högersidan
            {
                score1++; //Om bollen åker ut på högersidan så lägger den till ett poäng åt vänsterspelaren
                boll.X = 400; //Start koordinatierna vid mål i X-led
                boll.Y = 200; //Start koordinatierna vid mål i Y-led
                x_speed *= -1; //När den blir mål får andra spelaren börja med bollen
            }

            if (boll.X < 0)// Kollar om bollen åker ut på vänstersidan
            {
                score2++; //Om bollen åker ut på vänstersidan så lägger den till ett poäng åt högerspelaren
                boll.X = 400; //Start koordinatierna vid mål i X-led
                boll.Y = 200; //Start koordinatierna vid mål i Y-led
                x_speed *= -1; //När den blir mål får andra spelaren börja med bollen
            }







            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(bild, boll, Color.White); //Ritar ut bilden till bollen och sätter färgen
            spriteBatch.Draw(bild, spelare1, Color.White); //Ritar ut bilden till spelare1 och sätter färgen
            spriteBatch.Draw(bild, spelare2, Color.White); //Ritar ut bilden till spelaren2 och sätter färgen
            spriteBatch.DrawString(scorefont, score1.ToString(), new Vector2(10, 10), Color.White);//Ritar ut poängtavlan för första spelaren, sätter färgen och koorditater
            spriteBatch.DrawString(scorefont, score2.ToString(), new Vector2(780, 10), Color.White);//Ritar ut poängtavlan för första spelaren, sätter färgen och koorditater
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

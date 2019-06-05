#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion


namespace TopDownShooter
{

    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GamePlay gamePlay;

        Basic2d cursor;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Globals.screenWidth = 1600; 
            Globals.screenHeight = 900; 

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cursor = new Basic2d("2d\\Misc\\CursorArrow", new Vector2(0, 0), new Vector2(28, 28));

            Globals.keyboard = new McKeyboard();
            Globals.mouse = new McMouseControl();

            gamePlay = new GamePlay();
        }

        
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();


            gamePlay.Update();


            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();


            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            gamePlay.Draw();


            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0), Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }

#if WINDOWS || LINUX
        /// <summary>
        /// The main class.
        /// </summary>
        public static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
                using (var game = new Main())
                    game.Run();
            }
        }
#endif
    
}

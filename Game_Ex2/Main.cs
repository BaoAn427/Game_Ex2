using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Ex2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.PreferredBackBufferWidth = 1024;
            //graphics.PreferredBackBufferHeight = 668;
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
            // TODO: use this.Content to load your game content here
            this.IsMouseVisible = true;

            Global._Content = this.Content;
            Global.LoadTilingMap();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Global.UpdateEntityInvisible(gameTime);

            // Start dragging - Start clicking Left Mouse
            if (Global.Is_LeftMouse_Click_Begin())
            {
                Global.BeginDragging();
                Global.NotFloatedYet();
            }
            // Dragging - Press Left Mouse
            else if (Global.Is_LeftMouse_Pressed() && Global.IsDragging())
            {
                Global.Drag();
            }
            // Stop dragging - Stop clicking Left Mouse -> Begin Floating
            else if(Global.Is_LeftMouse_Click_End() && Global.IsDragging())
            {
                Global.EndDragging();
                Global.BeginFloating();
            }           
            // Stop Floating
            else if(Global.IsFloating())
            {
                Global.EndFloating();
            }
            // Content floats up
            else if(Global.Is_Scroll_Up()) 
            {
                Global.ZoomOut();
            }
            // Content float down
            else if(Global.Is_Scroll_Down())
            {
                Global.ZoomIn();
            }

            // Move to Left
            else if (Global.Is_ControlToLeft())
            {
                Global.BeginMovingToLeft();
            }
            else if (Global.Is_MovingToLeft())
            {
                if (!Global.Is_ReachLeft())
                {
                    Global.MoveToLeft();
                }
                else
                {
                    Global.EndMovingInCol();
                }
            }

            // Move to Right
            else if (Global.Is_ControlToRight())
            {
                Global.BeginMovingToRight();
            }
            else if (Global.Is_MovingToRight())
            {
                if (!Global.Is_ReachRight())
                {
                    Global.MoveToRight();
                }
                else
                {
                    Global.EndMovingInCol();
                }
            }

            // Move to Up
            else if (Global.Is_ControlToUp())
            {
                Global.BeginMovingToUp();
            }
            else if (Global.Is_MovingToUp())
            {
                if (!Global.Is_ReachUp())
                {
                    Global.MoveToUp();
                }
                else
                {
                    Global.EndMovingInRow();
                }
            }

            // Move to Down
            else if (Global.Is_ControlToDown())
            {
                Global.BeginMovingToDown();
            }
            else if (Global.Is_MovingToDown())
            {
                if (!Global.Is_ReachDown())
                {
                    Global.MoveToDown();
                }
                else
                {
                    Global.EndMovingInRow();
                }
            }

            Global.UpdateEntityVisible(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Global._Camera.WVP);
            //Global._TextureManagement.DrawTexture(gameTime, spriteBatch);
            Global.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

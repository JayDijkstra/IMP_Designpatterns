using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyPlane
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static Game1 Instance;

        public Random Random;

        private World _world;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
        }


        protected override void Initialize()
        {
            // Eerst moet de verwijzing naar de game er zijn. 
            Instance = this;
            Random = new Random();
            // Daarna kunnen alle assets ingeladen worden. Dit gebeurt door base.Initialize() aan te roepen (deze roept LoadContent aan)
            base.Initialize();


            _world = new World();

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //AssetsManager am = new AssetsManager();

        }

        protected override void Update(GameTime gameTime)
        {
            _world.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            _world.Draw();
            spriteBatch.End();
        }
    }
}

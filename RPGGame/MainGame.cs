using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class MainGame : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        SpriteBatch spriteBatch;
        Texture2D pic;
        public MainGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphicsDeviceManager.IsFullScreen = true;
            IsMouseVisible = true;
            base.Initialize();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            //pic = Content.Load<Texture2D>(@"Textures\Tiles\main_tile");
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(pic, new Vector2(), Color.Transparent);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

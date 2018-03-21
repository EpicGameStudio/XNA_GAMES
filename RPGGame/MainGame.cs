using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Helper;
using RPGGame.Scenes;
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
        ContentLoader contentLoader;
        public MainGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            contentLoader = new ContentLoader(Content);
            Window.AllowUserResizing = true;
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

            SceneManager.Instance.LoadScene("WorldScene", contentLoader);
            //pic = Content.Load<Texture2D>(@"Textures\Tiles\main_tile");
        }
        protected override void Update(GameTime gameTime)
        {
            SceneManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            SceneManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

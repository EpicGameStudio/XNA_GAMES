using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Components;
using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Scenes
{
    public class Map
    {
        private int id;
        private string name;
        private ContentLoader contentLoader;
        private List<GameObject> mapItems;

        public Map(int pId, ContentLoader contentLoader)
        {
            id = pId;
            this.contentLoader = contentLoader;
            mapItems = new List<GameObject>();
            LoadContent();
        }

        public void LoadContent()
        {
            //init map items, include map base entity and event
            //eg:
            GameObject gameObject = new GameObject();
            SpriteRenderer sprite = new SpriteRenderer();
            sprite.Sprite = contentLoader.LoadTexture("Tiles/main_tile");
            
            gameObject.AddComponent(sprite);
            mapItems.Add(gameObject);
        }

        public void Save()
        {

        }

        public void Update(GameTime gameTime )
        {
            mapItems.ForEach((i) => { i.Components.ForEach((c) => { c.Update(gameTime); }); });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapItems.ForEach((i) => { i.Components.ForEach((c) => { c.Draw(spriteBatch); }); });
        }
    }
}

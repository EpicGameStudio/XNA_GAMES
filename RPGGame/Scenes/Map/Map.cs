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
    public class Map:IPosition
    {
        private int id;
        private string name;
        private ContentLoader contentLoader;

        MapData mapData;
        private List<GameObject> mapItems;
        private Rectangle boundary;
        
        public Vector2 Position
        {
            get
            {
                return mapData.Position;
            }
            set
            {
                mapData.Position = value;
            }
        }

        public Map(MapData data, ContentLoader contentLoader)
        {
            mapData = data;
            this.contentLoader = contentLoader;
            mapItems = new List<GameObject>();
            LoadContent();
        }

        public void LoadContent()
        {
            //init map items, include map base entity and event
            //eg: 
            GameObject gameObject = new GameObject(this);
            SpriteRenderer sprite = new SpriteRenderer();
            sprite.Sprite = contentLoader.LoadTexture("Tiles/main_tile");                
                
            gameObject.AddComponent(sprite);
            gameObject.AddComponent(new Transform());
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

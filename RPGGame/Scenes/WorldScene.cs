using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Scenes
{
    public class WorldScene : SceneBase
    {
        public override int Id { get { return 1; } set { } }

        public override string Name { get { return "WorldScene"; } set { } }

        List<Map> mapList;

        public WorldScene()
        {
            mapList = new List<Map>();
        }
        
        public override void Load(ContentLoader contentLoader)
        {
            //load map here, it should load current map and the around maps
            var map = new Map(0,contentLoader);
            mapList.Add(map);
        }

        public override void UnLoad()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            mapList.ForEach(map => { map.Update(gameTime); });
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            mapList.ForEach(map => { map.Draw(spriteBatch); });
        }
    }
}

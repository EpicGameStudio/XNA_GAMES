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
    public abstract class SceneBase : IScene,IUpdate,IDraw
    {
        public virtual string Name { get; set; }

        public virtual int Id { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void Load(ContentLoader contentLoader) { }

        public virtual void UnLoad() { }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}

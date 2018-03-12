using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Sprite { get; set; }

        public Color Color { get; set; }

        public int Layer { get; set; }

        public int OrderInLayer { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Vector2.Zero, Color.White);
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}

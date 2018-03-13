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
            var transform = ComponentOwner.GetComponent<Transform>();
            var position = transform.Position + ComponentOwner.ParentPosition;
            spriteBatch.Draw(
                Sprite,
                position,
                Color.White
                );
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.GameEngine.Classes.Things.Entities
{
    [Serializable]
    public abstract class Entity:Thing
    {
        public Entity(Vector2 pos):base(pos)
        {

        }
    }
}

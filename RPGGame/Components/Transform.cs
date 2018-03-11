using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RPGGame.Components
{
    public class Transform:Component
    {
        public Vector2 Position { get; set; }

        public Vector2 Rotation { get; set; }

        public Vector2 Scale { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RPGGame.Scenes
{
    public class MapData
    {
        public Vector2 Position { get; set; }

        public int MapHeight { get; set; }

        public int MapWidth { get; set; }

        public int[,] MapTileData { get; set; }

        public List<Rectangle> Collisions { get; set; }
    }
}

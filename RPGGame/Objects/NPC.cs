using Microsoft.Xna.Framework;
using RPGGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Objects
{
    public sealed class NPC
    {
        public static GameObject Create(string id)
        {
            var gameObject = new GameObject();
            //gameObject.AddComponent(new Transform() { Position = position, Rotation = Vector2.One, Scale = Vector2.One });
            //gameObject.AddComponent(new SpriteRenderer());
            return gameObject;
        }
    }
}

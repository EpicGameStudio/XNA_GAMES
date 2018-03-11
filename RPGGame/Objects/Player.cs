using RPGGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RPGGame.Objects
{
    public sealed class Player
    {
        public static GameObject Create(Vector2 position)
        {
            var gameObject = new GameObject();
            gameObject.AddComponent(new Transform() { Position = position,Rotation = Vector2.One,Scale = Vector2.One });
            gameObject.AddComponent(new SpriteRenderer());
            return gameObject;
        }
    }
}

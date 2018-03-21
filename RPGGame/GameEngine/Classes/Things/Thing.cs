using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RPGGame.GameEngine
{
    public abstract class Thing : IPosition,INoun
    {
        public Thing(Vector2 pos)
        {
            mPos = pos;
        }

        Vector2 mPos;
        public Vector2 Position
        {
            get
            {
                return mPos;
            }
            set
            {
                if (mPos != value)
                {
                    OnSetPosition(value);
                }
            }
        }

        public abstract string NounText { get; }

        public abstract Person Person { get; }

        public abstract string Pronoun { get; }

        public abstract string Possessive { get; }

        protected virtual void OnSetPosition(Vector2 pos)
        {
            mPos = pos;
        }
    }
}


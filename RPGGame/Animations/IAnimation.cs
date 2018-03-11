using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Animations
{
    internal interface IAnimation
    {
        int AnimationCooldown { get; set; }
        Rectangle GetNewAnimationState();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Animations
{
    public class Animation
    {
        private IAnimation currentAnimation;
        private double counter;

        public Animation()
        {
            counter = 0;
        }

        public void Update(double gameTime)
        {
            if (currentAnimation == null)
                return;
            counter += gameTime;
            if (counter > currentAnimation.AnimationCooldown)
            {
                var drawFrame = currentAnimation.GetNewAnimationState();
                //var sprite = Owner.GetComponent<Sprite>();
                //sprite.UpdateDrawFrame(drawFrame);
                counter = 0;
            }
        }

        public void PlayAnimation()
        {
            throw new NotImplementedException();
        }

        public void StopAnimation()
        {
            currentAnimation = null;
        }
    }
}

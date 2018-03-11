using RPGGame.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Components
{
    public class Animator:Component
    {
        private Dictionary<string, Animation> animationList;

        public Animator()
        {
            animationList = new Dictionary<string, Animation>();
        }

        public void AddAnimation(string name, Animation animation)
        {
            animationList[name] = animation;
        }

        public void PlayAnimation(string name)
        {
            animationList[name].PlayAnimation();
        }

        public void StopAnimation(string name)
        {
            animationList[name].StopAnimation();
        }
    }
}

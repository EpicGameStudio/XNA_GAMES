using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.GameEngine
{
   public abstract class Action
    {
        public static implicit operator ActionResult(Action action)
        {
            return new ActionResult(action);
        }


    }
}

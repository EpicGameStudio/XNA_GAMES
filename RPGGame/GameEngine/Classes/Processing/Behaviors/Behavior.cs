using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.GameEngine.Classes.Processing.Behaviors
{
    [Serializable]
    public abstract class Behavior
    {
        public virtual bool NeedsUserInput
        {
            get { return false; }
        }

        public abstract Action NextAction();

    }
}

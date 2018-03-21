using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.GameEngine
{
    public interface INoun
    {
        string NounText { get; }
        Person Person { get; }
        string Pronoun { get; }
        string Possessive { get; }
    }
}

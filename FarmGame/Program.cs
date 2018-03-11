using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FarmGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new MainGame())
            {
                game.Run();
            }
        }
    }
}

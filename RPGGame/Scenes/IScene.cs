using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Scenes
{
    

    public interface IScene
    {
        int Id { get; set; }

        string Name { get; set; }

        void Load(ContentLoader contentLoader);

        void UnLoad();

    }
}

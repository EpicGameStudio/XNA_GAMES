using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Scenes
{
    public class StartScene : SceneBase
    {
        public int Id { get { return 0; } set { } }

        public string Name { get { return "StartScene"; } set { } }

        public override void Load(ContentLoader contentLoader)
        {
            throw new NotImplementedException();
        }

        public override void UnLoad()
        {
            throw new NotImplementedException();
        }
    }
}

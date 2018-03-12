using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Scenes
{
    public class IndoorScene : SceneBase
    {
        public override int Id { get { return 2; } set { } }

        public override string Name { get { return "IndoorScene"; } set { } }


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

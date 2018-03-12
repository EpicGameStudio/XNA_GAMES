using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Scenes
{
    public class SceneManager
    {
        private SceneBase currentScene;
        private bool isSceneLoaded = false;

        private SceneBase worldScene;
        private SceneBase battleScene;
        private SceneBase startScene;
        private SceneBase indoorScene;
        private List<SceneBase> sceneList;

        private static SceneManager instance;
        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SceneManager();
                return instance;
            }
        }

        public SceneManager()
        {
            Init();
        }

        private void Init()
        {
            //create the scene you wanna build
            worldScene = new WorldScene();
            battleScene = new BattleScene();
            startScene = new StartScene();
            indoorScene = new IndoorScene();
            sceneList = new List<SceneBase>() { startScene, worldScene, indoorScene, battleScene };
        }

        public void LoadScene(string name,ContentLoader contentLoader)
        {
            if (currentScene != null)
            {
                currentScene.UnLoad();
            }
            var scene = sceneList.Where(i => i.Name == name).FirstOrDefault();
            if(scene == null)
                throw new Exception("Scene cannot be found");

            currentScene = scene;
            currentScene.Load(contentLoader);
        }

        public void UnLoadScene(string name)
        {
            var scene = sceneList.Where(i => i.Name == name).FirstOrDefault();
            if (scene == null)
                throw new Exception("Scene cannot be found");

            scene.UnLoad();
        }

        public void LoadScene(int id, ContentLoader contentLoader)
        {
            var scene = sceneList.Where(i => i.Id == id).FirstOrDefault();
            if (scene == null)
                throw new Exception("Scene cannot be found");

            currentScene = scene;
            scene.Load(contentLoader);
        }

        public void UnLoadScene(int id)
        {
            var scene = sceneList.Where(i => i.Id == id).FirstOrDefault();
            if (scene == null)
                throw new Exception("Scene cannot be found");

            scene.UnLoad();
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScene.Draw(spriteBatch);
        }
    }
}

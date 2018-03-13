using Microsoft.Xna.Framework;
using RPGGame.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Components
{
    public sealed class GameObject
    {
        public GameObject()
        {
            
        }
        public GameObject(IPosition pParentPosition):this()
        {
            parentPosition = pParentPosition;
        }
        public GameObject(string name):this()
        { }

        public int Layer { get; set; }

        public int Active { get; set; }

        public string Tag { get; set; }

        private IPosition parentPosition = null;

        public Vector2 ParentPosition
        {
            get
            {
                if(parentPosition!=null)
                    return parentPosition.Position;
                return Vector2.Zero;
            }
        }

        private List<GameObject> children;
        public void AddChild(GameObject child)
        {
            if (children == null)
                children = new List<GameObject>();
            children.Add(child);
        }

        private List<Component> components = new List<Component>();
        public List<Component> Components { get { return components; } }

        public T GetComponent<T>() where T:Component
        {
            return components.Where(i => i is T).FirstOrDefault() as T;
        }

        public void AddComponent(Component component)
        {
            if (object.Equals(components, null))
                components = new List<Component>();

            component.ComponentOwner = this;
            components.Add(component); 
        }

        public void RemoveComponent(Component component)
        {
            if (components.Contains(component))
            {
                component.ComponentOwner = null;
                components.Remove(component);
                return;
            }
            else
            {
                throw new Exception("component cannot found");
            }
            
        }

        public void RemoveComponent<T>() where T:Component
        {
            components.RemoveAll((item) => { return item is T; });
        }             
    }
}

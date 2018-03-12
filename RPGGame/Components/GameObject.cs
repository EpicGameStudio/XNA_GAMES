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
        public GameObject(string name)
        { }

        public int Layer { get; set; }

        public int Active { get; set; }

        public string Tag { get; set; }

        private List<Component> components = new List<Component>();
        public List<Component> Components { get { return components; } }

        public Component GetComponent<T>() where T:Component
        {
            return components.Where(i => i is T).FirstOrDefault();
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

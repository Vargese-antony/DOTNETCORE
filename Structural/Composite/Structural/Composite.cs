using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_Pattern.Structural
{
    public class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        {
        }

        public void Add(Component c)
        {
            children.Add(c);
        }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.Name);
            foreach (var item in children)
            {
                item.PrimaryOperation(depth + 2);
            }
            
        }

        public void Remove(Component c)
        {
            children.Remove(c);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_Pattern.Structural
{
    public abstract class Component
    {
        public Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract void PrimaryOperation(int depth);
    }
}

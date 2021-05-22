using System;
using Composite_Pattern.Structural;

namespace Composite_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //StructuralExample();

        }

        private static void StructuralExample()
        {
            var root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var c1 = new Composite("Composite C1");
            c1.Add(new Leaf("Leaf C1-A"));
            c1.Add(new Leaf("Leaf C1-B"));

            var c2 = new Composite("Composite C2");
            c2.Add(new Leaf("Leaf C2-A"));
            c1.Add(c2);

            root.Add(c1);
            root.Add(new Leaf("Leaf C"));

            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            //Display tree
            root.PrimaryOperation(1);
        }
    }
}

using System;
using Composite_Pattern.Structural;

namespace Composite_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //StructuralExample();

            //FileSystemComposite();

        }

        private static void FileSystemComposite()
        {
            var root = new DirectoryItem("root");
            var p1 = new DirectoryItem("P1");
            var p2 = new DirectoryItem("P2");
            root.Add(p1);
            root.Add(p2);

            p1.Add(new FileItem("p1f1.txt", 2100));
            p1.Add(new FileItem("p1f2.txt", 3100));
            var sd1 = new DirectoryItem("sub-dir1");
            sd1.Add(new FileItem("p1f3.txt", 4100));
            sd1.Add(new FileItem("p1f4.txt", 5100));
            p1.Add(sd1);

            p2.Add(new FileItem("p2f1.txt", 6100));
            p2.Add(new FileItem("p2f2.txt", 7100));

            Console.WriteLine($"Total file size: {p2.GetFileSizeInKB()}");
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

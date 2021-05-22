using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Composite_Pattern
{
    class DirectoryItem : FileSystemItem
    {
        private List<FileSystemItem> items { get; } = new List<FileSystemItem>();
        public DirectoryItem(string name) : base(name)
        {
        }

        public void Add(FileSystemItem component)
        {
            items.Add(component);
        }
        public void Remove(FileSystemItem component)
        {
            items.Remove(component);
        }

        public override decimal GetFileSizeInKB()
        {
            return this.items.Sum(x => x.GetFileSizeInKB());
        }
    }
}

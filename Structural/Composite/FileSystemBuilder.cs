using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Composite_Pattern
{
    public class FileSystemBuilder
    {
        private DirectoryItem currentDirectory;

        public FileSystemBuilder(string rootDirectoryName)
        {
            this.Root = new DirectoryItem(rootDirectoryName);
            this.currentDirectory = this.Root;
        }

        public DirectoryItem Root { get; }

        public FileItem AddFile(string name, int fileByte)
        {
            var file = new FileItem(name, fileByte);
            this.currentDirectory.Add(file);
            return file;
        }

        public DirectoryItem SetCurrentDirectory(string name)
        {
            var dirStack = new Stack<DirectoryItem>();
            dirStack.Push(this.Root);
            while (dirStack.Any())
            {
                var c = dirStack.Pop();
                if(c.Name == name)
                {
                    this.currentDirectory = c;
                    return c;
                }
                foreach (var item in c.items.OfType<DirectoryItem>())
                {
                    dirStack.Push(item);
                }
            }
            throw new InvalidOperationException($"The directory name is not found: {name}");
        }

        public DirectoryItem AddDirectory(string name)
        {
            var dir = new DirectoryItem(name);
            this.currentDirectory.Add(dir);
            this.currentDirectory = dir;
            return dir;
        }

    }
}

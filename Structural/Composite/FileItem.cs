using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_Pattern
{
    public class FileItem : FileSystemItem
    {
        public FileItem(string name, long fileBytes) : base(name)
        {
            this.FileBytes = fileBytes;
        }

        public long FileBytes { get; }

        public override decimal GetFileSizeInKB()
        {
            return Decimal.Divide(this.FileBytes, 1024);
        }
    }
}

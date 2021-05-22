using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype_Pattern
{
    public class PrototypeManager
    {
        public Dictionary<string, Prototype> _prototypeLibrary =
            new Dictionary<string, Prototype>();

        public Prototype this[string key]
        {
            get { return _prototypeLibrary[key]; }
            set { _prototypeLibrary.Add(key, value); }
        }
    }
}

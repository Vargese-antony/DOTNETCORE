using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
    public class PropertyMappingValue
    {
        public IEnumerable<string> DestinatioProperties { get; private set; }
        public bool Revert { get; private set; }
        public PropertyMappingValue(IEnumerable<string> destinatioProperties, bool revert = false)
        {
            DestinatioProperties = destinatioProperties;
            Revert = revert;
        }
    }
}

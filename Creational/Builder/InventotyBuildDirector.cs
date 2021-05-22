using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_Pattern
{
    public class InventotyBuildDirector
    {
        private IFurnitureInventoryBuilder _builder;
        public InventotyBuildDirector(IFurnitureInventoryBuilder builder)
        {
            _builder = builder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDimensions();
            _builder.AddLogistics(DateTime.Now);
        }
    }
}

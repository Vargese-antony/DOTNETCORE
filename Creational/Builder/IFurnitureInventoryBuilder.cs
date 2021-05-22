using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_Pattern
{
    public interface IFurnitureInventoryBuilder
    {
        public void AddTitle();
        public void AddDimensions();
        public void AddLogistics(DateTime dateTime);
        public InventoryReport GetDailyReport();
    }
}

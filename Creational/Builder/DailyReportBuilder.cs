using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Builder_Pattern
{
    class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _report;
        private IEnumerable<FurnitureItem> _items;
        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            _report = new InventoryReport();
            _items = items;
        }
        public void AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, _items.Select(x => 
                $"Product: {x.Name} \nPrice: {x.Price}" +
                $"Height: {x.Height} x width: {x.Width} -> Weight: {x.Weight} lbs"));
        }

        public void AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report generated on {dateTime}";
        }

        public void AddTitle()
        {
            _report.TitleSection = "----------Daily Inventory Report---------------\n\n";
        }

        public InventoryReport GetDailyReport()
        {
            return _report;
        }
    }
}

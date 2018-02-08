using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Rubix.Framework
{
    public class VirtualLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string LocationPrefix { get; set; }
        public string ColorCode { get; set; }
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public Decimal? MaxCapacity { get; set; }
        public Decimal? Capacity { get; set; }
        public Decimal? MaxUnit { get; set; }
        public Decimal? Unit { get; set; }
        public int Level { get; set; }
        public int align { get; set; }
        public List<int> UsedLevelList { get; set; }
        private SolidBrush brush = null;

        public SolidBrush GetBrush()
        {
            if (brush == null)
                brush = new SolidBrush(System.Drawing.ColorTranslator.FromHtml(this.ColorCode));
            return brush;
        }

        public VirtualLocation(int x, int y, int width, int height, string colorCode, int zoneID, string zoneName, string locationPrefix)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.ColorCode = colorCode;
            this.ZoneID = zoneID;
            this.ZoneName = zoneName;
            this.LocationPrefix = locationPrefix;
        }
        public VirtualLocation(int x, int y, int width, int height, string colorCode, int zoneID, string zoneName, string LocationPrefix, Decimal? maxCapacity, Decimal? capacity, int level, List<int> usedLevelList)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.ColorCode = colorCode;
            this.ZoneID = zoneID;
            this.ZoneName = zoneName;
            this.MaxCapacity = maxCapacity;
            this.Capacity = capacity;
            this.Level = level;
            this.UsedLevelList = usedLevelList;
        }

        public override string ToString()
        {
            return string.Format("Insert into tbs_WarehouseLayout(DCID, Page, ZoneID, LocationPrefix, x, y, width, height) values (1, 1, {0}, '{1}', {2}, {3}, {4}, {5})", this.ZoneID, this.LocationPrefix, this.X, this.Y, this.Width, this.Height);
        }
    }
}

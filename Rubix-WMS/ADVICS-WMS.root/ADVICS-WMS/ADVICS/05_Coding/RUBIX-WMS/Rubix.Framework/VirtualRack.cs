using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Rubix.Framework
{
    public class VirtualRack
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int BlockSize { get; set; }
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public Decimal? MaxCapacity { get; set; }
        public Decimal? UsageCapacity { get; set; }
        public Decimal? MaxUnit { get; set; }
        public Decimal? UsageUnit { get; set; }
        public bool FullFlag { get; set; }
        public int Level { get; set; }

        [DefaultValue("#,##0.000")]
        public string QtyFormat { get; set; }
        [DefaultValue("#,##0.00")]
        public string PercentFormat { get; set; }

        public string Color
        {
            get
            {
                if (FullFlag)
                    return "#FF0000"; //full
                else if (this.UsageCapacity.HasValue && this.UsageCapacity.Value > 0 && this.UsageUnit.HasValue && this.UsageUnit.Value > 0)
                    return "#00FF00"; //available
                else
                    return "#FFFFFF"; //empty
            }
        }

        public SolidBrush GetBrush()
        {
            return new SolidBrush(System.Drawing.ColorTranslator.FromHtml(this.Color));
        }

        public Color GetColor()
        {
            return System.Drawing.ColorTranslator.FromHtml(this.Color);
        }

        public VirtualRack(int x, int y, int blockSize, int locationID, string locationCode, decimal maxCap, decimal usageCap, decimal maxUnit, decimal usageUnit, bool fullFlag, int level, string qtyFormat, string percentFormat)
        {
            this.X = x;
            this.Y = y;
            this.BlockSize = blockSize;
            this.LocationID = locationID;
            this.LocationCode = locationCode;
            this.MaxCapacity = maxCap;
            this.UsageCapacity = usageCap;
            this.MaxUnit = maxUnit;
            this.UsageUnit = usageUnit;
            this.FullFlag = fullFlag;
            this.Level = level;
            this.QtyFormat = qtyFormat;
            this.PercentFormat = percentFormat;
        }
    }
}

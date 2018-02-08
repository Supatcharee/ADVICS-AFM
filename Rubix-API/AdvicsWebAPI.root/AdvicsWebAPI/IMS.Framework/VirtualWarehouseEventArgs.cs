using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubix.Framework
{
    public class VirtualWarehouseEventArgs : EventArgs
    {
        public VirtualLocation LocationInformation { get; set; }

        public VirtualWarehouseEventArgs(VirtualLocation location)
        {
            this.LocationInformation = location;
        }
    }
}

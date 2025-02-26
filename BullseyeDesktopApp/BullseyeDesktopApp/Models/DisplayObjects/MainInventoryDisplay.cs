using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    class MainInventoryDisplay
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int? Threshold { get; set; }
        public int? NewThreshold { get; set; }
    }
}

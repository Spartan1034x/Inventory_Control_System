using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models
{
    public class InventoryDisplay
    {
        public int ItemId { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? CaseSize { get; set; }
        public int? MinimumThreshold { get; set; }
        public int OptimumThreshold { get; set; }
        public int? Ordered {  get; set; }
    }
}

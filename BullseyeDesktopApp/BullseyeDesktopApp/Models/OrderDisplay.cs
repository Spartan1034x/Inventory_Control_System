using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models
{
    public class OrderDisplay
    {
        public required string Location { get; set; }
        public required string Status { get; set; }
        public required int Items { get; set; }
        public required decimal Weight { get; set; }
        public required string DeliveryDate { get; set; }
    }
}

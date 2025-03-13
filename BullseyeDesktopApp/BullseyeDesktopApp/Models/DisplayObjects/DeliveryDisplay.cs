using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    class DeliveryDisplay
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string VehicleType { get; set; } = null!;
        public string? Notes { get; set; }
        public int TotalCases { get; set; }
        public decimal Weight { get; set; } 

        public bool Delivered { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    class DeliveryItemDisplay
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }

        public bool Confirmed { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    class SupplierDisplay
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? Postal { get; set; }
        public string? Phone { get; set; }
        public string? Contact { get; set; }
        public sbyte Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    class LocationDisplay
    {
        public int ID { get; set; }
        public string? Location { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Prov { get; set; }
        public string? Country { get; set; }
        public string? Postal { get; set; }
        public string? Phone { get; set; }
        public string? Delivery { get; set; }
        public int Distance { get; set; }
        public string? Notes { get; set; }
        public int Active { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    public class OrderDisplay
    {
        public required int OrderID { get; set; }
        public required string Location { get; set; }
        public required string Status { get; set; }
        public required string Type { get; set; }
        public required int Items { get; set; }
        public required decimal Weight { get; set; }
        public required string DeliveryDate { get; set; }

        //public string WeightToString => $"{this.Weight} kgs";
    }
}

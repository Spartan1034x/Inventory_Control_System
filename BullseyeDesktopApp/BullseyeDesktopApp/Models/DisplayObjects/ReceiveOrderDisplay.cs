using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.Models.DisplayObjects
{
    class ReceiveOrderDisplay
    {
        public int ItemID { get; set; }
        public required string Name { get; set; }
        public required int InStock { get; set; }
        public required int Requested { get; set; }
        public required int CaseSize { get; set; }
        public required int Allocated { get; set; }
    }
}

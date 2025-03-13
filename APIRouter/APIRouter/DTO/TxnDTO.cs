using APIRouter.Models;

namespace APIRouter.DTO
{
    public class TxnDTO
    {
        public int TxnId { get; set; }

        public string? SiteTo { get; set; }

        public string TxnStatus { get; set; } = null!;

        public DateTime ShipDate { get; set; }

        public string BarCode { get; set; } = null!;

        public int? DeliveryId { get; set; }

        public bool EmergencyDelivery { get; set; }

        public decimal TotalWeight { get; set; }

        public int TotalItems { get; set; }

    }
}

namespace APIRouter.DTO
{
    public class DeliveryDTO
    {
        public int TxnID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int EmergencyOrder { get; set; }

        public string? Notes { get; set; }

        public decimal TotalWeight { get; set; }

        public string? BarCode { get; set; }

        public int SiteIDTo { get; set; }
    }
}

namespace APIRouter.DTO
{
    public class DeliveryDTO
    {
        public int DeliveryId { get; set; }

        public bool EmergencyOrder { get; set; }

        public string? DeliveryDate { get; set; }

        public string? Notes { get; set; }

        public decimal TotalWeight { get; set; }

        public string? VehicleType { get; set; }

        public List<int> TxnIDs  { get; set; }
    }
}

namespace APIRouter.DTO
{
    public class InventoryDTO
    {
        public int ItemID { get; set; }
        public int SiteID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? SKU { get; set; }
        public string? ImageLocation { get; set; }
    }
}

namespace APIRouter.DTO
{
    public class NewTxnDTO
    {
        public int SiteIdTo { get; set; }

        public string? Notes { get; set; }

        public List<TxnItemDTO>? Items { get; set; }
    }

    public class TxnItemDTO
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}

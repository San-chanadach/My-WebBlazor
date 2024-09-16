namespace RapidNRIMs.Model.Inventories
{
    public class InventoryStockCheckOutItemLastYear
    {
        public string InventoryStockNumber { get; set; } = string.Empty;
        public Guid? InventoryStockCheckOutGiveTo { get; set; }
        public int? Count { get; set; }
        public DateTime? LastCheckOutDate { get; set; }
    }
}

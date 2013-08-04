namespace TIPS.Pricing
{
    public class Item
    {
        public long Id { get; protected set; }
        public string ItemNumber { get; set; }
        public string UOM { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitCredit { get; set; }
        public decimal WasteFactor { get; set; }
        public decimal QuantityRoundingMultiple { get; set; }
        public string ItemType { get; set; }
        public string ProductType { get; set; }
        public long? OppositeItemId { get; set; }
        public bool IsTaxable { get; set; }
    }
}

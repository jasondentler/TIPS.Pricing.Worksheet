namespace TIPS.Pricing.Data
{
    internal class CommunityItemDto : IItemDto
    {
        public virtual long ItemID { get; set; }
        public virtual string ItemNumber { get; set; }
        public virtual string ItemType { get; set; }
        public virtual string ProductType { get; set; }
        public virtual decimal? UnitCost { get; set; }
        public virtual decimal? UnitCredit { get; set; }
        public virtual decimal? WasteFactor { get; set; }
        public virtual string UOM { get; set; }
        public virtual decimal? Rounding { get; set; }
        public virtual long? OppositeItemID { get; set; }
        public virtual bool? Taxable { get; set; }
        public virtual bool? InvalidPricing { get; set; }
    }
}

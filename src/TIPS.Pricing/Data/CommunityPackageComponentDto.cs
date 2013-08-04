namespace TIPS.Pricing.Data
{
    internal class CommunityPackageComponentDto 
    {
        public virtual long ID { get; set; }
        public virtual string CommunityId { get; set; }
        public virtual long OptionID { get; set; }
        public virtual long ComponentItemID { get; set; }
        public virtual string ItemNumber { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ItemType { get; set; }
        public virtual decimal? UnitCost { get; set; }
        public virtual decimal? UnitCredit { get; set; }
        public virtual decimal? WasteFactor { get; set; }
        public virtual string UOM { get; set; }
        public virtual decimal? Rounding { get; set; }
    }
}

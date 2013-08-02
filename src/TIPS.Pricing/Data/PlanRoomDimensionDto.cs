namespace TIPS.Pricing.Data
{
    internal class PlanRoomDimensionDto
    {
        public virtual long Id { get; set; }
        public virtual string CityId { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual string Room { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ProductTypeGroup { get; set; }
        public virtual string OptionNumber { get; set; }
        public virtual string UOM { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual bool AllowCredit { get; set; }
        public virtual bool IncludeInWholeHome { get; set; }
    }
}

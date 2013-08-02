namespace TIPS.Pricing.Data
{
    internal class AvailableOptionDto : IOptionDto
    {
        public virtual long OptionID { get; set; }
        public virtual string CommunityID { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual string OptionNumber { get; set; }
        public virtual string OptionType { get; set; }
        public virtual string Description { get; set; }
        public virtual string Room { get; set; }
        public virtual string OptionCategory { get; set; }
        public virtual string SubCategory { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual int? StageCutoff { get; set; }
        public virtual bool? AttributesRequired { get; set; }
        public virtual bool? InGroup { get; set; }
        public virtual bool? HasDetails { get; set; }
        public virtual string UOM { get; set; }
        public virtual decimal? MaterialBudget { get; set; }
        public virtual decimal? LaborBudget { get; set; }
        public virtual string OriginalDescription { get; set; }
        public virtual string SelectBy { get; set; }
        public virtual string ImageURL { get; set; }
        public virtual string Family { get; set; }
        public virtual string Finish { get; set; }
        public virtual string Template { get; set; }
        public virtual string ProductLevel { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ProductTypeGroup { get; set; }
        public virtual string Item { get; set; }
        public virtual decimal? RoomSize { get; set; }
        public virtual string RoomUOM { get; set; }
        public virtual decimal? UnitCost { get; set; }
        public virtual decimal? UnitCredit { get; set; }
        public virtual int? MarginPercent { get; set; }
        public virtual decimal? BaseOptionBudget { get; set; }
        public virtual decimal? BaseBudgetCostFactor { get; set; }
        public virtual decimal? BaseBudgetCreditFactor { get; set; }
        public virtual decimal? WasteFactor { get; set; }
        public virtual bool? Proforma { get; set; }
        public virtual bool? UseDynamicPricing { get; set; }
        public virtual string PricingUOM { get; set; }
        public virtual decimal? MinSalesPrice { get; set; }
    }
}

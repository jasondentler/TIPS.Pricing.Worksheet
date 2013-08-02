using System;

namespace TIPS.Pricing.Data
{
    public class SelectedOptionDto
    {
        public virtual long OptionSelectionID { get; set; }
        public virtual long? OptionID { get; set; }
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
        public virtual string OriginalDescription { get; set; }
        public virtual string SelectBy { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual decimal? TotalPrice { get; set; }
        public virtual int? PaymentType { get; set; }
        public virtual DateTime? DateSelected { get; set; }
        public virtual bool? SelectedAfterCutoff { get; set; }
        public virtual string Notes { get; set; }
        public virtual decimal? MaterialBudget { get; set; }
        public virtual decimal? LaborBudget { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string CreatedByName { get; set; }
        public virtual int? Approved { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual DateTime? ApprovedDate { get; set; }
        public virtual bool? PlanIncluded { get; set; }
        public virtual bool? OptionInJDE { get; set; }
        public virtual bool? IncludedInWebPrice { get; set; }
        public virtual bool? HasHouseFileDoc { get; set; }
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
        public virtual decimal? RoomSizeAdditions { get; set; }
        public virtual decimal? RoomSizeSubtractions { get; set; }
        public virtual decimal? AdjustedRoomSize { get; set; }
        public virtual decimal? AdjustedPrice { get; set; }
        public virtual bool? UseDynamicPricing { get; set; }
        public virtual string PricingUOM { get; set; }
        public virtual decimal? MinSalesPrice { get; set; }
    }
}

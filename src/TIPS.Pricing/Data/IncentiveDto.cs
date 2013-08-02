using System;

namespace TIPS.Pricing.Data
{
    public class IncentiveDto
    {
        public virtual long OptionSelectionID { get; set; }
        public virtual long? SaleID { get; set; }
        public virtual long? OptionID { get; set; }
        public virtual string Description { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual decimal? TotalPrice { get; set; }
        public virtual int? PaymentType { get; set; }
        public virtual DateTime? DateSelected { get; set; }
        public virtual bool? SelectedAfterCutoff { get; set; }
        public virtual string Notes { get; set; }
        public virtual bool? OptionInJDE { get; set; }
        public virtual string OriginalDescription { get; set; }
        public virtual decimal? SOP_ID { get; set; }
        public virtual int? JSE_ID { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual DateTime? ChangedDate { get; set; }
        public virtual bool? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool? HasHouseFileDoc { get; set; }
        public virtual long? CopiedFromID { get; set; }
        public virtual string Item { get; set; }
        public virtual string Template { get; set; }
        public virtual decimal? UnitCost { get; set; }
        public virtual decimal? UnitCredit { get; set; }
        public virtual int? MarginPercent { get; set; }
        public virtual decimal? WasteFactor { get; set; }
        public virtual decimal? BaseOptionBudget { get; set; }
        public virtual decimal? BaseBudgetCostFactor { get; set; }
        public virtual decimal? BaseBudgetCreditFactor { get; set; }
        public virtual bool? Proforma { get; set; }
        public virtual decimal? MaterialBudget { get; set; }
        public virtual decimal? LaborBudget { get; set; }
        public virtual string OptionNumber { get; set; }
        public virtual int? Approved { get; set; }
        public virtual DateTime? ApprovedDate { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual string OptionCategory { get; set; }
        public virtual string Room { get; set; }
        public virtual string SubCategory { get; set; }
        public virtual int? StageCutoff { get; set; }
    }
}

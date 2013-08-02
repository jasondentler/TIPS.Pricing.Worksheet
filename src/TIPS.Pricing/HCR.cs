using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIPS.Pricing.Data;

namespace TIPS.Pricing
{
    public class HCR
    {

        public HCR()
        {
        }

        internal HCR(HCRDto dto)
        {
        }

        public virtual long Id { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Number { get; set; }
        public virtual string OptionType { get; set; }
        public virtual string Description { get; set; }
        public virtual string Room { get; set; }
        public virtual string Category { get; set; }
        public virtual string SubCategory { get; set; }
        public virtual int? StageCutoff { get; set; }
        public virtual string OriginalDescription { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual decimal? TotalPrice { get; set; }
        public virtual int? PaymentType { get; set; }
        public virtual decimal? MaterialBudget { get; set; }
        public virtual decimal? LaborBudget { get; set; }
        public virtual int? MarginPercent { get; set; }
        public virtual long? PlanIncludedOptionID { get; set; }
        public virtual DateTime? DateSelected { get; set; }
        public virtual string Notes { get; set; }
        public virtual string RTE { get; set; }
        public virtual bool? Final { get; set; }
        public virtual bool? PricedInField { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string CreatedByName { get; set; }
        public virtual bool? AttributesRequired { get; set; }
        public virtual int? Approved { get; set; }
        public virtual int? BuyerApproved { get; set; }
        public virtual int? BuilderApproved { get; set; }
        public virtual bool? IncludedInWebPrice { get; set; }
        public virtual long? OriginalHCR { get; set; }
        public virtual int? ChangeStatus { get; set; }
        public virtual string ChangeStatusBy { get; set; }
        public virtual DateTime? ChangeStatusDate { get; set; }
        public virtual decimal? OriginalPrice { get; set; }
        public virtual decimal? OriginalMaterialBudget { get; set; }
        public virtual decimal? OriginalLaborBudget { get; set; }
        public virtual int? OriginalMarginPercent { get; set; }
        public virtual bool? HasHouseFileDoc { get; set; }
        public virtual bool? ReplacesFeature { get; set; }
        public virtual decimal? LaborBudgetAdjustment { get; set; }
        public virtual decimal? MaterialBudgetAdjustment { get; set; }
        public virtual string BudgetAdjustmentOption { get; set; }

    }
}

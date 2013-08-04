using System.Linq;

namespace TIPS.Pricing
{
    public class Option
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public string CommunityID { get; set; }
        public string PlanNumber { get; set; }
        public string Elevation { get; set; }
        public string OptionType { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public string OptionCategory { get; set; }
        public string SubCategory { get; set; }
        public decimal? Price { get; set; }
        public int? StageCutoff { get; set; }
        public bool? AttributesRequired { get; set; }
        public bool? InGroup { get; set; }
        public bool? HasDetails { get; set; }
        public string UOM { get; set; }
        public decimal? MaterialBudget { get; set; }
        public decimal? LaborBudget { get; set; }
        public string OriginalDescription { get; set; }
        public string SelectBy { get; set; }
        public string ImageURL { get; set; }
        public string Family { get; set; }
        public string Finish { get; set; }
        public string Template { get; set; }
        public string ProductLevel { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeGroup { get; set; }
        public string Item { get; set; }
        public decimal? RoomSize { get; set; }
        public string RoomUOM { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? UnitCredit { get; set; }
        public int? MarginPercent { get; set; }
        public decimal? BaseOptionBudget { get; set; }
        public decimal? BaseBudgetCostFactor { get; set; }
        public decimal? BaseBudgetCreditFactor { get; set; }
        public decimal? WasteFactor { get; set; }
        public bool? Proforma { get; set; }
        public bool? UseDynamicPricing { get; set; }
        public string PricingUOM { get; set; }
        public decimal? MinSalesPrice { get; set; }
        public bool IsPlanIncluded { get; set; }

        public bool IsSelected
        {
            get { return Quantity >= 0; }
        }


        /*

         * Properties only for selected options
        
        public long OptionSelectionID { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? PaymentType { get; set; }
        public DateTime? DateSelected { get; set; }
        public bool? SelectedAfterCutoff { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? Approved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? PlanIncluded { get; set; }
        public bool? OptionInJDE { get; set; }
        public bool? IncludedInWebPrice { get; set; }
        public bool? HasHouseFileDoc { get; set; }
        public decimal? RoomSizeAdditions { get; set; }
        public decimal? RoomSizeSubtractions { get; set; }
        public decimal? AdjustedRoomSize { get; set; }
        public decimal? AdjustedPrice { get; set; }

        */

        public bool IsFeature()
        {
            return !string.IsNullOrEmpty(Template) && Template.StartsWith(TipsConstants.TemplatePrefixes.Feature);
        }

        public bool IsFeatureRelatedToFlexOption()
        {
            return IsFeature() && Template.StartsWith(TipsConstants.TemplatePrefixes.Feature + "-");
        }

        public bool IsFeatureRelatedToFlexOption(Option option)
        {
            return IsFeatureRelatedToFlexOption(option.Number);
        }

        public bool IsFeatureRelatedToFlexOption(string optionNumber)
        {
            return IsFeatureRelatedToFlexOption() && Template == TipsConstants.TemplatePrefixes.Feature + "-" + optionNumber;
        }

        public bool IsBaseHomeFeature()
        {
            return IsFeature() && Template == TipsConstants.TemplatePrefixes.Feature;
        }

        public bool IsUpgrade()
        {
            return !string.IsNullOrEmpty(Template) && Template.StartsWith(TipsConstants.TemplatePrefixes.Upgrade);
        }

        public bool IsUpgradeRelatedToFlexOption()
        {
            return IsUpgrade() && Template.StartsWith(TipsConstants.TemplatePrefixes.Upgrade + "-");
        }

        public bool IsBaseHomeUpgrade()
        {
            return IsUpgrade() && Template == TipsConstants.TemplatePrefixes.Upgrade;
        }

        public bool IsWholeHome()
        {
            return Room == TipsConstants.Rooms.WholeHome;
        }

        public virtual bool IsPackage()
        {
            return false;
        }

        public bool IsPlanSpecific()
        {
            return !string.IsNullOrWhiteSpace(PlanNumber);
        }

        public bool IsElevationSpecific()
        {
            return IsPlanSpecific() && !string.IsNullOrWhiteSpace(Elevation);
        }

        public bool IsPurchasing2Option()
        {
            return !string.IsNullOrWhiteSpace(ProductType) ||
                   TipsConstants.CategoryCodes.CategoryCodesWithoutProductTypes.Contains(OptionCategory);
        }

        public bool IsPurchasing1Option()
        {
            return string.IsNullOrWhiteSpace(ProductType);
        }

        public bool IsFlexSpace()
        {
            return OptionCategory == TipsConstants.CategoryCodes.FlexSpace;
        }


    }
}

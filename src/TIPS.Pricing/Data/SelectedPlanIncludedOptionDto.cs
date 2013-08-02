namespace TIPS.Pricing.Data
{
    internal class SelectedPlanIncludedOptionDto 
    {
        public virtual long OptionID { get; set; }

        public virtual string JobNumber { get; set; }
        public virtual string OptionNumber { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual string OptionCategory { get; set; }
        public virtual string Room { get; set; }
        public virtual string SubCategory { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ProductTypeGroup { get; set; }
        public virtual string OptionType { get; set; }
    }
}

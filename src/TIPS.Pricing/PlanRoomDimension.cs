namespace TIPS.Pricing
{
    public class PlanRoomDimension
    {
        public long Id { get; set; }
        public string PlanNumber { get; set; }
        public string Elevation { get; set; }
        public string Room { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeGroup { get; set; }
        public string OptionNumber { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public bool AllowCredit { get; set; }
        public bool IncludeInWholeHome { get; set; }
    }
}

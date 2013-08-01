namespace TIPS.Pricing
{
    public class SaleSummary
    {
        public virtual int SaleId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual string JobNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string CommunityCode { get; set; }
        public virtual string CommunityName { get; set; }
        public virtual string MarketCode { get; set; }
        public virtual string MarketName { get; set; }
    }
}
using System;

namespace TIPS.Pricing.Data
{
    internal class SaleDto
    {
        public virtual long SaleID { get; set; }
        public virtual long? OpportunityID { get; set; }
        public virtual string JobNumber { get; set; }
        public virtual string JobType { get; set; }
        public virtual string RecordType { get; set; }
        public virtual int? ContactID { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual string Swing { get; set; }
        public virtual decimal? BasePrice { get; set; }
        public virtual decimal? LotPremium { get; set; }
        public virtual DateTime? SaleDate { get; set; }
        public virtual DateTime? CancelDate { get; set; }
        public virtual DateTime? CloseDate { get; set; }
    }
}

using System.Collections.Generic;

namespace TIPS.Pricing
{
    public class Sale
    {

        public Sale()
        {
            PlanRooms = new List<PlanRoom>();
            PlanRoomDimensions = new List<PlanRoomDimension>();
            Options = new Dictionary<long, Option>();
            Hcrs = new List<HCR>();
            Incentives = new List<Incentive>();
        }

        public string Id { get; set; }
        public long SaleId { get; set; }
        public long OpportunityId { get; set; }
        public string JobNumber { get; set; }
        public string CustomerName { get; set; }
        public string PlanNumber { get; set; }
        public string Elevation { get; set; }
        public string Swing { get; set; }
        public decimal BasePrice { get; set; }
        public decimal LotPremium { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CommunityId { get; set; }
        public string CommunityName { get; set; }
        public bool IsPurchasing20 { get; set; }

        public List<PlanRoom> PlanRooms { get; private set; }
        public List<PlanRoomDimension> PlanRoomDimensions { get; private set; }
        public Dictionary<long, Option> Options { get; private set; }
        public List<HCR> Hcrs { get; private set; }
        public List<Incentive> Incentives { get; private set; }

    }
}

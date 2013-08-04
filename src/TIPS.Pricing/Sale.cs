using System;
using System.Collections.Generic;
using System.Linq;
using TIPS.Pricing.Data;

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

        public List<PlanRoom> PlanRooms { get; private set; }
        public List<PlanRoomDimension> PlanRoomDimensions { get; private set; }
        public Dictionary<long, Option> Options { get; private set; }
        public List<HCR> Hcrs { get; private set; }
        public List<Incentive> Incentives { get; private set; }

        private void ParseSaleDto(SaleDto saleDto)
        {
            if (saleDto == null) throw new ArgumentNullException("saleDto");
            SaleId = saleDto.SaleID;
            OpportunityId = saleDto.OpportunityID.Value;
            JobNumber = saleDto.JobNumber;
            CustomerName = saleDto.CustomerName;
            PlanNumber = saleDto.PlanNumber;
            Elevation = saleDto.Elevation;
            Swing = saleDto.Swing;
            BasePrice = saleDto.BasePrice.Value;
            LotPremium = saleDto.LotPremium.Value;
        }


    }
}

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

        public Sale(SaleCompositeData data) : this()
        {
            if (data == null) throw new ArgumentNullException("data");
            ParseSaleDto(data.Sale);
            PlanRooms.AddRange(data.PlanRooms.Select(pr => new PlanRoom(pr)));
            PlanRoomDimensions.AddRange(data.PlanRoomDimensions.Select(prd => new PlanRoomDimension(prd)));

            data.SelectedOptions
                .Select(so => new Option(so))
                .ToList()
                .ForEach(o => Options[o.Id] = o);

            data.AvailableOptions
                .Where(ao => !Options.ContainsKey(ao.OptionID))
                .Select(ao => new Option(ao))
                .ToList()
                .ForEach(o => Options[o.Id] = o);

            data.PlanIncludedOptions
                .Where(pio => !Options.ContainsKey(pio.OptionID))
                .Select(pio => new Option(pio))
                .ToList()
                .ForEach(o => Options[o.Id] = o);

            data.PlanIncludedOptions
                .ToList()
                .ForEach(pio => Options[pio.OptionID].IsPlanIncluded = true);

            data.SelectedPlanIncludedOptions
                .Where(spio => !Options.ContainsKey(spio.OptionID))
                .Select(spio => new Option(spio))
                .ToList()
                .ForEach(o => Options[o.Id] = o);

            data.SelectedPlanIncludedOptions
                .ToList()
                .ForEach(spio =>
                    {
                        var o = Options[spio.OptionID];
                        o.Quantity = o.Quantity > 0 ? o.Quantity : 1; // Must be selected
                        o.IsPlanIncluded = true;
                    });

            Hcrs.AddRange(data.HCRs.Select(dto => new HCR(dto)));

            Incentives.AddRange(data.Incentives.Select(dto => new Incentive(dto)));
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

using System.Collections.Generic;
using TIPS.Pricing.Data;

namespace TIPS.Pricing
{
    public class SaleData
    {
        public List<PlanRoomDto> PlanRooms { get; set; }

        public List<PlanRoomDimensionDto> PlanRoomDimensions { get; set; }

        public List<SelectedOptionDto> SelectedOptions { get; set; }

        public List<PlanIncludedOptionDto> PlanIncludedOptions { get; set; }

        public List<SelectedPlanIncludedOptionDto> SelectedPlanIncludedOptions { get; set; }

        public List<HCRDto> HCRs { get; set; }

        public List<AvailableOptionDto> AvailableOptions { get; set; }

        public List<IncentiveDto> Incentives { get; set; }

        public List<OptionExclusionDto> OptionExclusions { get; set; }

        public List<OptionPrereqDto> OptionPrereqs { get; set; }
    }
}

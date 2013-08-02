using System.Collections.Generic;

namespace TIPS.Pricing.Data
{
    public class SaleCompositeData
    {
        internal SaleDto Sale { get; set; }

        internal List<PlanRoomDto> PlanRooms { get; set; }

        internal List<PlanRoomDimensionDto> PlanRoomDimensions { get; set; }

        internal List<SelectedOptionDto> SelectedOptions { get; set; }

        internal List<AvailableOptionDto> AvailableOptions { get; set; }

        internal List<PlanIncludedOptionDto> PlanIncludedOptions { get; set; }

        internal List<SelectedPlanIncludedOptionDto> SelectedPlanIncludedOptions { get; set; }

        internal List<HCRDto> HCRs { get; set; }

        internal List<IncentiveDto> Incentives { get; set; }

        internal List<OptionExclusionDto> OptionExclusions { get; set; }

        internal List<OptionPrereqDto> OptionPrereqs { get; set; }

        internal List<ComponentDto> Components { get; set; }

        internal List<CommunityComponentDto> CommunityComponents { get; set; }

        internal List<AssemblyDto> Assemblies { get; set; }

        internal List<CommunityAssemblyDto> CommunityAssemblies { get; set; }

        internal List<CommunityItemDto> CommunityItems { get; set; }

        internal List<ItemDto> Items { get; set; }
    }
}

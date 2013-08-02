using System.Linq;
using NHibernate;

namespace TIPS.Pricing.Data
{
    public class SaleQuery : Query
    {
        public SaleQuery(ISession session) : base(session)
        {
        }

        public SaleCompositeData Execute(long saleId)
        {
            var planRooms = Session.GetNamedQuery("PlanRoomsQuery")
                           .SetParameter("SaleId", saleId)
                           .Future<PlanRoomDto>();

            var planRoomDimensions = Session.GetNamedQuery("PlanRoomDimensionsQuery")
                                            .SetParameter("SaleId", saleId)
                                            .Future<PlanRoomDimensionDto>();

            var selectedOptions = Session.GetNamedQuery("SelectedOptionsQuery")
                                         .SetParameter("SaleId", saleId)
                                         .Future<SelectedOptionDto>();

            var planIncludedOptions = Session.GetNamedQuery("PlanIncludedOptionsQuery")
                                         .SetParameter("SaleId", saleId)
                                         .Future<PlanIncludedOptionDto>();

            var selectedPlanIncludedOptions = Session.GetNamedQuery("SelectedPlanIncludedOptionsQuery")
                                                     .SetParameter("SaleId", saleId)
                                                     .Future<SelectedPlanIncludedOptionDto>();

            var hcrs = Session.GetNamedQuery("HCRsQuery")
                              .SetParameter("SaleId", saleId)
                              .Future<HCRDto>();

            var availableOptions = Session.GetNamedQuery("AvailableOptionsQuery")
                                          .SetParameter("SaleId", saleId)
                                          .Future<AvailableOptionDto>();

            var incentives = Session.GetNamedQuery("IncentivesQuery")
                                    .SetParameter("SaleId", saleId)
                                    .Future<IncentiveDto>();

            var optionExclusions = Session.GetNamedQuery("OptionExclusionsQuery")
                                          .SetParameter("SaleId", saleId)
                                          .Future<OptionExclusionDto>();

            var optionPrereqs = Session.GetNamedQuery("OptionPrereqsQuery")
                                       .SetParameter("SaleId", saleId)
                                       .Future<OptionPrereqDto>();

            var sale = Session.GetNamedQuery("SaleQuery")
                              .SetParameter("SaleId", saleId)
                              .FutureValue<SaleDto>();

            var data = new SaleCompositeData()
                {
                    Sale = sale.Value,
                    PlanRooms = planRooms.ToList(),
                    PlanRoomDimensions = planRoomDimensions.ToList(),
                    SelectedOptions = selectedOptions.ToList(),
                    PlanIncludedOptions = planIncludedOptions.ToList(),
                    SelectedPlanIncludedOptions = selectedPlanIncludedOptions.ToList(),
                    HCRs = hcrs.ToList(),
                    AvailableOptions = availableOptions.ToList(),
                    Incentives = incentives.ToList(),
                    OptionExclusions = optionExclusions.ToList(),
                    OptionPrereqs = optionPrereqs.ToList()
                };

            return data;
        }

    }
}

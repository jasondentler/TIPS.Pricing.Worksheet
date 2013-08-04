using System.IO;
using System.Linq;
using System.Reflection;
using NHibernate;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TIPS.Pricing.Data
{
    public class SaleQuery : Query
    {
        public SaleQuery(ISession session) : base(session)
        {
        }

        public Sale Execute(long saleId)
        {
            var saleData = ExecuteQuery(saleId);
            var sale = saleData.BuildSale();
            return sale;
        }

        internal SaleCompositeData ExecuteQuery(long saleId)
        {

            var cacheFile = Path.Combine(Path.GetTempPath(), saleId + ".json");
            

            var dcr = new DefaultContractResolver();
            dcr.DefaultMembersSearchFlags |= BindingFlags.NonPublic;
            var jss = new JsonSerializerSettings();
            jss.ContractResolver = dcr;

            //if (File.Exists(cacheFile))
            //{
            //    var deserializedData = File.ReadAllText(cacheFile);
            //    return JsonConvert.DeserializeObject<SaleCompositeData>(deserializedData, jss);
            //}

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

            var packageComponents = Session.GetNamedQuery("PackageComponentsQuery")
                                    .SetParameter("SaleId", saleId)
                                    .Future<PackageComponentDto>();

            var communityPackageComponents = Session.GetNamedQuery("CommunityPackageComponentsQuery")
                                             .SetParameter("SaleId", saleId)
                                             .Future<CommunityPackageComponentDto>();

            var assemblyComponents = Session.GetNamedQuery("AssemblyComponentsQuery")
                                    .SetParameter("SaleId", saleId)
                                    .Future<AssemblyComponentDto>();

            var communityAssemblyComponents = Session.GetNamedQuery("CommunityAssemblyComponentsQuery")
                                             .SetParameter("SaleId", saleId)
                                             .Future<CommunityAssemblyComponentDto>();

            var items = Session.GetNamedQuery("ItemsQuery")
                                        .SetParameter("SaleId", saleId)
                                        .Future<ItemDto>();

            var communityItems = Session.GetNamedQuery("CommunityItemsQuery")
                                        .SetParameter("SaleId", saleId)
                                        .Future<CommunityItemDto>();

            var sale = Session.GetNamedQuery("SaleQuery")
                              .SetParameter("SaleId", saleId)
                              .FutureValue<SaleDto>();

            availableOptions = availableOptions
                .Where(dto => string.IsNullOrWhiteSpace(dto.Elevation) || dto.Elevation == sale.Value.Elevation);

            //var allOptionIds = selectedOptions.Select(dto => dto.OptionID)
            //                                  .Union(availableOptions.Select(dto => dto.OptionID))
            //                                  .Union(planIncludedOptions.Select(dto => dto.OptionID))
            //                                  .Union(selectedPlanIncludedOptions.Select(dto => dto.OptionID))
            //                                  .Union(hcrs.Select(dto => dto.PlanIncludedOptionID ?? 0))
            //                                  .Union(incentives.Select(dto => dto.OptionID ?? 0))
            //                                  .Distinct()
            //                                  .ToArray();

            //components = components.Where(dto => allOptionIds.Contains(dto.OptionID));
            //communityComponents = communityComponents.Where(dto => allOptionIds.Contains(dto.OptionID));
            //assemblies = assemblies.Where(dto => allOptionIds.Contains(dto.OptionID));
            //communityAssemblies = communityAssemblies
            //    .Where(dto => dto.PlanNumber == sale.Value.PlanNumber && dto.Elevation == sale.Value.Elevation);

            //items = items.Where(dto => !dto.OptionID.HasValue || allOptionIds.Contains(dto.OptionID.Value));
            
            var saleCompositeData = new SaleCompositeData()
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
                    OptionPrereqs = optionPrereqs.ToList(),
                    PackageComponents = packageComponents.ToList(),
                    CommunityPackageComponents = communityPackageComponents.ToList(),
                    AssemblyComponents = assemblyComponents.ToList(),
                    CommunityAssemblyComponents = communityAssemblyComponents.ToList(),
                    Items = items.ToList(),
                    CommunityItems = communityItems.ToList()
                };

            var serializedData = JsonConvert.SerializeObject(saleCompositeData, jss);
            File.WriteAllText(cacheFile, serializedData);

            return saleCompositeData;
        }

    }
}

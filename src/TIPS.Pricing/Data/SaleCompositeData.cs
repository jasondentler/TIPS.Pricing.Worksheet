using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TIPS.Pricing.Data
{
    public class SaleCompositeData
    {

        public SaleCompositeData()
        {
            Sale = new SaleDto();
            PlanRooms = new List<PlanRoomDto>();
            PlanRoomDimensions = new List<PlanRoomDimensionDto>();
            SelectedOptions = new List<SelectedOptionDto>();
            AvailableOptions = new List<AvailableOptionDto>();
            PlanIncludedOptions = new List<PlanIncludedOptionDto>();
            SelectedPlanIncludedOptions = new List<SelectedPlanIncludedOptionDto>();
            HCRs = new List<HCRDto>();
            Incentives = new List<IncentiveDto>();
            OptionExclusions = new List<OptionExclusionDto>();
            OptionPrereqs = new List<OptionPrereqDto>();
            PackageComponents = new List<PackageComponentDto>();
            CommunityPackageComponents = new List<CommunityPackageComponentDto>();
            AssemblyComponents = new List<AssemblyComponentDto>();
            CommunityAssemblyComponents = new List<CommunityAssemblyComponentDto>();
            CommunityItems = new List<CommunityItemDto>();
            Items = new List<ItemDto>();
        }

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

        internal List<PackageComponentDto> PackageComponents { get; set; }

        internal List<CommunityPackageComponentDto> CommunityPackageComponents { get; set; }

        internal List<AssemblyComponentDto> AssemblyComponents { get; set; }

        internal List<CommunityAssemblyComponentDto> CommunityAssemblyComponents { get; set; }

        internal List<CommunityItemDto> CommunityItems { get; set; }

        internal List<ItemDto> Items { get; set; }

        public Sale BuildSale()
        {

            var planRooms = PlanRooms.Select(Mapper.Map<PlanRoom>).ToList();
            var planRoomDimensions = PlanRoomDimensions.Select(Mapper.Map<PlanRoomDimension>).ToList();

            // Items & CommunityItems make up Items (non-assembly package items)
            // if item.ItemType == "ASM", then it's an assembly
            //    and components are loaded where AssemblyItemId = assembly's ItemId

            var items = Items
                .Select(Convert)
                .ToDictionary(i => i.Id, i => i);

            var communityItems = CommunityItems
                .Select(Convert)
                .ToDictionary(i => i.Id, i => i);

            var packageComponents = PackageComponents
                .Select(dto => Tuple.Create(dto.OptionID, dto.ComponentItemID))
                .GroupBy(t => t.Item1, t => t.Item2)
                .ToDictionary(g => g.Key, g => g.ToArray());

            var communityPackageComponents = CommunityPackageComponents
                .Select(dto => Tuple.Create(dto.OptionID, dto.ComponentItemID))
                .GroupBy(t => t.Item1, t => t.Item2)
                .ToDictionary(g => g.Key, g => g.ToArray());

            var assemblyComponents = AssemblyComponents
                .Select(dto => Tuple.Create(dto.AssemblyItemID, Convert(dto, Sale.Swing, items, communityItems)))
                .ToList();

            var communityAssemblyComponents = CommunityAssemblyComponents
                .Select(dto => Tuple.Create(dto.AssemblyItemID, Convert(dto, Sale.Swing, items, communityItems)))
                .ToList();

            var assemblies = items.OfType<Assembly>().Concat(communityItems.OfType<Assembly>());

            foreach (var assembly in assemblies)
            {
                var components = assemblyComponents.Where(t => t.Item1 == assembly.Id).ToArray();
                if (!components.Any())
                    components = communityAssemblyComponents.Where(t => t.Item1 == assembly.Id).ToArray();
                assembly.Components.AddRange(components.Select(t => t.Item2));
            }

            var options = SelectedOptions
                .Select(Convert)
                .ToDictionary(o => o.Id, o => o);

            AvailableOptions
                .Where(dto => !options.ContainsKey(dto.OptionID))
                .Select(Convert)
                .ToList()
                .ForEach(o => options[o.Id] = o);

            PlanIncludedOptions
                .Select(o => o.OptionID)
                .ToList()
                .ForEach(optionId => options[optionId].IsPlanIncluded = true);

            SelectedPlanIncludedOptions
                .Select(o => o.OptionID)
                .ToList()
                .ForEach(optionId =>
                    {
                        var option = options[optionId];
                        option.IsPlanIncluded = true;
                        option.Quantity = option.Quantity > 0 ? option.Quantity : 1;
                    });

            var hcrs = HCRs.Select(dto => new HCR(dto)).ToList();

            var incentives = Incentives.Select(dto => new Incentive(dto)).ToList();

            var sale = new Sale();

            Mapper.Map(Sale, sale);

            sale.PlanRooms.AddRange(planRooms);
            
            sale.PlanRoomDimensions.AddRange(planRoomDimensions);
            
            foreach (var option in options.Values)
                sale.Options[option.Id] = option;

            var packages = options.Values.OfType<Package>();

            foreach (var package in packages)
                LoadPackageComponents(package, packageComponents, communityPackageComponents, items, communityItems);

            sale.Hcrs.AddRange(hcrs);
            
            sale.Incentives.AddRange(incentives);

            return sale;
        }

        private static void LoadPackageComponents(Package package,
                                           Dictionary<long, long[]> packageComponents,
                                           Dictionary<long, long[]> communityPackageComponents,
                                           Dictionary<long, Item> items,
                                           Dictionary<long, Item> communityItems)
        {
            long[] componentIds;
            if (!packageComponents.TryGetValue(package.Id, out componentIds))
                if (!communityPackageComponents.TryGetValue(package.Id, out componentIds))
                    throw new ApplicationException("Could not find package components for package id " + package.Id);

            foreach (var componentId in componentIds)
            {
                Item item;
                if (!items.TryGetValue(componentId, out item))
                    if (!communityItems.TryGetValue(componentId, out item))
                        throw new ApplicationException(string.Format("Package {0} uses item {1}, which was not found.",
                                                                     package.Id, componentId));

                package.Items.Add(item);
            }

        }

        private static Option Convert(IOptionDto dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            var option = dto.IsPackage() 
                ? new Package() 
                : new Option();
            Mapper.Map(dto, option, dto.GetType(), option.GetType());
            return option;
        }

        private static Item Convert(IItemDto dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            var item = dto.IsAssembly() ? new Assembly() : new Item();
            Mapper.Map(dto, item, dto.GetType(), item.GetType());
            return item;
        }

        private static AssemblyComponent Convert(IAssemblyComponentDto dto, string swing, Dictionary<long, Item> items,
                                                 Dictionary<long, Item> communityItems)
        {
            var componentItemId = dto.GetSwingAppropriateItemId(swing);
            Item componentItem;

            if (!items.TryGetValue(componentItemId, out componentItem))
                if (!communityItems.TryGetValue(componentItemId, out componentItem))
                    throw new ApplicationException(string.Format("Assembly {0} uses item {1}, which was not found.",
                                                                 dto.AssemblyItemID, componentItemId));
            return new AssemblyComponent()
                {
                    ProductType = dto.ProductType,
                    QuantityMultiplier = dto.AssemblyQuantity ?? 0M,
                    Item = componentItem
                };
        }

    }
}

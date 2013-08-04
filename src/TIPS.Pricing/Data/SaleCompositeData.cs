using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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

        internal List<PackageComponentDto> PackageComponents { get; set; }

        internal List<CommunityPackageComponentDto> CommunityPackageComponents { get; set; }

        internal List<AssemblyComponentDto> AssemblyComponents { get; set; }

        internal List<CommunityAssemblyComponentDto> CommunityAssemblyComponents { get; set; }

        internal List<CommunityItemDto> CommunityItems { get; set; }

        internal List<ItemDto> Items { get; set; }

        public Sale BuildSale()
        {

            var planRooms = PlanRooms.Select(dto => new PlanRoom(dto)).ToList();
            var planRoomDimensions = PlanRoomDimensions.Select(dto => new PlanRoomDimension(dto)).ToList();

            // Items & CommunityItems make up Items (non-assembly package items)
            // if item.ItemType == "ASM", then it's an assembly
            //    and components are loaded where AssemblyItemId = assembly's ItemId

            var items = Items.Select(Convert).ToList();
            var communityItems = CommunityItems.Select(Convert).ToList();

            var packageComponents = PackageComponents
                .Select(dto => Tuple.Create(dto.OptionID, Convert(dto, items, communityItems)))
                .ToList();

            var communityPackageComponents = CommunityPackageComponents
                .Select(dto => Tuple.Create(dto.OptionID, Convert(dto, items, communityItems)))
                .ToList();

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

            foreach (var package in options.Values.OfType<Package>())
            {
                var components = packageComponents.Where(t => t.Item1 == package.Id).ToArray();
                if (!components.Any())
                    components = communityPackageComponents.Where(t => t.Item1 == package.Id).ToArray();
                package.Components.AddRange(components.Select(t => t.Item2));
            }

            sale.Hcrs.AddRange(hcrs);
            
            sale.Incentives.AddRange(incentives);

            return sale;
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

        private static PackageComponent Convert(IPackageComponentDto dto, IEnumerable<Item> items,
                                                IEnumerable<Item> communityItems)
        {
            return new PackageComponent()
                {
                    UnitOfMeasure = dto.UOM,
                    ProductType = dto.ProductType,
                    Item = items.FirstOrDefault(i => i.Id == dto.ComponentItemID)
                           ?? communityItems.FirstOrDefault(i => i.Id == dto.ComponentItemID)
                };
        }

        private static AssemblyComponent Convert(IAssemblyComponentDto dto, string swing, IEnumerable<Item> items,
                                                 IEnumerable<Item> communityItems)
        {
            var componentItemId = dto.GetSwingAppropriateItemId(swing);
            return new AssemblyComponent()
                {
                    ProductType = dto.ProductType,
                    QuantityMultiplier = dto.AssemblyQuantity ?? 0M,
                    Item = items.FirstOrDefault(i => i.Id == componentItemId)
                           ?? communityItems.FirstOrDefault(i => i.Id == componentItemId)
                };
        }

    }
}

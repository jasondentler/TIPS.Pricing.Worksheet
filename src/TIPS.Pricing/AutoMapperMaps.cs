using AutoMapper;
using TIPS.Pricing.Data;

namespace TIPS.Pricing
{
    public static class AutoMapperMaps
    {

        public static void Setup()
        {

            Mapper.CreateMap<SaleDto, Sale>()
                  .ForMember(s => s.OpportunityId, mo => mo.ResolveUsing(dto => dto.OpportunityID.Value))
                  .ForMember(s => s.BasePrice, mo => mo.ResolveUsing(dto => dto.BasePrice.Value))
                  .ForMember(s => s.LotPremium, mo => mo.ResolveUsing(dto => dto.LotPremium.Value));

            Mapper.CreateMap<SelectedOptionDto, Option>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.Quantity, mo => mo.ResolveUsing(dto => dto.Quantity > 0 ? dto.Quantity : 1));

            Mapper.CreateMap<SelectedOptionDto, Package>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.Quantity, mo => mo.ResolveUsing(dto => dto.Quantity > 0 ? dto.Quantity : 1));

            Mapper.CreateMap<AvailableOptionDto, Option>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

            Mapper.CreateMap<AvailableOptionDto, Package>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

            Mapper.CreateMap<PlanIncludedOptionDto, Option>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.IsPlanIncluded, mo => mo.UseValue(true));

            Mapper.CreateMap<PlanIncludedOptionDto, Package>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.IsPlanIncluded, mo => mo.UseValue(true));

            Mapper.CreateMap<SelectedPlanIncludedOptionDto, Option>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.Quantity, mo => mo.UseValue(1))
                  .ForMember(o => o.IsPlanIncluded, mo => mo.UseValue(true));

            Mapper.CreateMap<SelectedPlanIncludedOptionDto, Package>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.Quantity, mo => mo.UseValue(1))
                  .ForMember(o => o.IsPlanIncluded, mo => mo.UseValue(true));

            Mapper.CreateMap<HCRDto, HCR>()
                  .ForMember(hcr => hcr.Id, mo => mo.MapFrom(dto => dto.HCRID))
                  .ForMember(hcr => hcr.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(hcr => hcr.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

            Mapper.CreateMap<IncentiveDto, Incentive>()
                  .ForMember(incentive => incentive.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(incentive => incentive.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(incentive => incentive.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

            Mapper.CreateMap<ItemDto, Item>()
                  .ForMember(i => i.Id, mo => mo.MapFrom(dto => dto.ItemID.Value))
                  .ForMember(i => i.OppositeItemId, mo => mo.MapFrom(dto => dto.OppositeItemID))
                  .ForMember(i => i.QuantityRoundingMultiple, mo => mo.ResolveUsing(dto => dto.Rounding.HasValue ? dto.Rounding.Value : 0M))
                  .ForMember(i => i.UnitCost, mo => mo.ResolveUsing(dto => dto.UnitCost.HasValue ? dto.UnitCost.Value : 0M))
                  .ForMember(i => i.UnitCredit, mo => mo.ResolveUsing(dto => dto.UnitCredit.HasValue ? dto.UnitCredit.Value : 0M))
                  .ForMember(i => i.WasteFactor, mo => mo.ResolveUsing(dto => dto.WasteFactor.HasValue ? dto.WasteFactor.Value : 0M))
                  .ForMember(i => i.IsTaxable, mo => mo.ResolveUsing(dto => dto.Taxable.HasValue && dto.Taxable.Value));

            Mapper.CreateMap<ItemDto, Assembly>()
                  .ForMember(i => i.Id, mo => mo.MapFrom(dto => dto.ItemID.Value))
                  .ForMember(i => i.OppositeItemId, mo => mo.MapFrom(dto => dto.OppositeItemID))
                  .ForMember(i => i.QuantityRoundingMultiple, mo => mo.ResolveUsing(dto => dto.Rounding.HasValue ? dto.Rounding.Value : 0M))
                  .ForMember(i => i.UnitCost, mo => mo.ResolveUsing(dto => dto.UnitCost.HasValue ? dto.UnitCost.Value : 0M))
                  .ForMember(i => i.UnitCredit, mo => mo.ResolveUsing(dto => dto.UnitCredit.HasValue ? dto.UnitCredit.Value : 0M))
                  .ForMember(i => i.WasteFactor, mo => mo.ResolveUsing(dto => dto.WasteFactor.HasValue ? dto.WasteFactor.Value : 0M))
                  .ForMember(i => i.IsTaxable, mo => mo.ResolveUsing(dto => dto.Taxable.HasValue && dto.Taxable.Value));

            Mapper.CreateMap<CommunityItemDto, Item>()
                  .ForMember(i => i.Id, mo => mo.MapFrom(dto => dto.ItemID))
                  .ForMember(i => i.OppositeItemId, mo => mo.MapFrom(dto => dto.OppositeItemID))
                  .ForMember(i => i.QuantityRoundingMultiple, mo => mo.ResolveUsing(dto => dto.Rounding.HasValue ? dto.Rounding.Value : 0M))
                  .ForMember(i => i.UnitCost, mo => mo.ResolveUsing(dto => dto.UnitCost.HasValue ? dto.UnitCost.Value : 0M))
                  .ForMember(i => i.UnitCredit, mo => mo.ResolveUsing(dto => dto.UnitCredit.HasValue ? dto.UnitCredit.Value : 0M))
                  .ForMember(i => i.WasteFactor, mo => mo.ResolveUsing(dto => dto.WasteFactor.HasValue ? dto.WasteFactor.Value : 0M))
                  .ForMember(i => i.IsTaxable, mo => mo.ResolveUsing(dto => dto.Taxable.HasValue && dto.Taxable.Value));

            Mapper.CreateMap<CommunityItemDto, Assembly>()
                  .ForMember(i => i.Id, mo => mo.MapFrom(dto => dto.ItemID))
                  .ForMember(i => i.OppositeItemId, mo => mo.MapFrom(dto => dto.OppositeItemID))
                  .ForMember(i => i.QuantityRoundingMultiple, mo => mo.ResolveUsing(dto => dto.Rounding.HasValue ? dto.Rounding.Value : 0M))
                  .ForMember(i => i.UnitCost, mo => mo.ResolveUsing(dto => dto.UnitCost.HasValue ? dto.UnitCost.Value : 0M))
                  .ForMember(i => i.UnitCredit, mo => mo.ResolveUsing(dto => dto.UnitCredit.HasValue ? dto.UnitCredit.Value : 0M))
                  .ForMember(i => i.WasteFactor, mo => mo.ResolveUsing(dto => dto.WasteFactor.HasValue ? dto.WasteFactor.Value : 0M))
                  .ForMember(i => i.IsTaxable, mo => mo.ResolveUsing(dto => dto.Taxable.HasValue && dto.Taxable.Value));

        }

    }
}

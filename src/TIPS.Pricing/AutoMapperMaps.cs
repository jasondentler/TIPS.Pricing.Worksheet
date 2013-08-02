using AutoMapper;
using TIPS.Pricing.Data;

namespace TIPS.Pricing
{
    public static class AutoMapperMaps
    {

        public static void Setup()
        {
            Mapper.CreateMap<SelectedOptionDto, Option>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory))
                  .ForMember(o => o.Quantity, mo => mo.ResolveUsing(dto => dto.Quantity > 0 ? dto.Quantity : 1));

            Mapper.CreateMap<AvailableOptionDto, Option>()
                  .ForMember(o => o.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(o => o.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(o => o.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

            Mapper.CreateMap<PlanIncludedOptionDto, Option>()
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

            Mapper.CreateMap<HCRDto, HCR>()
                  .ForMember(hcr => hcr.Id, mo => mo.MapFrom(dto => dto.HCRID))
                  .ForMember(hcr => hcr.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(hcr => hcr.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

            Mapper.CreateMap<IncentiveDto, Incentive>()
                  .ForMember(incentive => incentive.Id, mo => mo.MapFrom(dto => dto.OptionID))
                  .ForMember(incentive => incentive.Number, mo => mo.MapFrom(dto => dto.OptionNumber))
                  .ForMember(incentive => incentive.Category, mo => mo.MapFrom(dto => dto.OptionCategory));

        }

    }
}

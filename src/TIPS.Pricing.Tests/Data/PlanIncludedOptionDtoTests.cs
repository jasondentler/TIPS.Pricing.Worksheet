using System;
using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class PlanIncludedOptionDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToOption()
        {
            var dto = new PlanIncludedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category"
            };
            var option = Mapper.Map<Option>(dto);
            option.Id.ShouldEqual(dto.OptionID);
            option.Number.ShouldEqual(dto.OptionNumber);
            option.Category.ShouldEqual(dto.OptionCategory);
            option.Quantity.ShouldEqual(0);
            option.IsPlanIncluded.ShouldBeTrue();
        }

        [Fact]
        public void MapToPackage()
        {
            var dto = new PlanIncludedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category"
            };
            var option = Mapper.Map<Package>(dto);

            option.Id.ShouldEqual(dto.OptionID);
            option.Number.ShouldEqual(dto.OptionNumber);
            option.Category.ShouldEqual(dto.OptionCategory);
            option.Quantity.ShouldEqual(0);
            option.IsPlanIncluded.ShouldBeTrue();
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

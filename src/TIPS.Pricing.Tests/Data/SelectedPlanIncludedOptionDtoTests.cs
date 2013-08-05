using System;
using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class SelectedPlanIncludedOptionDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToOption()
        {
            var dto = new SelectedPlanIncludedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category"
            };
            var option = Mapper.Map<Option>(dto);

            option.Id.ShouldEqual(dto.OptionID);
            option.Number.ShouldEqual(dto.OptionNumber);
            option.Category.ShouldEqual(dto.OptionCategory);
            option.IsSelected.ShouldBeTrue();
            option.IsPlanIncluded.ShouldBeTrue();
        }


        [Fact]
        public void MapToPackage()
        {
            var dto = new SelectedPlanIncludedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category"
            };
            var option = Mapper.Map<Package>(dto);

            option.Id.ShouldEqual(dto.OptionID);
            option.Number.ShouldEqual(dto.OptionNumber);
            option.Category.ShouldEqual(dto.OptionCategory);
            option.IsSelected.ShouldBeTrue();
            option.IsPlanIncluded.ShouldBeTrue();
        }


        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

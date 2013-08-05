using System;
using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class AvailableOptionDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToOption()
        {
            var dto = new AvailableOptionDto()
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
        }

        [Fact]
        public void MapToPackage()
        {
            var dto = new AvailableOptionDto()
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
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

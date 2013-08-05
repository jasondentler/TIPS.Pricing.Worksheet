using System;
using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class SelectedOptionDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToOption()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = 1
            };
            var option = Mapper.Map<Option>(dto);

            option.Id.ShouldEqual(dto.OptionID);
            option.Number.ShouldEqual(dto.OptionNumber);
            option.Category.ShouldEqual(dto.OptionCategory);
            option.Quantity.ShouldEqual(dto.Quantity.Value);
        }

        [Fact]
        public void MapToOptionWithZeroQuantity()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = 0
            };
            var option = Mapper.Map<Option>(dto);
            option.Quantity.ShouldEqual(1);
        }

        [Fact]
        public void MapToOptionWithNegativeQuantity()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = -2
            };
            var option = Mapper.Map<Option>(dto);
            option.Quantity.ShouldEqual(1);
        }

        [Fact]
        public void MapToOptionWithNullQuantity()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = null
            };
            var option = Mapper.Map<Option>(dto);
            option.Quantity.ShouldEqual(1);
        }

        [Fact]
        public void MapToPackage()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = 1
            };
            var option = Mapper.Map<Package>(dto);

            option.Id.ShouldEqual(dto.OptionID);
            option.Number.ShouldEqual(dto.OptionNumber);
            option.Category.ShouldEqual(dto.OptionCategory);
            option.Quantity.ShouldEqual(dto.Quantity.Value);
        }

        [Fact]
        public void MapToPackageWithZeroQuantity()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = 0
            };
            var option = Mapper.Map<Package>(dto);
            option.Quantity.ShouldEqual(1);
        }

        [Fact]
        public void MapToPackageWithNegativeQuantity()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = -2
            };
            var option = Mapper.Map<Package>(dto);
            option.Quantity.ShouldEqual(1);
        }

        [Fact]
        public void MapToPackageWithNullQuantity()
        {
            var dto = new SelectedOptionDto()
            {
                OptionID = 1234,
                OptionNumber = "NUMBER",
                OptionCategory = "Category",
                Quantity = null
            };
            var option = Mapper.Map<Package>(dto);
            option.Quantity.ShouldEqual(1);
        }


        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

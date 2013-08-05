using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class ItemDtoTests : IUseFixture<AutomapperFixture>
    {


        [Fact]
        public void CanMapToItem()
        {
            var dto = new ItemDto()
            {
                ItemID = 12345,
                OppositeItemID = 54321,
                Rounding = 10,
                UnitCost = 3,
                UnitCredit = 4,
                WasteFactor = 5,
                Taxable = true
            };

            var item = Mapper.Map<Item>(dto);

            item.Id.ShouldEqual(dto.ItemID.Value);
            item.OppositeItemId.ShouldEqual(dto.OppositeItemID.Value);
            item.QuantityRoundingMultiple.ShouldEqual(dto.Rounding.Value);
            item.UnitCost.ShouldEqual(dto.UnitCost.Value);
            item.UnitCredit.ShouldEqual(dto.UnitCredit.Value);
            item.WasteFactor.ShouldEqual(dto.WasteFactor.Value);
            item.IsTaxable.ShouldEqual(dto.Taxable.Value);
        }

        [Fact]
        public void CanMapToAssembly()
        {
            var dto = new ItemDto()
            {
                ItemID = 12345,
                OppositeItemID = 54321,
                Rounding = 10,
                UnitCost = 3,
                UnitCredit = 4,
                WasteFactor = 5,
                Taxable = true
            };

            var assembly = Mapper.Map<Assembly>(dto);

            assembly.Id.ShouldEqual(dto.ItemID.Value);
            assembly.OppositeItemId.ShouldEqual(dto.OppositeItemID.Value);
            assembly.QuantityRoundingMultiple.ShouldEqual(dto.Rounding.Value);
            assembly.UnitCost.ShouldEqual(dto.UnitCost.Value);
            assembly.UnitCredit.ShouldEqual(dto.UnitCredit.Value);
            assembly.WasteFactor.ShouldEqual(dto.WasteFactor.Value);
            assembly.IsTaxable.ShouldEqual(dto.Taxable.Value);
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

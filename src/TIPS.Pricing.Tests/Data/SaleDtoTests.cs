using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class SaleDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToSale()
        {

            var dto = new SaleDto()
                {
                    OpportunityID = 12345,
                    BasePrice = 2.50M,
                    LotPremium = 3.50M
                };

            var sale = Mapper.Map<Sale>(dto);

            sale.OpportunityId.ShouldEqual(dto.OpportunityID.Value);
            sale.BasePrice.ShouldEqual(dto.BasePrice.Value);
            sale.LotPremium.ShouldEqual(dto.LotPremium.Value);
        }

        public void SetFixture(AutomapperFixture data)
        {
        }

    }
}

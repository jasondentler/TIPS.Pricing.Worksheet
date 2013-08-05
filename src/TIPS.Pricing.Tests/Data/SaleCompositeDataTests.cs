using System;
using Should;
using Xunit;
using Xunit.Extensions;

namespace TIPS.Pricing.Data
{

    public class SaleCompositeDataTests : IUseFixture<AutomapperFixture>
    {

        [Theory, AutoFakeItEasyData]
        internal void SaleFromSaleDto(SaleDto dto)
        {
            var saleCompositeData = new SaleCompositeData() {Sale = dto};
            var sale = saleCompositeData.BuildSale();

            sale.Address.ShouldEqual(dto.Address);
            sale.BasePrice.ShouldEqual(dto.BasePrice.Value);
            sale.City.ShouldEqual(dto.City);
            sale.CommunityId.ShouldEqual(dto.CommunityId);
            sale.CommunityName.ShouldEqual(dto.CommunityName);
            sale.CustomerName.ShouldEqual(dto.CustomerName);
            sale.Elevation.ShouldEqual(dto.Elevation);
            sale.IsPurchasing20.ShouldEqual(dto.IsPurchasing20);
            sale.JobNumber.ShouldEqual(dto.JobNumber);
            sale.LotPremium.ShouldEqual(dto.LotPremium.Value);
            sale.OpportunityId.ShouldEqual(dto.OpportunityID.Value);
            sale.PlanNumber.ShouldEqual(dto.PlanNumber);
            sale.SaleId.ShouldEqual(dto.SaleID);
            sale.State.ShouldEqual(dto.State);
            sale.Swing.ShouldEqual(dto.Swing);
            sale.ZipCode.ShouldEqual(dto.ZipCode);
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

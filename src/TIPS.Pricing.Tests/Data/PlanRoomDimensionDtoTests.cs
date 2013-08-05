using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class PlanRoomDimensionDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToPlanRoomDimension()
        {
            var a = new PlanRoomDimensionDto()
                {
                    Id = 1234,
                    CityId = "HOU",
                    PlanNumber = "4567",
                    Elevation = "Z",
                    Room = "ROOM",
                    ProductType = "PRODUCTTYPE",
                    ProductTypeGroup = "PRODUCTTYPEGROUP",
                    OptionNumber = "OPTIONNUMBER",
                    UOM = "SF",
                    Quantity = 6.1M,
                    AllowCredit = true,
                    IncludeInWholeHome = true
                };
            
            var b = Mapper.Map<PlanRoomDimension>(a);
            b.Id.ShouldEqual(a.Id);
            b.PlanNumber.ShouldEqual(a.PlanNumber);
            b.Elevation.ShouldEqual(a.Elevation);
            b.Room.ShouldEqual(a.Room);
            b.ProductType.ShouldEqual(a.ProductType);
            b.ProductTypeGroup.ShouldEqual(a.ProductTypeGroup);
            b.OptionNumber.ShouldEqual(a.OptionNumber);
            b.UOM.ShouldEqual(a.UOM);
            b.Quantity.ShouldEqual(a.Quantity);
            b.AllowCredit.ShouldEqual(a.AllowCredit);
            b.IncludeInWholeHome.ShouldEqual(a.IncludeInWholeHome);
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

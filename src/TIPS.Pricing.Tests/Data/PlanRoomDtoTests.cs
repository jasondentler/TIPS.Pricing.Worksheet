using AutoMapper;
using Xunit;
using Should;

namespace TIPS.Pricing.Data
{
    public class PlanRoomDtoTests : IUseFixture<AutomapperFixture>
    {
        private const string Room = "ROOM";
        private const string OtherRoom = "OTHER";
        private const string OptionNumber = "OPTIONNUMBER";
        private const string OtherOptionNumber = "OTHEROPTIONNUMBER";

        [Fact]
        public void WhenRoomAndOptionNumberMatch()
        {
            var a = new PlanRoomDto() {Room = Room, OptionNumber = OptionNumber, Quantity = 2M};
            var b = new PlanRoomDto() {Room = Room, OptionNumber = OptionNumber, Quantity = 3M};           
            a.ShouldEqual(b);
            a.GetHashCode().ShouldEqual(b.GetHashCode());
        }

        [Fact]
        public void WhenRoomDoesntMatch()
        {
            var a = new PlanRoomDto() { Room = Room, OptionNumber = OptionNumber, Quantity = 2M };
            var b = new PlanRoomDto() { Room = OtherRoom, OptionNumber = OptionNumber, Quantity = 3M };
            a.ShouldNotEqual(b);
        }

        [Fact]
        public void WhenOptionNumberDoesntMatch()
        {
            var a = new PlanRoomDto() { Room = Room, OptionNumber = OptionNumber, Quantity = 2M };
            var b = new PlanRoomDto() { Room = Room, OptionNumber = OtherOptionNumber, Quantity = 3M };
            a.ShouldNotEqual(b);
        }

        [Fact]
        public void MapToPlanRoom()
        {
            var a = new PlanRoomDto() { Room = Room, OptionNumber = OptionNumber, Quantity = 2M };
            var b = Mapper.Map<PlanRoom>(a);
            b.Room.ShouldEqual(a.Room);
            b.OptionNumber.ShouldEqual(a.OptionNumber);
            b.Quantity.ShouldEqual(a.Quantity);
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

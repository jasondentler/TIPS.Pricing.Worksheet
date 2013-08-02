using System;
using TIPS.Pricing.Data;

namespace TIPS.Pricing
{
    public class PlanRoom
    {

        public PlanRoom()
        {
        }

        internal PlanRoom(PlanRoomDto planRoomDto)
        {
            if (planRoomDto == null) throw new ArgumentNullException("planRoomDto");
            Room = planRoomDto.Room;
            OptionNumber = planRoomDto.OptionNumber;
            Quantity = planRoomDto.Quantity;
        }

        public string Room { get; set; }
        public string OptionNumber { get; set; }
        public string Quantity { get; set; }

    }
}

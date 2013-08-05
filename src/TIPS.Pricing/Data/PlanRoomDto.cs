using System;

namespace TIPS.Pricing.Data
{
    internal class PlanRoomDto : IEquatable<PlanRoomDto>
    {
        public virtual string Room { get; set; }
        public virtual string OptionNumber { get; set; }
        public virtual decimal Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PlanRoomDto);
        }

        public virtual bool Equals(PlanRoomDto other)
        {
            if (other == null)
                return false;
            return Equals(Room, other.Room) &&
                   Equals(OptionNumber, other.OptionNumber);
        }

        public override int GetHashCode()
        {
            return (Room ?? string.Empty).GetHashCode() ^
                   (OptionNumber ?? string.Empty).GetHashCode();
        }
    }
}

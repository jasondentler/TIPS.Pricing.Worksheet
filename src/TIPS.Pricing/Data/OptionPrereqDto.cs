using System;

namespace TIPS.Pricing.Data
{
    internal class OptionPrereqDto : IEquatable<OptionPrereqDto>
    {
        public virtual long OptionID { get; set; }
        public virtual long RequiredOptionID { get; set; }

        public virtual string OptionNumber { get; set; }
        public virtual string RequiredOptionNumber { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as OptionPrereqDto);
        }

        public virtual bool Equals(OptionPrereqDto other)
        {
            return Equals(OptionID, other.OptionID) &&
                   Equals(RequiredOptionID, other.RequiredOptionID);
        }

        public override int GetHashCode()
        {
            return OptionID.GetHashCode() ^ RequiredOptionID.GetHashCode();
        }
    }
}

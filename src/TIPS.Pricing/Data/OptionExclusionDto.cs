using System;

namespace TIPS.Pricing.Data
{
    public class OptionExclusionDto : IEquatable<OptionExclusionDto>
    {
        public virtual long OptionID1 { get; set; }
        public virtual string OptionNumber1 { get; set; }
        public virtual long OptionID2 { get; set; }
        public virtual string OptionNumber2 { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as OptionExclusionDto);
        }
        
        public virtual bool Equals(OptionExclusionDto other)
        {
            return Equals(OptionID1, other.OptionID1) &&
                   Equals(OptionID2, other.OptionID2);
        }

        public override int GetHashCode()
        {
            return OptionID1.GetHashCode() ^ OptionID2.GetHashCode();
        }
    }
}

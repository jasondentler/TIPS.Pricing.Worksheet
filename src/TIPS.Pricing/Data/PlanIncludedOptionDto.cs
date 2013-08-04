using System;

namespace TIPS.Pricing.Data
{
    internal class PlanIncludedOptionDto : IEquatable<PlanIncludedOptionDto>
    {
        public virtual string CommunityID { get; set; }
        public virtual int PlanID { get; set; }
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual long OptionID { get; set; }

        public virtual string OptionNumber { get; set; }
        public virtual DateTime? EffectiveDate { get; set; }
        public virtual string OptionCategory { get; set; }

        public virtual string Room { get; set; }
        public virtual string SubCategory { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ProductTypeGroup { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PlanIncludedOptionDto);
        }

        public virtual bool Equals(PlanIncludedOptionDto other)
        {
            if (other == null)
                return false;
            return Equals(CommunityID, other.CommunityID) &&
                   Equals(PlanID, other.PlanID) &&
                   Equals(PlanNumber, other.PlanNumber) &&
                   Equals(Elevation, other.Elevation) &&
                   Equals(OptionID, other.OptionID);
        }

        public override int GetHashCode()
        {
            return (CommunityID ?? string.Empty).GetHashCode() ^
                   PlanID.GetHashCode() ^
                   (PlanNumber ?? string.Empty).GetHashCode() ^
                   (Elevation ?? string.Empty).GetHashCode() ^
                   OptionID.GetHashCode();
        }
    }
}

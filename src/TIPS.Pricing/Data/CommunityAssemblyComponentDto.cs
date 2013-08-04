using System;

namespace TIPS.Pricing.Data
{
    internal class CommunityAssemblyComponentDto : IEquatable<CommunityAssemblyComponentDto>, IAssemblyComponentDto
    {
        public virtual string PlanNumber { get; set; }
        public virtual string Elevation { get; set; }
        public virtual long AssemblyItemID { get; set; }
        public virtual string Swing { get; set; }
        public virtual long ComponentItemID { get; set; }
        public virtual long? OppositeItemID { get; set; }
        public virtual decimal? AssemblyQuantity { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ComponentItemType { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as CommunityAssemblyComponentDto);
        }

        public virtual bool Equals(CommunityAssemblyComponentDto other)
        {
            if (other == null)
                return false;

            return Equals(PlanNumber, other.PlanNumber) &&
                   Equals(Elevation, other.Elevation) &&
                   Equals(AssemblyItemID, other.AssemblyItemID);
        }

        public override int GetHashCode()
        {
            return (PlanNumber ?? "").GetHashCode() ^
                   (Elevation ?? "").GetHashCode() ^
                   (AssemblyItemID).GetHashCode();
        }
    }
}

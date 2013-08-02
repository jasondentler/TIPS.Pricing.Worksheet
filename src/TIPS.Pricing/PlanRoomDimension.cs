using TIPS.Pricing.Data;

namespace TIPS.Pricing
{
    public class PlanRoomDimension
    {

        public PlanRoomDimension()
        {
        }

        internal PlanRoomDimension(PlanRoomDimensionDto dto)
        {
            Id = dto.Id;
            PlanNumber = dto.PlanNumber;
            Elevation = dto.Elevation;
            Room = dto.Room;
            ProductType = dto.ProductType;
            ProductTypeGroup = dto.ProductTypeGroup;
            OptionNumber = dto.OptionNumber;
            UOM = dto.UOM;
            Quantity = dto.Quantity;
            AllowCredit = dto.AllowCredit;
            IncludeInWholeHome = dto.IncludeInWholeHome;
        }

        public long Id { get; set; }
        public string PlanNumber { get; set; }
        public string Elevation { get; set; }
        public string Room { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeGroup { get; set; }
        public string OptionNumber { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public bool AllowCredit { get; set; }
        public bool IncludeInWholeHome { get; set; }

    }
}

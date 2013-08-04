namespace TIPS.Pricing.Data
{
    internal class AssemblyComponentDto : IAssemblyComponentDto 
    {
        public virtual long ID { get; set; }
        public virtual long OptionID { get; set; }
        public virtual long AssemblyItemID { get; set; }
        public virtual string Swing { get; set; }
        public virtual long ComponentItemID { get; set; }
        public virtual long? OppositeItemID { get; set; }
        public virtual decimal? AssemblyQuantity { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string ComponentItemType { get; set; }
    }
}

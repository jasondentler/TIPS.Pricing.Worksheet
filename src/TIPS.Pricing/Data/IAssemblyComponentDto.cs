namespace TIPS.Pricing.Data
{
    internal interface IAssemblyComponentDto
    {
        long AssemblyItemID { get; }
        string Swing { get; }
        long ComponentItemID { get; }
        long? OppositeItemID { get; }
        string ProductType { get; }
        decimal? AssemblyQuantity { get; }

    }
}

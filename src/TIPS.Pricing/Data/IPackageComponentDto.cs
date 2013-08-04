namespace TIPS.Pricing.Data
{
    internal interface IPackageComponentDto
    {

        string UOM { get; }
        string ProductType { get; }
        long ComponentItemID { get; set; }

    }
}

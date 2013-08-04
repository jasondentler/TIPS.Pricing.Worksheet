namespace TIPS.Pricing.Data
{
    internal interface IOptionDto
    {
        long OptionID { get; }
        string Room { get; }
        string PlanNumber { get; }
        string OptionCategory { get; }
        string Template { get; }
        string ProductType { get; }
        string Elevation { get; }
    }
}

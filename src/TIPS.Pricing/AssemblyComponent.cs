namespace TIPS.Pricing
{
    public class AssemblyComponent
    {
        /// <remarks>This may be the component item or its opposite, depending on the swing</remarks>
        public Item Item { get; set; }
        
        public decimal QuantityMultiplier { get; set; }

        /// <remarks>Always the product type of the component item, regardless of swing</remarks>
        public string ProductType { get; set; }
    }
}

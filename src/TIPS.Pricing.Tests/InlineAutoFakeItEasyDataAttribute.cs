using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

namespace TIPS.Pricing
{
    internal class InlineAutoFakeItEasyDataAttribute : CompositeDataAttribute
    {
        internal InlineAutoFakeItEasyDataAttribute(params object[] values)
            : base(new DataAttribute[] { 
                new InlineDataAttribute(values), new AutoFakeItEasyDataAttribute() })
        {
        }
    }
}
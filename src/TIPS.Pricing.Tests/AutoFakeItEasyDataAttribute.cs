using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Ploeh.AutoFixture.Xunit;

namespace TIPS.Pricing
{
    internal class AutoFakeItEasyDataAttribute : AutoDataAttribute
    {
        internal AutoFakeItEasyDataAttribute()
            : base(new Fixture().Customize(new AutoFakeItEasyCustomization()))
        {
        }
    }
}

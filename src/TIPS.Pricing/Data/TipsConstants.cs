namespace TIPS.Pricing.Data
{
    internal class TipsConstants
    {

        public class TemplatePrefixes
        {
            public const string Feature = "FTR";
            public const string Upgrade = "OPT";
        }

        public class Rooms
        {
            public const string WholeHome = "200";
        }

        public class ProductTypes
        {
            public const string Package = "PACKAGE";
        }

        public class CategoryCodes
        {
            public const string FlexSpace = "525";
            public static readonly string[] CategoryCodesWithoutProductTypes = new[] {"525", "545"};
        }
    }
}
using System.Linq;

namespace TIPS.Pricing.Data
{
    internal static class OptionDtoExtensions
    {

        public static bool IsFeature(this IOptionDto dto)
        {
            return !string.IsNullOrEmpty(dto.Template) && dto.Template.StartsWith(TipsConstants.TemplatePrefixes.Feature);
        }

        public static bool IsFeatureRelatedToFlexOption(this IOptionDto dto)
        {
            return dto.IsFeature() && dto.Template.StartsWith(TipsConstants.TemplatePrefixes.Feature + "-");
        }

        public static bool IsBaseHomeFeature(this IOptionDto dto)
        {
            return dto.IsFeature() && dto.Template == TipsConstants.TemplatePrefixes.Feature;
        }

        public static bool IsUpgrade(this IOptionDto dto)
        {
            return !string.IsNullOrEmpty(dto.Template) && dto.Template.StartsWith(TipsConstants.TemplatePrefixes.Upgrade);
        }

        public static bool IsUpgradeRelatedToFlexOption(this IOptionDto dto)
        {
            return dto.IsUpgrade() && dto.Template.StartsWith(TipsConstants.TemplatePrefixes.Upgrade + "-");
        }

        public static bool IsBaseHomeUpgrade(this IOptionDto dto)
        {
            return dto.IsUpgrade() && dto.Template == TipsConstants.TemplatePrefixes.Upgrade;
        }

        public static bool IsWholeHome(this IOptionDto dto)
        {
            return dto.Room == TipsConstants.Rooms.WholeHome;
        }

        public static bool IsPackage(this IOptionDto dto)
        {
            return dto.ProductType == TipsConstants.ProductTypes.Package;
        }

        public static bool IsPlanSpecific(this IOptionDto dto)
        {
            return !string.IsNullOrWhiteSpace(dto.PlanNumber);
        }

        public static bool IsElevationSpecific(this IOptionDto dto)
        {
            return dto.IsPlanSpecific() && !string.IsNullOrWhiteSpace(dto.Elevation);
        }

        public static bool IsPurchasing2Option(this IOptionDto dto)
        {
            return !string.IsNullOrWhiteSpace(dto.ProductType) ||
                   TipsConstants.CategoryCodes.CategoryCodesWithoutProductTypes.Contains(dto.OptionCategory);
        }

        public static bool IsPurchasing1Option(this IOptionDto dto)
        {
            return string.IsNullOrWhiteSpace(dto.ProductType);
        }

        public static bool IsFlexSpace(this IOptionDto dto)
        {
            return dto.OptionCategory == TipsConstants.CategoryCodes.FlexSpace;
        }

    }
}
using System;

namespace TIPS.Pricing.Data
{
    internal static class ItemDtoExtensions
    {

        public static bool IsAssembly(this IItemDto dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            return dto.ItemType == TipsConstants.ItemTypes.Assembly;
        }
    }
}

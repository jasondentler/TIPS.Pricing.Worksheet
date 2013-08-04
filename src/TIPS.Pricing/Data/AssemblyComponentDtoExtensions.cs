using System;

namespace TIPS.Pricing.Data
{
    internal static class AssemblyComponentDtoExtensions
    {

        public static long GetSwingAppropriateItemId(this IAssemblyComponentDto dto, string swing)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            if (dto.SwingIsWildcard() || dto.Swing == swing)
                return dto.ComponentItemID;

            if (!dto.OppositeItemID.HasValue)
                throw new ApplicationException("A component in assembly " + dto.AssemblyItemID + " requires an opposite swing item corresponding to item " + dto.ComponentItemID);

            return dto.OppositeItemID.Value;
        }

        private static bool SwingIsWildcard(this IAssemblyComponentDto dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            return string.IsNullOrWhiteSpace(dto.Swing);
        }
    }
}

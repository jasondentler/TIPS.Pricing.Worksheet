using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class HCRDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToHCR()
        {
            var dto = new HCRDto()
                {
                    HCRID = 12345,
                    OptionNumber = "OptionNumber",
                    OptionCategory = "Category"
                };

            var hcr = Mapper.Map<HCR>(dto);

            hcr.Id.ShouldEqual(dto.HCRID);
            hcr.Number.ShouldEqual(dto.OptionNumber);
            hcr.Category.ShouldEqual(dto.OptionCategory);
        }

        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

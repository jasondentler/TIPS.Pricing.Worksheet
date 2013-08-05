using AutoMapper;
using Should;
using Xunit;

namespace TIPS.Pricing.Data
{
    public class IncentiveDtoTests : IUseFixture<AutomapperFixture>
    {

        [Fact]
        public void MapToIncentive()
        {
            var dto = new IncentiveDto()
            {
                OptionSelectionID = 123456,
                OptionNumber = "OptionNumber",
                OptionCategory = "Category"
            };

            var incentive = Mapper.Map<Incentive>(dto);

            incentive.Id.ShouldEqual(dto.OptionSelectionID);
            incentive.Number.ShouldEqual(dto.OptionNumber);
            incentive.Category.ShouldEqual(dto.OptionCategory);
        }



        public void SetFixture(AutomapperFixture data)
        {
        }
    }
}

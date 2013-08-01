using System.ComponentModel.DataAnnotations;

namespace TIPS.Pricing.UI.Models
{
    public class SelectASale
    {
        [Required, Range(1, long.MaxValue, ErrorMessage = "Invalid Sale Id")]
        public long SaleId { get; set; }
    }
}
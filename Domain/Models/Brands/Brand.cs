using Microsoft.EntityFrameworkCore;

namespace Domain.Models.Brands
{
    [Index(nameof(BrandName), IsUnique = true)]
    public class Brand
    {
        public Guid BrandId { get; set; }
        public required string BrandName { get; set; }
    }
}

using Domain.Models.Brands;

namespace Application.Dtos
{
    public class GearboxDto
    {
        public required string GearboxModel { get; set; }
        public bool SixGears { get; set; }
        public Brand Brand { get; set; }

    }
}

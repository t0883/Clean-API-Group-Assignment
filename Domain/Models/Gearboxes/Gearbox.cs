using Domain.Models.Brands;

namespace Domain.Models.Gearboxes
{
    public class Gearbox
    {
        public Guid GearboxId { get; set; }
        public required string GearboxModel { get; set; }
        public Brand Brand { get; set; }
        public bool SixGears { get; set; }
    }
}

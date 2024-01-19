using Domain.Models.Brands;


namespace Domain.Models.Tires
{
    public class Tire
    {
        public Guid TireId { get; set; }
        public required string TireModel { get; set; }
        public Brand Brand { get; set; }
        public required string TireSize { get; set; }
        public decimal TireTreadDepth { get; set; }



    }
}

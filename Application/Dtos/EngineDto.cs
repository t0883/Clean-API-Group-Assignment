using Domain.Models.Brands;

namespace Application.Dtos
{
    public class EngineDto
    {
        public required string EngineName { get; set; }
        public required string EngineFuel { get; set; }
        public required int HorsePower { get; set; }
        public Brand Brand { get; set; }
    }
}


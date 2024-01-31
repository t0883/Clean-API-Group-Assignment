using Domain.Models.Brands;

namespace Application.Dtos
{
    public class SeatDto
    {
        public required string SeatName { get; set; }
        public Brand Brand { get; set; }
        public required string SeatColor { get; set; }
        public required string SeatMaterial { get; set; }
    }
}

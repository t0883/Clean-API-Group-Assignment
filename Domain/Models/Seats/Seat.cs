using Domain.Models.Brands;

namespace Domain.Models.Seats
{
    public class Seat
    {
        public Guid SeatId { get; set; }
        public required string SeatName { get; set; }
        public Brand Brand { get; set; }
        public required string SeatColor { get; set; }
        public required string SeatMaterial { get; set; }
    }
}

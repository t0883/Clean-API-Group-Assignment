using Domain.Models.Brands;

namespace Domain.Models.Seats
{
    public class Seat
    {
        public Guid SeatId { get; set; }
        public string SeatName { get; set; }
        public Brand Brand { get; set; }
        public string SeatColor { get; set; }
        public string SeatMaterial { get; set; }
    }
}

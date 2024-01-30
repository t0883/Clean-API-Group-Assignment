using Azure.Core;
using Domain.Models.Brands;
using Domain.Models.Seats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Seats.UpdateSeat
{
    public class UpdateSeatByIdCommand : IRequest<Unit>
    {
        public UpdateSeatByIdCommand(Seat seatToUpdate)
        {
            SeatName = seatToUpdate.SeatName;
            Brand = seatToUpdate.Brand;
            SeatColor = seatToUpdate.SeatColor;
            SeatMaterial = seatToUpdate.SeatMaterial;
        }

        public string SeatName { get; }
        public Brand Brand { get; }
        public string SeatColor { get; }
        public string SeatMaterial { get; }
    }
}

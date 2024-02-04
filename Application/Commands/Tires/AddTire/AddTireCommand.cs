using Application.Dtos;
using Domain.Models.Tires;
using MediatR;

namespace Application.Commands.Tires.AddTire
{
    public class AddTireCommand : IRequest<Tire>
    {
        public AddTireCommand(TireDto newTire)
        {
            NewTire = newTire;
        }

        public TireDto NewTire { get; }
    }
}

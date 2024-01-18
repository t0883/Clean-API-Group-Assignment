using MediatR;
using Application.Dtos;

namespace Application.Commands.Tires.AddTire
{
    public class AddTireCommand : IRequest<Unit>
    {
        public AddTireCommand(TireDto newTire)
        {
            NewTire = newTire;
        }

        public TireDto NewTire { get; }
    }
}

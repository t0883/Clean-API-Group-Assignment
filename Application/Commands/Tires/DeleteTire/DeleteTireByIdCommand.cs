using MediatR;
using System;

namespace Application.Commands.Tires.DeleteTire
{
    public class DeleteTireByIdCommand : IRequest<Unit>
    {
        public DeleteTireByIdCommand(Guid tireId)
        {
            TireId = tireId;
        }

        public Guid TireId { get; }
    }
}

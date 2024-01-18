using MediatR;
using System;
using Domain.Models.Tires;

namespace Application.Queries.Tires.GetById
{
    public class GetTireByIdQuery : IRequest<Tire>
    {
        public GetTireByIdQuery(Guid tireId)
        {
            TireId = tireId;
        }

        public Guid TireId { get; }
    }
}

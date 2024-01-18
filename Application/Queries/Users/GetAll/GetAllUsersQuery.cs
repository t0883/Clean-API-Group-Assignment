using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}

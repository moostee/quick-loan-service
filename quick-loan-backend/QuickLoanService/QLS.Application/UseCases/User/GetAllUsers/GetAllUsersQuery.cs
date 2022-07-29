using QLS.Application.Queries;
using QLS.Domain;
using QLS.Shared;

namespace QLS.Application.UseCases.Users.GetAllUsers;

public record GetAllUsersQuery : QueryBase<Result<List<User>>>
{

}

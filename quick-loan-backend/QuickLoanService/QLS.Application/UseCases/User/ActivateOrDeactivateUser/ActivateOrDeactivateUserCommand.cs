using QLS.Application.Commands;
using QLS.Shared;

namespace QLS.Application.UseCases.Users.ActivateorDeactivateUser;


public record ActivateorDeactivateUserCommand(int UserId, string Action) : CommandBase<Result<string>>
{

}

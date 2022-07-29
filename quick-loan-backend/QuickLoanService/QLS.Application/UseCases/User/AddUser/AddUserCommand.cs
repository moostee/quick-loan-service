using QLS.Application.Commands;
using QLS.Domain;
using QLS.Shared;

namespace QLS.Application.UseCases.Users.AddUser;


public record AddUserCommand(string Name, string Email, string Password, Role Role) : CommandBase<Result<string>>
{

}

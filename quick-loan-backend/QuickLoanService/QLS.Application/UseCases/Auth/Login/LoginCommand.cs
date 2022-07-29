using QLS.Application.Commands;
using QLS.Domain;
using QLS.Shared;

namespace QLS.Application.UseCases.Auth.Login;


public record LoginCommand(string Email, string Password) : CommandBase<Result<AuthenticateResponseModel>>
{
    
}

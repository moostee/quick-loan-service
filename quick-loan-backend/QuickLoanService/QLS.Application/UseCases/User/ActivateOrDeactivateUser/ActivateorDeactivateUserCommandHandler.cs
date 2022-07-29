using QLS.Application.Contracts;
using QLS.Application.Contracts.Handlers;
using QLS.Application.Exceptions;
using QLS.Domain;
using QLS.Shared;
using QLS.Shared.Exceptions;

namespace QLS.Application.UseCases.Users.ActivateorDeactivateUser;

internal class ActivateorDeactivateUserCommandHandler : ICommandHandler<ActivateorDeactivateUserCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ActivateorDeactivateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(ActivateorDeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var existing = await _unitOfWork.UsersRepository.GetByIdAsync(request.UserId);
        if (existing is null)
            throw new NotFoundException("user not found");

        if(request.Action.ToLower() == QLS.Domain.Entity.Action.Activate.Value.ToLower())
            await ActivateUserAsync(existing);
        else
            await DeactivateUserAsync(existing);
        
        await _unitOfWork.CompleteAsync();

        return ActivateorDeactivateUserCommandResult.Success("success");
    }

    private async Task ActivateUserAsync(User existingUser)
    {
        if(!existingUser.IsDeleted) 
            throw new QLSException("user is already active");
        
        existingUser.ActivateUser();
        _unitOfWork.UsersRepository.Update(existingUser);
        
    }

    private async Task DeactivateUserAsync(User existingUser)
    {
        if(existingUser.IsDeleted) 
            throw new QLSException("user is already deactivated");
        
        existingUser.DeactivateUser();
        _unitOfWork.UsersRepository.Update(existingUser);

        
    }
}
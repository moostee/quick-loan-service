using QLS.Application.Contracts;
using QLS.Application.Contracts.Handlers;
using QLS.Application.Exceptions;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.GetLoanByUserId;

internal class GetLoanByUserIdQueryHandler : IQueryHandler<GetLoanByUserIdQuery, Result<List<Loans>>>
{
    private readonly IUnitOfWork _untiOfWork;
    public GetLoanByUserIdQueryHandler(IUnitOfWork untiOfWork)
    {
        _untiOfWork = untiOfWork;
    }
    public async Task<Result<List<Loans>>> Handle(GetLoanByUserIdQuery request, CancellationToken cancellationToken)
    {
        var exists = await _untiOfWork.UsersRepository.FindOneAsync(x => x.Id == request.UserId && !x.IsDeleted);
        if(exists is null) throw new NotFoundException("user not found");
        
        var loans = await _untiOfWork.LoanRepository.FindAsync(x => x.UserId == request.UserId);
        return GetLoanByUserIdResult.Success(loans.ToList());
    }

}
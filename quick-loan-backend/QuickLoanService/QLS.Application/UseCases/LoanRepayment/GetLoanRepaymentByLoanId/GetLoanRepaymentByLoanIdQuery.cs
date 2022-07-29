
using QLS.Application.Contracts;
using QLS.Application.Contracts.Handlers;
using QLS.Application.Exceptions;
using QLS.Application.Queries;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.LoanRepayment.GetLoanRepaymentById;


public record GetLoanRepaymentByLoanIdQuery(int LoanId) : QueryBase<Result<List<LoanRepayments>>>
{

}

public class GetLoanRepaymentByLoanIdQueryResult : Result<List<LoanRepayments>>
{ 

}


internal class GetLoanRepaymentByLoanIdQueryHandler : IQueryHandler<GetLoanRepaymentByLoanIdQuery, Result<List<LoanRepayments>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetLoanRepaymentByLoanIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<List<LoanRepayments>>> Handle(GetLoanRepaymentByLoanIdQuery request, CancellationToken cancellationToken)
    {
        var existing = await _unitOfWork.LoanRepository.GetByIdAsync(request.LoanId);
        if(existing is null)
            throw new NotFoundException("loan not found");  

        var loanRepayments = await _unitOfWork.LoanRepaymentRepository.FindAsync(x => x.LoanId == request.LoanId); 
        return GetLoanRepaymentByLoanIdQueryResult.Success(loanRepayments.ToList());
    }

}


using QLS.Application.Contracts;
using QLS.Application.Contracts.Handlers;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.GetAllLoans;

internal class GetAllLoansQueryHandler : IQueryHandler<GetAllLoansQuery, Result<List<Loans>>>
{
    private readonly IUnitOfWork _untiOfWork;
    public GetAllLoansQueryHandler(IUnitOfWork untiOfWork)
    {
        _untiOfWork = untiOfWork;
    }
    public async Task<Result<List<Loans>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
        var loans = await _untiOfWork.LoanRepository.GetAllAsync();
        return GetAllLoansResult.Success(loans.ToList());
    }
}




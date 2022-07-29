using QLS.Application.Queries;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.GetAllLoans;

public record GetAllLoansQuery : QueryBase<Result<List<Loans>>>
{

}

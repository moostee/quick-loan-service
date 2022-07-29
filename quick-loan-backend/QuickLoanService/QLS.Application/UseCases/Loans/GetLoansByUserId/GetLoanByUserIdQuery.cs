using QLS.Application.Queries;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.GetLoanByUserId;


public record GetLoanByUserIdQuery(int UserId) : QueryBase<Result<List<Loans>>>
{

}

using QLS.Application.Commands;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.RepayLoan;


public record RepayLoanCommand(int UserId) : CommandBase<Result<string>>
{

}

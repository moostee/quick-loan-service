using QLS.Application.Commands;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.AddLoan;


public record AddLoanCommand(decimal LoanAmount, int UserId, string StartDate, string EndDate) : CommandBase<Result<string>>
{
    
}

using QLS.Application.Contracts;
using QLS.Application.Contracts.Handlers;
using QLS.Application.Exceptions;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.Loan.RepayLoan;

internal class AddLoanCommandHandler : ICommandHandler<RepayLoanCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddLoanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(RepayLoanCommand request, CancellationToken cancellationToken)
    {
        var exists = await _unitOfWork.UsersRepository.FindOneAsync(x => x.Id == request.UserId && !x.IsDeleted);
        if (exists is null) throw new NotFoundException("user not found");

        var loan = await _unitOfWork.LoanRepository.FindOneAsync(x => x.UserId == request.UserId && x.Status == RepaymentStatus.Ongoing.ToString());

        if(loan is null) return RepayLoanCommandResult.Failure("no active loan to repay");
        
        loan.CompleteLoan();
        _unitOfWork.LoanRepository.Update(loan);

        var loanRepayment = await _unitOfWork.LoanRepaymentRepository.FindOneAsync(x => x.LoanId == loan.Id && x.Status == RepaymentStatus.Ongoing.ToString());
        loanRepayment.CompleteLoan();
        _unitOfWork.LoanRepaymentRepository.Update(loanRepayment);

        var wallet = await _unitOfWork.WalletRepository.FindOneAsync(x => x.UserId == request.UserId);
        wallet.MakeLoanRepayment();
        _unitOfWork.WalletRepository.Update(wallet);


        await _unitOfWork.CompleteAsync();

        return RepayLoanCommandResult.Success("successful");
    }
}

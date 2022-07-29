using QLS.Domain;
using QLS.Domain.Entity;

namespace QLS.Application.Contracts;


public interface IUnitOfWork
{
    ILoanRepository LoanRepository { get; }

    ILoanRepaymentRepository LoanRepaymentRepository { get; }
    IUserRepository UsersRepository { get; }
    IWalletRepository WalletRepository { get; }
    int Complete();

    Task<int> CompleteAsync();
}
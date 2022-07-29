using QLS.Application.Contracts;
using QLS.Domain;
using QLS.Domain.Entity;

namespace QLS.Infrastructure.Data.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly QLSContext _context;
    public UnitOfWork(QLSContext context, ILoanRepository loanRepository, ILoanRepaymentRepository loanRepaymentRepository, IUserRepository usersRepository, IWalletRepository walletRepository)
    {
        _context = context;
        LoanRepository = loanRepository;
        LoanRepaymentRepository = loanRepaymentRepository;
        UsersRepository = usersRepository;
        WalletRepository = walletRepository;
    }

    public ILoanRepository LoanRepository { get; private set; }

    public ILoanRepaymentRepository LoanRepaymentRepository { get; private set; }

    public IUserRepository UsersRepository { get; private set; }

    public IWalletRepository WalletRepository { get; private set; }

    public int Complete() => _context.SaveChanges();

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
}

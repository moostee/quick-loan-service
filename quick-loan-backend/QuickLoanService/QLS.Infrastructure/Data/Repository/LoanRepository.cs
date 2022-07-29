namespace QLS.Infrastructure.Data.Repository;
using QLS.Domain.Entity;

internal class LoanRepository : Repository<Loans, int>, ILoanRepository
{
    public LoanRepository(QLSContext context) : base(context)
    {
    }
}
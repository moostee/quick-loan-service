namespace QLS.Infrastructure.Data.Repository;
using QLS.Domain.Entity;

internal class LoanRepaymentRepository : Repository<LoanRepayments, int>, ILoanRepaymentRepository
{
    public LoanRepaymentRepository(QLSContext context) : base(context)
    {
    }
}

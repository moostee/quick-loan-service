namespace QLS.Infrastructure.Data.Repository;
using QLS.Domain.Entity;

internal class WalletRepository : Repository<Wallets, int>, IWalletRepository
{
    public WalletRepository(QLSContext context) : base(context)
    {
    }
}

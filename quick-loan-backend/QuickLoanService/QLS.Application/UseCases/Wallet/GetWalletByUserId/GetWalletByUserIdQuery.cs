using QLS.Application.Queries;
using QLS.Domain.Entity;
using QLS.Shared;

namespace QLS.Application.UseCases.Wallet.GetWalletByUserId;


public record GetWalletByUserIdQuery(int UserId) : QueryBase<Result<Wallets>>
{

}

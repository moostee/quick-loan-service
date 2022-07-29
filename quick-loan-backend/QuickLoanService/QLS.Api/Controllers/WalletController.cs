using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLS.Application.UseCases.Wallet.GetWalletByUserId;

namespace QLS.Api.Controllers;

[Authorize(Roles = "USER")]
public class WalletController : BaseController
{
    public WalletController(IMediator mediator) : base(mediator)
    {

    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetWalletByUserIdAsync([Required] int userId)
    {
        return Ok(await _mediator.Send(new GetWalletByUserIdQuery(userId)));
    }

}

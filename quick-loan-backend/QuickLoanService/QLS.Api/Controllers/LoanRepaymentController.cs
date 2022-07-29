using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLS.Application.UseCases.LoanRepayment.GetLoanRepaymentById;

namespace QLS.Api.Controllers;

[Authorize]
public class LoanRepaymentController : BaseController
{
    public LoanRepaymentController(IMediator mediator) : base(mediator)
    {

    }

    [HttpGet("{loanId}")]
    public async Task<IActionResult> GetWalletByUserIdAsync([Required] int loanId)
    {
        return Ok(await _mediator.Send(new GetLoanRepaymentByLoanIdQuery(loanId)));
    }

}
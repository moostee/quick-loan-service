using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLS.Application.UseCases.Loan.AddLoan;
using QLS.Application.UseCases.Loan.GetAllLoans;
using QLS.Application.UseCases.Loan.GetLoanByUserId;
using QLS.Application.UseCases.Loan.RepayLoan;
using QLS.Domain.Entity;

namespace QLS.Api.Controllers;

[Authorize]
public class LoanController : BaseController
{
    public LoanController(IMediator mediator) : base(mediator)
    {

    }


    [Authorize(Roles = "USER")]
    [HttpPost]
    public async Task<IActionResult> AddLoanAsync(LoanForm form)
    {
        form.Validate();
        return Ok(await _mediator.Send(new AddLoanCommand(form.LoanAmount, form.UserId, form.StartDate, form.EndDate)));
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetAllLoanAsync()
    {
        return Ok(await _mediator.Send(new GetAllLoansQuery()));
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetLoanByUserIdAsync([Required] int userId)
    {
        return Ok(await _mediator.Send(new GetLoanByUserIdQuery(userId)));
    }

    [HttpPut("repay")]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> RepayLoanAsync([FromBody] RepayLoanForm form)
    {
        form.Validate();
        return Ok(await _mediator.Send(new RepayLoanCommand(form.UserId)));
    }
}

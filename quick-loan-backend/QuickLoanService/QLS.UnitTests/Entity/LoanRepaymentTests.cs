namespace QLS.UnitTests;

using NUnit.Framework;
using QLS.Domain;
using QLS.Domain.Entity;

public class LoanRepaymentTests
{
    [SetUp]
    public void Setup()
    {

    }


    [Test]
    public void CompleteLoan_WhenCalled_ConfirmLoanIsCompleted()
    {
        var user = User.Create("test", "test@gmail.com", "password", Role.USER, 0, true);
        var loan = Loans.Create(user, 1000, DateTime.UtcNow, DateTime.UtcNow, 1, 1, RepaymentStatus.Ongoing.ToString());
        var loanRepayment = LoanRepayments.Create(loan, RepaymentStatus.Ongoing.ToString(), DateTime.UtcNow.AddMonths(1), DateTime.UtcNow);

        loan.CompleteLoan();

        Assert.That(loan.Status, Is.EqualTo(RepaymentStatus.Completed.ToString()));
    }
}

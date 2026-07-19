using LoanTracker;
using Xunit;

public sealed class LoanTests
{
    private static readonly Lender TestLender = new("Test Bank", "123", "loans@example.com");

    [Fact]
    public void InstallmentLoan_CalculatesAmortizedPayment()
    {
        var loan = new InstallmentLoan(TestLender, "Car", 10_000m, 5m, 3);

        Assert.Equal(299.71m, loan.MonthlyPayment);
        Assert.Equal(loan.MonthlyPayment, loan.FinalPayment);
    }

    [Fact]
    public void InstallmentLoan_HandlesZeroInterest()
    {
        var loan = new InstallmentLoan(TestLender, "Equipment", 1_200m, 0m, 1);

        Assert.Equal(100m, loan.MonthlyPayment);
    }

    [Fact]
    public void BalloonLoan_ReportsInterestAndFinalPrincipalPayment()
    {
        var loan = new BalloonLoan(TestLender, "Property", 12_000m, 6m, 5);

        Assert.Equal(60m, loan.MonthlyPayment);
        Assert.Equal(12_060m, loan.FinalPayment);
    }

    [Fact]
    public void Loan_RejectsNonPositivePrincipal()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new InstallmentLoan(TestLender, "Car", 0m, 5m, 3));
    }
}

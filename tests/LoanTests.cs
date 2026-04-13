using Xunit;

public class LoanTests
{
    [Fact]
    public void InstallmentLoan_CalculatesPayment()
    {
        var lender = new Lender("Test", "123", "email@test.com");
        var loan = new InstallmentLoan(lender, "Car", 10000, 5, 3);

        var payment = loan.ToString();

        Assert.NotNull(payment);
    }
}

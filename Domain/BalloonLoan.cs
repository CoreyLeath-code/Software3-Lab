namespace LoanTracker;

public sealed class BalloonLoan : Loan
{
    public BalloonLoan(
        Lender lender,
        string purpose,
        decimal principal,
        decimal annualInterestRatePercent,
        int termYears)
        : base(lender, purpose, principal, annualInterestRatePercent, termYears)
    {
    }

    public override string LoanType => "Balloon";

    public override decimal MonthlyPayment =>
        decimal.Round(
            Principal * (AnnualInterestRatePercent / 100m / 12m),
            2,
            MidpointRounding.AwayFromZero);

    public override decimal FinalPayment => Principal + MonthlyPayment;
}

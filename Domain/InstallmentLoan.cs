namespace LoanTracker;

public sealed class InstallmentLoan : Loan
{
    public InstallmentLoan(
        Lender lender,
        string purpose,
        decimal principal,
        decimal annualInterestRatePercent,
        int termYears)
        : base(lender, purpose, principal, annualInterestRatePercent, termYears)
    {
    }

    public override string LoanType => "Installment";

    public override decimal MonthlyPayment
    {
        get
        {
            var months = TermYears * 12;
            var monthlyRate = AnnualInterestRatePercent / 100m / 12m;
            if (monthlyRate == 0)
            {
                return decimal.Round(Principal / months, 2, MidpointRounding.AwayFromZero);
            }

            var factor = (decimal)Math.Pow((double)(1m + monthlyRate), months);
            var payment = Principal * monthlyRate * factor / (factor - 1m);
            return decimal.Round(payment, 2, MidpointRounding.AwayFromZero);
        }
    }

    public override decimal FinalPayment => MonthlyPayment;
}

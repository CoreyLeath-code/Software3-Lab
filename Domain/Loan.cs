using System.Globalization;

namespace LoanTracker;

public abstract class Loan
{
    protected Loan(
        Lender lender,
        string purpose,
        decimal principal,
        decimal annualInterestRatePercent,
        int termYears)
    {
        Lender = lender ?? throw new ArgumentNullException(nameof(lender));
        Purpose = string.IsNullOrWhiteSpace(purpose)
            ? throw new ArgumentException("Loan purpose is required.", nameof(purpose))
            : purpose.Trim();
        Principal = principal > 0
            ? principal
            : throw new ArgumentOutOfRangeException(nameof(principal), "Principal must be positive.");
        AnnualInterestRatePercent = annualInterestRatePercent >= 0
            ? annualInterestRatePercent
            : throw new ArgumentOutOfRangeException(
                nameof(annualInterestRatePercent),
                "Interest rate cannot be negative.");
        TermYears = termYears > 0
            ? termYears
            : throw new ArgumentOutOfRangeException(nameof(termYears), "Term must be positive.");
    }

    public Lender Lender { get; }
    public string Purpose { get; }
    public decimal Principal { get; }
    public decimal AnnualInterestRatePercent { get; }
    public int TermYears { get; }
    public abstract decimal MonthlyPayment { get; }
    public abstract decimal FinalPayment { get; }
    public abstract string LoanType { get; }

    public override string ToString() =>
        $"{LoanType}: {Purpose}; lender={Lender.Name}; principal=" +
        $"{Principal.ToString("C", CultureInfo.InvariantCulture)}; " +
        $"monthly={MonthlyPayment.ToString("C", CultureInfo.InvariantCulture)}; " +
        $"final={FinalPayment.ToString("C", CultureInfo.InvariantCulture)}";
}

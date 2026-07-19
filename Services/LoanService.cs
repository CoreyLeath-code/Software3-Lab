namespace LoanTracker;

public sealed class LoanService
{
    public void AddLoan(ICollection<Loan> loans, Loan loan)
    {
        ArgumentNullException.ThrowIfNull(loans);
        ArgumentNullException.ThrowIfNull(loan);
        loans.Add(loan);
    }

    public IReadOnlyList<Loan> GetLoans(IEnumerable<Loan> loans)
    {
        ArgumentNullException.ThrowIfNull(loans);
        return loans.ToArray();
    }
}

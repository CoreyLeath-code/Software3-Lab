// Services/LoanService.cs
public class LoanService
{
    public void AddLoan(List<Loan> loans, Loan loan)
    {
        loans.Add(loan);
    }

    public List<Loan> GetLoans(List<Loan> loans)
    {
        return loans;
    }
}

namespace LoanTracker;

public sealed record Lender
{
    public Lender(string name, string phone, string email)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Lender name is required.", nameof(name))
            : name.Trim();
        Phone = phone?.Trim() ?? string.Empty;
        Email = email?.Trim() ?? string.Empty;
    }

    public string Name { get; }
    public string Phone { get; }
    public string Email { get; }
}

using System.Text.Json;

namespace LoanTracker;

public static class FileOperations
{
    private const string DefaultPath = "loans.json";

    public static void LoanSave(IEnumerable<Loan> loans, string path = DefaultPath)
    {
        ArgumentNullException.ThrowIfNull(loans);
        ValidatePath(path);

        var records = loans.Select(LoanRecord.FromLoan).ToArray();
        var json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public static void LoanLoad(ICollection<Loan> destination, string path = DefaultPath)
    {
        ArgumentNullException.ThrowIfNull(destination);
        ValidatePath(path);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Loan file was not found.", path);
        }

        var records = JsonSerializer.Deserialize<LoanRecord[]>(File.ReadAllText(path))
            ?? throw new InvalidDataException("Loan file did not contain a valid collection.");

        var loaded = records.Select(record => record.ToLoan()).ToArray();
        destination.Clear();
        foreach (var loan in loaded)
        {
            destination.Add(loan);
        }
    }

    private static void ValidatePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("A file path is required.", nameof(path));
        }
    }

    private sealed record LoanRecord(
        string Type,
        string LenderName,
        string LenderPhone,
        string LenderEmail,
        string Purpose,
        decimal Principal,
        decimal AnnualInterestRatePercent,
        int TermYears)
    {
        public static LoanRecord FromLoan(Loan loan) =>
            new(
                loan.LoanType,
                loan.Lender.Name,
                loan.Lender.Phone,
                loan.Lender.Email,
                loan.Purpose,
                loan.Principal,
                loan.AnnualInterestRatePercent,
                loan.TermYears);

        public Loan ToLoan()
        {
            var lender = new Lender(LenderName, LenderPhone, LenderEmail);
            return Type switch
            {
                "Installment" => new InstallmentLoan(
                    lender, Purpose, Principal, AnnualInterestRatePercent, TermYears),
                "Balloon" => new BalloonLoan(
                    lender, Purpose, Principal, AnnualInterestRatePercent, TermYears),
                _ => throw new InvalidDataException($"Unsupported loan type '{Type}'."),
            };
        }
    }
}

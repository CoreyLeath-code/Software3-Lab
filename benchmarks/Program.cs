using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using LoanTracker;

BenchmarkRunner.Run<LoanBenchmarks>();

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80, launchCount: 1, warmupCount: 3, iterationCount: 5)]
public class LoanBenchmarks
{
    private readonly InstallmentLoan _installment =
        new(new Lender("Benchmark Bank", "555-0100", "bench@example.com"), "Vehicle", 25_000m, 6.5m, 5);

    private readonly BalloonLoan _balloon =
        new(new Lender("Benchmark Bank", "555-0100", "bench@example.com"), "Property", 250_000m, 7m, 10);

    [Benchmark(Baseline = true)]
    public decimal InstallmentMonthlyPayment() => _installment.MonthlyPayment;

    [Benchmark]
    public decimal BalloonMonthlyPayment() => _balloon.MonthlyPayment;

    [Benchmark]
    public string FormatInstallmentLoan() => _installment.ToString();
}

using System;
using System.Collections.Generic;

namespace LoanTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Loan> loans = new List<Loan>();
            int selection = 0;

            while (selection != 5)
            {
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Add Loan");
                Console.WriteLine("2. Amortization Report");
                Console.WriteLine("3. Save to File");
                Console.WriteLine("4. Load from File");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid menu selection.");
                    Console.WriteLine("[LOG] " + ex.Message);
                    selection = 0;
                }

                switch (selection)
                {
                    case 1:
                        AddLoan(loans);
                        break;

                    case 2:
                        DisplayReport(loans);
                        break;

                    case 3:
                        try
                        {
                            FileOperations.LoanSave(loans);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error saving file.");
                            Console.WriteLine("[LOG] " + ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            FileOperations.LoanLoad(loans);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error loading file.");
                            Console.WriteLine("[LOG] " + ex.Message);
                        }
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddLoan(List<Loan> loans)
        {
            int loanType = 0;

            Console.WriteLine("Loan Type ---");
            Console.WriteLine("1. Installment Loan");
            Console.WriteLine("2. Balloon Loan");
            Console.Write("Select a loan type: ");

            try
            {
                loanType = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid loan type.");
                Console.WriteLine("[LOG] " + ex.Message);
                return;
            }

            Console.WriteLine("Lender Information ---");

            Console.Write("Please enter the name of the lender (Example \"ABC Bank\"): ");
            string lenderName = Console.ReadLine() ?? "";

            Console.Write("Please enter the phone number: ");
            string lenderPhone = Console.ReadLine() ?? "";

            Console.Write("Please enter the email: ");
            string lenderEmail = Console.ReadLine() ?? "";

            Lender lender = new Lender(lenderName, lenderPhone, lenderEmail);

            Console.Write("Please enter the purpose of the loan: ");
            string purpose = Console.ReadLine() ?? "";

            decimal amount;
            Console.Write("Please enter the loan amount: ");
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid loan amount.");
                Console.WriteLine("[LOG] " + ex.Message);
                return;
            }

            decimal interestRate;
            Console.Write("Please enter the interest rate: ");
            try
            {
                interestRate = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid interest rate.");
                Console.WriteLine("[LOG] " + ex.Message);
                return;
            }

            int term;
            Console.Write("Please enter the term (years): ");
            try
            {
                term = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid term.");
                Console.WriteLine("[LOG] " + ex.Message);
                return;
            }

            Loan loan;

            if (loanType == 1)
            {
                loan = new InstallmentLoan(lender, purpose, amount, interestRate, term);
            }
            else if (loanType == 2)
            {
                loan = new BalloonLoan(lender, purpose, amount, interestRate, term);
            }
            else
            {
                Console.WriteLine("Invalid loan type.");
                return;
            }

            loans.Add(loan);
        }

        static void DisplayReport(List<Loan> loans)
        {
            if (loans.Count == 0)
            {
                Console.WriteLine("No loans to display.");
                return;
            }

            foreach (Loan loan in loans)
            {
                Console.WriteLine(loan.ToString());
            }
        }
    }
}

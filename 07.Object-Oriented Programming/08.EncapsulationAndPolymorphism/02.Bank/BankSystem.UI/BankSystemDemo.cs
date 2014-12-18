namespace BankSystem.UI
{
    using System;
    using BankSystem.Common;
    using System.Collections.Generic;
    class BankSystemDemo
    {
        static void Main()
        {
            // Creating some customers
            IndividualCustomer customer1 = new IndividualCustomer("Ivan", "Ivanov", 11223344);
            CompanyCustomer customer2 = new CompanyCustomer("Company 0101", 99887766);
            CompanyCustomer customer3 = new CompanyCustomer("Company 123", 22334455);

            // Creating different kinds of accounts
            DepositAccount account1 = new DepositAccount(customer1, 20000m, 10m);
            LoanAccount account2 = new LoanAccount(customer2, 5000m, 6.8m);
            DepositAccount account3 = new DepositAccount(customer3, 3400m, 16.4m);

            // Creating the bank with the accounts
            List<Account> accounts = new List<Account>() { account1, account2, account3 };
            Bank bank = new Bank("G Bank", accounts);

            // Adding account to the bank
            IndividualCustomer customer4 = new IndividualCustomer("Georgi", "Georgiev", 66778800);
            MortgageAccount account4 = new MortgageAccount(customer4, 2000m, 4.1m);
            bank.AddAccount(account4);

            // Printing all the information about the bank and its clients on the console
            Console.WriteLine(bank);

            // Depositting and withdrawing money to account1
            account1.DepositMoney(100m);
            account1.WithdrawMoney(2000m);
            Console.WriteLine("After depositting and withdrawing money from {0} {1}'s account the balance is: {2:C2}",
                customer1.Fname, customer1.Lname, account1.Balance);
            Console.WriteLine();

            // Calculating the interest amount for all the accounts in the bank
            Console.WriteLine("Deposit account interest amount after 5 months: {0:C2}", account1.CalculateInterestAmount(5));
            account3.WithdrawMoney(2600m);
            Console.WriteLine("Deposit account interest amount after 2 months: {0:C2}", account3.CalculateInterestAmount(2));
            Console.WriteLine("Loan account interest amount after 10 months: {0:C2}", account2.CalculateInterestAmount(10));
            Console.WriteLine("Mortgage account interest amount after 1 year: {0:C2}", account4.CalculateInterestAmount(12));
        }
    }
}

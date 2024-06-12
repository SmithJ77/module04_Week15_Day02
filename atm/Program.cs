using System;

namespace atm
{
    class Program
    {
        public static decimal Balance = 100;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the atm!\n\n");
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("To view balance, press 1");
                Console.WriteLine("To withdraw, press 2");
                Console.WriteLine("To deposit new funds, press 3");
                Console.WriteLine("To exit, press 4");

                Console.WriteLine("\n");

                string input = Console.ReadLine();
                Console.Clear();

                if (input == "1")
                {
                    decimal balance = ViewBalance();
                    Console.WriteLine("This is the current balance: " + balance);
                }
                else if (input == "2")
                {
                    Console.Write("What is the withdrawal amount? ");
                    string withdrawAmountString = Console.ReadLine();
                    decimal withdrawAmount = Convert.ToDecimal(withdrawAmountString);
                    decimal newAccountBalance = Withdraw(withdrawAmount);
                    Balance = newAccountBalance;
                    Console.WriteLine("The new balance is " + newAccountBalance + "\n");
                }
                else if (input == "3")
                {
                    Console.Write("What is the deposit amount? ");
                    string depositAmountString = Console.ReadLine();
                    decimal depositAmount = Convert.ToDecimal(depositAmountString);
                    decimal newAccountBalance = Deposit(depositAmount);
                    Balance = newAccountBalance;
                    Console.WriteLine("The new balance is " + newAccountBalance + "\n");
                }
                else if (input == "4")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("\n");

                Console.Write("Press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static decimal ViewBalance()
        {
            return Balance;
        }

        static decimal Withdraw(decimal withdrawAmount)
        {
            if (Balance < withdrawAmount)
            {
                throw new Exception("Insufficient funds!: You ain't got no moneyyy!");
            }
            else if (withdrawAmount < 0)
            {
                throw new Exception("Invalid withdrawal amount");
            }

            decimal newBalance = Balance - withdrawAmount;
            return newBalance;
        }

        static decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount.");
            }

            Balance += amount;
            return Balance;
        }
    }
}

using System;
using BankAppNew.Model;
using BankAppNew.Repositories;

namespace BankAppNew
{
    class Program
    {
        static BankRepo bankRepository = new BankRepo();
        static CustomerRepo customerRepository = new CustomerRepo();
        static AccountRepo accountRepository = new AccountRepo();

        static void Main(string[] args)
        {
            Console.WriteLine("Bank SQL database app 1.0");           
            string message = "";
            string userInput = null;

            do
            {
                userInput = ChooseAction();
                switch (userInput.ToUpper())
                {
                    case "1":
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("1 = Create a bank");
                        Console.WriteLine("2 = Print bank information");
                        Console.WriteLine("3 = Update bank.");
                        Console.WriteLine("4 = Delete bank.");
                        string BankChoice = Console.ReadLine();

                        if (BankChoice.ToUpper() == "1")
                        {
                            bankRepository.CreateBank();
                            Console.WriteLine("Bank created.");
                        }
                        else if (BankChoice.ToUpper() == "2")
                        {
                            PrintBank();
                        }
                       
                        else if (BankChoice.ToUpper() == "3")
                        {
                            bankRepository.UpdateBank();
                            Console.WriteLine("Bank updated.");
                        }
                        else if (BankChoice.ToUpper() == "4")
                        {
                            bankRepository.DeleteBank(1); 
                            Console.WriteLine("Bank has been deleted.");
                        }
                        else
                            Console.WriteLine("Given option does not exist.");

                        break;

                    case "2":
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("1 = Create a new customer");
                        Console.WriteLine("2 = Print  customer's  info");
                        Console.WriteLine("3 = Print all customers");
                        Console.WriteLine("4 = Update customer's info");
                        Console.WriteLine("5 = Delete customer");
                        string CustomerOption = Console.ReadLine();

                        if (CustomerOption.ToUpper() == "1")
                        {
                            customerRepository.CreateCustomer();
                            Console.WriteLine("Customer created.");
                        }
                        else if (CustomerOption.ToUpper() == "2")
                        {
                            PrintCustomer();
                        }
                        else if (CustomerOption.ToUpper() == "3")
                        {
                            PrintAllCustomers();
                        }
                        else if (CustomerOption.ToUpper() == "4")
                        {
                            customerRepository.UpdateCustomer();
                            Console.WriteLine("Customer updated.");
                        }
                        else if (CustomerOption.ToUpper() == "5")
                        {
                            customerRepository.DeleteCustomer(1);
                        }                       
                        break;

                    case "3":
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("1 = Create a new account");
                        Console.WriteLine("2 = Print account's info");
                        Console.WriteLine("3 = Print all accounts in a bank");
                        Console.WriteLine("4 = Print all accounts of a customer");
                        Console.WriteLine("5 = Delete account by IBAN");
                        string AccountOption = Console.ReadLine();

                        if (AccountOption.ToUpper() == "1")
                        {
                            accountRepository.CreateNewAccount();
                            Console.WriteLine("New accoumt created.");
                        }
                        else if (AccountOption.ToUpper() == "2")
                        {
                            PrintAccount("FI4250001510000023");  
                        }
                        else if (AccountOption.ToUpper() == "3")
                        {
                            PrintAccounts();
                        }
                        else if (AccountOption.ToUpper() == "4")
                        {
                            PrintAll(1); 
                        }
                        else if (AccountOption.ToUpper() == "5")
                        {
                            accountRepository.DeleteAccount("FI4250001510000023");
                            Console.WriteLine("Account has been deleted.");
                        }                     
                        break;

                    case "4":
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("1 = Create a transaction");
                        Console.WriteLine("2 = Print customer's transactions");
                        string TransactionOption = Console.ReadLine();

                        if (TransactionOption.ToUpper() == "1")
                        {
                            var amount = accountRepository.AddTransaction();
                            Transaction trns = new Transaction { Iban = "FI4250001510000023", Amount = amount };
                            accountRepository.CreateTransaction(trns);
                            accountRepository.UpdateAccountBalance(amount);
                            Console.WriteLine($"Transaction of {amount} has been recorded.");
                        }
                        else if (TransactionOption.ToUpper() == "2")
                        {
                            PrintTransaction("FI4250001510000023");
                        }
                        break;
                        
                    default:
                        message = "Invalid option.";
                        break;
                }
                Console.WriteLine(message);
                Console.ReadKey();
                Console.Clear();
            }
            while (true); 
        }

        public static string ChooseAction()
        {
            Console.WriteLine("Choose an action and press enter:");
            Console.WriteLine("[ 1 ] = Banks");
            Console.WriteLine("[ 2 ] = Customers");
            Console.WriteLine("[ 3 ] = Accounts");
            Console.WriteLine("[ 4 ] = Transactions");
            string choice = Console.ReadLine();
            return choice;
        }

        static private void PrintBank()
        {
            var bank = bankRepository.Read(1); 
            Console.WriteLine($"{bank.Id}, {bank.Name}, {bank.Bic}");
        }

    
        static private void PrintAllCustomers()
        {
            var customers = customerRepository.Read();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Firstname} {customer.Lastname}, in bank with id {customer.BankId}");
            }
        }

        static private void PrintCustomer()
        {
            var customer = customerRepository.Read(1);
            Console.WriteLine($"{customer.Firstname} {customer.Lastname}, in bank with id {customer.BankId}");
        }

        static private void PrintAll(long id) 
        {
            var customer = customerRepository.Read(id);
            var accounts = accountRepository.Read(id);

            Console.WriteLine($"{customer.Firstname} {customer.Lastname} is customer in bank number {customer.BankId}");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Name}: {account.Balance}");
            }
        }

       
        static private void PrintAccounts() 
        {
            Console.WriteLine("Input id of the bank account you wish to read.");
            string bankId = Console.ReadLine();
            long id = Convert.ToInt64(bankId);

            var accounts = accountRepository.Read();
            foreach (var account in accounts)
            {
                if (account.BankId == id)
                    Console.WriteLine($"Account name: {account.Name} with Iban {account.Iban}");
            }
        }

        static private void PrintAccount(string iban)
        {
            var account = accountRepository.Read(iban);
            Console.WriteLine($"Iban: {account.Iban}, {account.Name} of customer with id {account.CustomerId}, in bank with id {account.BankId}.\n");
            Console.WriteLine($"Account balance: {account.Balance}");
        }

        static private void PrintTransaction(string iban)
        {
            var transactions = accountRepository.ReadTransaction(iban); 
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"IBAN: {transaction.Iban}: {transaction.TimeStamp} {transaction.Amount}");
            }
        }
    }
}









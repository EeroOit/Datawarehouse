using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using BankAppNew.Model;
using BankAppNew.Repositories;

namespace BankAppNew.Repositories
{
    class AccountRepo : IAccount
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Account account)
        {
            _bankdbContext.Add(account);
            _bankdbContext.SaveChanges();
        }

        public void CreateNewAccount()
        {
            Account newAccount = new Account();
            newAccount.Iban = "FI4250001510000023";
            newAccount.Name = "2nd account";
            newAccount.BankId = 1;
            newAccount.CustomerId = 1;
            newAccount.Balance = 10000;
            Create(newAccount);
        }

        public void Delete(string iban)
        {
            var accouuntDelete = Read(iban);
            if (accouuntDelete != null)
            {
                _bankdbContext.Account.Remove(accouuntDelete);
                _bankdbContext.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteAccount(string iban)
        {
            var account = Read(iban);

            if (account == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                Delete(iban);
            }
        }

        public List<Account> Read()
        {
            var accounts = _bankdbContext.Account.ToList();
            return accounts;
        }

        public List<Account> Read(long id)
        {
            var accounts = _bankdbContext.Account.Where(a => a.CustomerId == id).ToList();
            return accounts;
        }

        public Account Read(string iban)
        {
            var readAccount = _bankdbContext.Account
                .AsNoTracking().Where(a => a.Iban == iban)
                .FirstOrDefault();
            if (readAccount == null)
            {
                return null;
            }
            else
            {
                return readAccount;
            }
        }

        public void Update(string iban, Account account)
        {
            var checkAccount = Read(iban);
            if (checkAccount != null)
            {
                _bankdbContext.Update(account);
                _bankdbContext.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<Transaction> ReadTransaction(string iban)
        {
            var transaction = _bankdbContext.Transaction.
                Where(t => t.Iban == iban).ToList();
            return transaction;
        }

        public decimal AddTransaction()
        {
            Console.WriteLine("Input a transaction:");
            string transaction = Console.ReadLine();
            decimal DecimalTransaction = System.Convert.ToDecimal(transaction);

            return DecimalTransaction;
        }

        public Account SearchIban(string iban)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var account = context.Account.FirstOrDefault(a => a.Iban == iban);
                    return account;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }
            }
        }

       public void UpdateAccountBalance(decimal transactionDecim)
        {
            Account updateAccountBalance = Read("FI4250001510000023"); 

            updateAccountBalance.Balance = updateAccountBalance.Balance + transactionDecim;
            Update("FI4250001510000023", updateAccountBalance); 
        }

        public void CreateTransaction(Transaction transaction)
        {
            _bankdbContext.Add(transaction);
            _bankdbContext.SaveChanges();
        }
    }
}
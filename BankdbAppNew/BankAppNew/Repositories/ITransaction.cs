using System;
using System.Collections.Generic;
using System.Text;
using BankAppNew.Model;

namespace BankAppNew.Repositories
{
    interface ITransaction
    {
        List<Transaction> GetAccountsTransactions();
        List<Transaction> GetAccountTransactions(string iban);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BankAppNew.Model;

namespace BankAppNew.Repositories
{
    public interface IAccount
    {
        void Create(Account account); 

        List<Account> Read();
        Account Read(string iban);
        void Delete(string iban);

        void Update(string iban, Account account); 

    }
}

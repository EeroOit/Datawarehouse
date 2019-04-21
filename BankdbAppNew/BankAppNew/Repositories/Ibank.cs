using System;
using System.Collections.Generic;
using System.Text;
using BankAppNew.Model;

namespace BankAppNew.Repositories
{
    interface IBank
    {
        List<Bank> GetBanks();
        List<Bank> GetBankCustomers();
        List<Bank> GetBankAccounts();

        Bank Read(long id);

        void Update(long id, Bank bank);
        void Delete(long id);
        void Create(Bank bank);
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using BankAppNew.Model;

namespace BankAppNew.Repositories
{
    class BankRepo : IBank

    {
        private readonly BankdbContext _BankdbContext = new BankdbContext();

        public void Create(Bank bank)
        {
            _BankdbContext.Bank.Add(bank);
            _BankdbContext.SaveChanges();
        }
        public void CreateBank()
        {
            Bank newBank = new Bank
            {
                Name = "BankTest",
                Bic = "BICTEST"
            };
            Create(newBank);
        }
        public List<Bank> GetBanks()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank.ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }
        }

        public void Delete(long id)
        {
            var deleteBank = Read(id);
            if (deleteBank != null)
            {
                _BankdbContext.Bank.Remove(deleteBank);
                _BankdbContext.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public void DeleteBank(int id)
        {
            var bank = Read(id);
            if (bank == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                Delete(id);
                _BankdbContext.SaveChanges();
            }
        }

        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .Include(b => b.Account)
                        .Include(b => b.Account).ThenInclude(a => a.Transaction)
                        .Where(b => b.Id == 1)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }
        }

        public List<Bank> GetBankCustomers()
        {
            var banks = _BankdbContext.Bank.ToList();
            return banks;
        }

        public Bank Read(long id)
        {
            var readBank = _BankdbContext.Bank
                .AsNoTracking().Where(b => b.Id == id)
                .FirstOrDefault();
            if (readBank == null)
            {
                return null;
            }
            else
            {
                return readBank;
            }
        }

        public List<Bank> GetBankAccounts()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Account)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }
            }
        }

        public void Update(long id, Bank bank)
        {
            var checkBank = Read(id);
            if (checkBank != null)
            {
                _BankdbContext.Update(bank);
                _BankdbContext.SaveChanges();             
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateBank()
        {
            Bank updateBank = Read(1);

            updateBank.Name = "BankTestNew";
            updateBank.Bic = "BICTESTNEW";
            Update(1, updateBank);
        }

    }
}
    





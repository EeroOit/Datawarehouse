using System;
using System.Collections.Generic;
using System.Text;
using BankAppNew.Model;

namespace BankAppNew.Repositories
{
    interface ICustomer
    {
        void Create(Customer customer);

        List<Customer> Read();
        Customer Read(long id); 

       void Update(long id, Customer customer); 
       void Delete(long id);
    }
}

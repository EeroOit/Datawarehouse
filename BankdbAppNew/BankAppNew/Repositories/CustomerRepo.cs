using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using BankAppNew.Model;

namespace BankAppNew.Repositories
{
    class CustomerRepo : ICustomer
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

    public void Create(Customer customer)
    {
        _bankdbContext.Add(customer);
        _bankdbContext.SaveChanges();
    }

    public void CreateCustomer()
    {
        Customer newCustomer = new Customer();
        newCustomer.Firstname = "Matti";
        newCustomer.Lastname = "Virtanen";
        newCustomer.BankId = 2;
        Create(newCustomer);
    }

    public void Delete(long id)
    {
        var customerToDelete = Read(id);
        if (customerToDelete != null)
        {            
            _bankdbContext.Customer.Remove(customerToDelete);
            _bankdbContext.SaveChanges();
        }
        else
        {
                throw new NotImplementedException();
            }
        }

    public void DeleteCustomer(int id)
    {
        var customer = Read(id);

        if (customer == null)
        {
                throw new NotImplementedException();
            }
            else
        {
            Delete(id);            
        }
    }

    public List<Customer> Read()
    {
        var customers = _bankdbContext.Customer.ToList();
        return customers;
    }

    public Customer Read(long id)
    {
        var readCustomer = _bankdbContext.Customer
            .AsNoTracking().Where(c => c.Id == id)
            .FirstOrDefault();
        if (readCustomer == null)
        {
            return null;
        }
        else
        {
            return readCustomer;
        }
    }

    public void Update(long id, Customer customer)
    {
        var checkCustomer = Read(id);
        if (checkCustomer != null)
        {
            _bankdbContext.Update(customer);
            _bankdbContext.SaveChanges();
        }
        else
        {
                throw new NotImplementedException();
            }
        }

    public void UpdateCustomer()
    {
        Customer updateCustomer = Read(1); 

        updateCustomer.Firstname = "Maija";
        updateCustomer.Lastname = "Meikäläinen";
        updateCustomer.BankId = 1;

        Update(1, updateCustomer); 
    }
}
}

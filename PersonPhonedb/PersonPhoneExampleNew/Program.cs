using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PersonPhoneExampleNew.Repos;
using PersonPhoneExampleNew.Model;

namespace PersonPhoneExampleNew
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personReposity = new PersonRepository();

            Person newPerson = new Person();
            newPerson.Name = "Pelle Peloton";
            newPerson.Age = 60;
            newPerson.Phone = new List<Phone>
            {
                new Phone{ Type="KOTI",Number ="123456"},
                new Phone{Type="WORK", Number ="01010101" }
            };

            personReposity.Create(newPerson);
            personReposity.Delete(3);
            personReposity.Read();
            personReposity.Update(3,newPerson);
        }
    }
}

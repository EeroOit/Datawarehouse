using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PersonPhoneExampleNew.Model;

namespace PersonPhoneExampleNew.Model
{
    public interface IPersonRepository
    {
        void Create(Person person);

        List<Person> Read();
        Person Read(long id);

        void Update(long id, Person person);
        void Delete(long id);


    }
}

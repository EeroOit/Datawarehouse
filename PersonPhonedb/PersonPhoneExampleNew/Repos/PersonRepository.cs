using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonPhoneExampleNew.Model;


namespace PersonPhoneExampleNew.Repos
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersondbContext

        public void Create(Person person)
        {
            _persondbContext.Person.Add(person);
            _persondbContext.SaveChanges();
        }

        public void Delete(long id)
        {

            var person = Read(id);
            if (person != null)
            {
                _persondbContext.Person.Remove(person);
                _persondbContext.SaveChanges();
            }
        }


        public List<Person> Read()
        {
            var persons = _persondbContext.Person
            .Include(p => p.Phone)
            .ToList();
            return persons;
        }

        public Person Read(long id)
        {
            var person = _persondbContext.Person
           .Include(p => p.Phone)
           .FirstOrDefault(p => p.Id == id);
            return person;
        }

        public void Update(long id, Person person)
        {
            var updatePerson = Read(id);
            if (updatePerson != null)
            {
                _persondbContext.Person.Update(person);
                _persondbContext.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonPhoneExampleNew.Model
{
    public partial class Person
    {
        public Person()
        {
            Phone = new HashSet<Phone>();
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short? Age { get; set; }
        public string Psw { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppNew.Model
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        [Key]
        [Column("IBAN")]
        [StringLength(20)]
        public string Iban { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public virtual Bank Bank { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Account")]
        public virtual Customer Customer { get; set; }
        [InverseProperty("IbanNavigation")]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
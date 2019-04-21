using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppNew.Model
{
    public partial class Transaction
    {
        public long Id { get; set; }
        [Required]
        [Column("IBAN")]
        [StringLength(20)]
        public string Iban { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Iban")]
        [InverseProperty("Transaction")]
        public virtual Account IbanNavigation { get; set; }
    }
}
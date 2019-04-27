using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLoan.System.Web.API.Models
{
    public class Transaction
    {
        public Transaction()
        {
            this.DateTimeCreated = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public int AgreementId { get; set; }
        public Agreement Agreement { get; set; }
    }
}

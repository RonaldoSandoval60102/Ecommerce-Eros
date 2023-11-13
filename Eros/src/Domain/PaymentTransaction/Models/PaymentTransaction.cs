using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.PaymentTransaction.Models
{
    [Table("paymenttransactions")]
    public class PaymentTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_paymenttransaction")]
        public int ID_PaymentTransaction { get; set; }

        [Column("id_order")]
        public int ID_Order { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("paymentdate")]
        public DateTime PaymentDate { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [ForeignKey("ID_Order")]
        public virtual Order.Models.Order? Order { get; set; }
    }
}
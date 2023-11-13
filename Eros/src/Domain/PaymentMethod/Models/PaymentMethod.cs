using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eros.src.Domain.PaymentMethod.Models
{
    [Table("paymentmethods")]
    public class PaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_paymentmethod")]
        public int ID_PaymentMethod { get; set; }

        [Column("name")]
        public string? NamePaymentMethod { get; set; }

        public virtual Order.Models.Order? Order { get; set; }

    }
}
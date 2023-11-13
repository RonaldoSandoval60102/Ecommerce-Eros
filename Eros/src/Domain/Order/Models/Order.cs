using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.Order.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_order")]
        public int ID_Order { get; set; }

        [Column("id_user")]
        public int ID_User { get; set; }

        [Column("id_paymentmethod")]
        public int ID_PaymentMethod { get; set; }

        [Column("id_orderstatus")]
        public int ID_OrderStatus { get; set; }

        [Column("totalprice")]
        public double? TotalPrice { get; set; }

        [Column("dateorder")]
        public DateTime? DateOrder { get; set; }

        [ForeignKey("ID_User")]
        public virtual User.Models.User? User { get; set; }

        [ForeignKey("ID_PaymentMethod")]
        public virtual PaymentMethod.Models.PaymentMethod? PaymentMethod { get; set; }
    
        [ForeignKey("ID_OrderStatus")]
        public virtual OrderStatus.Models.OrderStatus? OrderStatus { get; set;}


        public virtual List<OrderDetail.Models.OrderDetail>? OrderDetails { get; set; }

        public virtual PaymentTransaction.Models.PaymentTransaction? PaymentTransaction { get; set;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.OrderDetail.Models
{
    [Table("orderdetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_orderdetail")]

        public int ID_OrderDetail { get; set; }

        [Column("id_order")]
        public int ID_Order { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [ForeignKey("ID_Order")]
        public virtual Order.Models.Order? Order { get; set; }
    }
}
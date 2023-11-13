using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.OrderStatus.Models
{
    [Table("orderstatuses")]
    public class OrderStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_orderstatus")]
        public int ID_OrderStatus { get; set; }

        [Column("name")]
        public string? NameOrderStatus { get; set; }

        public virtual Order.Models.Order? Order { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eros.src.Domain.Cart.Models
{
    [Table("carts")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_cart")]
        public int ID_Cart { get; set; }

        [Column("id_user")]
        public int ID_User { get; set; }

        [Column("id_product")]
        public int ID_Product { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("ID_User")]
        public virtual User.Models.User? User { get; set; }
    
        [ForeignKey("ID_Product")]
        public virtual Product.Models.Product? Product { get; set; }
    }
}
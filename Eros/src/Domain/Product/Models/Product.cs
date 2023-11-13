using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.Product.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_product")]
        public int ID_Product { get; set; }

        [Column("name")]
        public string? NameProduct { get; set; }

        [Column("description")]
        public string? DescriptionProduct { get; set; }

        [Column("price")]
        public double? PriceProduct { get; set; }
        
        [Column("stock")]
        public int StockProduct { get; set; }

        [Column("image")]
        public string? ImageProduct { get; set; }

        [Column("id_category")]
        public int ID_Category { get; set; }

        [ForeignKey("ID_Category")]
        public virtual Category.Models.Category? Category { get; set; }
    
        public virtual List<Cart.Models.Cart>? Carts { get; set; }
    }
}
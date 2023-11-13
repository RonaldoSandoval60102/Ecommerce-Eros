using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eros.src.Domain.Category.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_category")]
        public int ID_Category { get; set; }

        [Column("name")]
        public string? NameCategory { get; set; }

        public virtual List<Product.Models.Product>? Products { get; set; }
    }
}
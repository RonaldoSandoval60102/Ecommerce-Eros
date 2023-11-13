using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.User.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_user")]
        public int ID_User { get; set; }

        [Column("firstname")]
        public string? NameUser { get; set; }

        [Column("lastname")]
        public string? LastNameUser { get; set; }

        [Column("email")]
        public string? EmailUser { get; set; }

        [Column("password")]
        public string? PasswordUser { get; set; }

        [Column("cash")]
        public double Cash { get; set; }

        public virtual List<Order.Models.Order>? Orders { get; set; }
    
        public virtual List<Cart.Models.Cart>? Carts { get; set;}

        public virtual Address.Models.Address? Address { get; set; }    
        public virtual AuditLog.Models.AuditLog? AuditLog { get; set;}
    }
}
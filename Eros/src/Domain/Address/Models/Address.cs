using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eros.src.Domain.Address.Models
{
    [Table("addresses")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_address")]
        public int ID_Address { get; set; }

        [Column("id_user")]
        public int ID_User { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("streetaddress")]
        public string? StreetAddress { get; set; }

        [Column("city")]
        public string? City { get; set; }

        [Column("state")]
        public string? State { get; set; }

        [Column("postalcode")]
        public string? PostalCode { get; set; }

        [ForeignKey("ID_User")]
        public virtual User.Models.User? User { get; set; }
    }
}
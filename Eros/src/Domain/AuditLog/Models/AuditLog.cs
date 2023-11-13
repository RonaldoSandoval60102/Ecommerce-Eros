using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eros.src.Domain.AuditLog.Models
{
    [Table("auditlogs")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_auditlog")]
        public int ID_AuditLog { get; set; }

        [Column("id_user")]
        public int ID_User { get; set; }

        [Column("action")]
        public string? Action { get; set; }

        [Column("tablename")]
        public string? TableName { get; set; }

        [Column("recordid")]
        public int RecordID { get; set; }

        [Column("timestamp")]
        public DateTime? Timestamp { get; set; }

        [ForeignKey("ID_User")]
        public virtual User.Models.User? User { get; set; }
    }
}
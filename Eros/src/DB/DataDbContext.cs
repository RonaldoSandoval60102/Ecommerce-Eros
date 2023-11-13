using Microsoft.EntityFrameworkCore;

namespace Eros.src.DB
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options): base(options)
        {
        }

        public DbSet<Domain.Category.Models.Category> Categories { get; set; }


        public DbSet<Domain.OrderStatus.Models.OrderStatus> OrderStatus { get; set; }

        public DbSet<Domain.Product.Models.Product> Products { get; set; }

        public DbSet<Domain.User.Models.User> Users { get; set; }

        public DbSet<Domain.OrderDetail.Models.OrderDetail> OrderDetails { get; set; }

        public DbSet<Domain.Order.Models.Order> Orders { get; set; }

        public DbSet<Domain.PaymentMethod.Models.PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Domain.Cart.Models.Cart> Carts { get; set; }
    
        public DbSet<Domain.Address.Models.Address> Addresses { get; set; }
    
        public DbSet<Domain.AuditLog.Models.AuditLog> AuditLogs { get; set; }
    
        public DbSet<Domain.PaymentTransaction.Models.PaymentTransaction> PaymentTransactions { get; set; }
    }
}
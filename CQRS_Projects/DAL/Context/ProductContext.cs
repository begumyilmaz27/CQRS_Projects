using CQRS_Projects.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Projects.DAL.Context
{
    public class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-MC9V08U\\SQLEXPRESS;initial catalog=CQRSDb;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}

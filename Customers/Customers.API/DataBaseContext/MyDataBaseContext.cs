using Customers.API.Models;

using Microsoft.EntityFrameworkCore;

namespace Customers.API.DataBaseContext
{
    public class MyDataBaseContext : DbContext
    {
        public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options) : base(options)
        {
        }        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasAlternateKey(e =>e.Email);
                    entity.HasAlternateKey(e => e.Dni);
                }
                );
                
                
            
               





        }

    }

}

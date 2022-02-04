using Microsoft.EntityFrameworkCore;
using Blazor.back.Models;
namespace Blazor.back.Data
{
    public class MyContext : DbContext
    {
        public MyContext()
        {

            Database.EnsureCreated();
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Cliente> cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

    }
}
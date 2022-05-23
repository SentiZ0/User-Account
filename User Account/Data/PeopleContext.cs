using User_Account.Models;
using Microsoft.EntityFrameworkCore;


namespace User_Account.Data
{

    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(b => b.LastName)
                .IsRequired(false);
            modelBuilder.Entity<Person>()
                .Property(b => b.UserName)
                .IsRequired(false);
        }
    }
}

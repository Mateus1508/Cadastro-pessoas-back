using CadastroPersonsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPersonsAPI
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
        { }

        public DbSet<PersonModel> Person { get; set; }
        public DbSet<AddressModel> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

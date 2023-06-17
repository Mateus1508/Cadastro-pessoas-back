using CadastroPessoasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoasAPI
{
    public class CadastroDbContext : DbContext
    {
        public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
        { }

        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

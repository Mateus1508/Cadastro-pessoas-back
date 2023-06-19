using CadastroPessoasAPI.Models;
using CadastroPessoasAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoasAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CadastroDbContext _dbContext;

        public EnderecoRepository(CadastroDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<EnderecoModel>> GetAll()
        {
            return await _dbContext.Endereco.ToListAsync();
        }

        public async Task<List<EnderecoModel>> GetByPessoaId(int pessoaId)
        {
            return await _dbContext.Endereco.Where(x => x.PessoaId == pessoaId).AsNoTracking().ToListAsync();
        }

        public async Task<EnderecoModel> GetById(int id)
        {
            return await _dbContext.Endereco.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteById(int id)
        {
            EnderecoModel EnderecoById = await GetById(id) ?? throw new Exception("Usuário não encontrado!");

            _dbContext.Endereco.Remove(EnderecoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

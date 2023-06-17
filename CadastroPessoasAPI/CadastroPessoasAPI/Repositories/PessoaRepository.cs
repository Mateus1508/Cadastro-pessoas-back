using CadastroPessoasAPI.Models;
using CadastroPessoasAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoasAPI.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly CadastroDbContext _dbContext;

        public PessoaRepository(CadastroDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<PessoaModel>> GetAll()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }

        public async Task<PessoaModel> GetById(int id)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PessoaModel> AddPessoa(PessoaModel pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<PessoaModel> UpdatePessoa(PessoaModel pessoa, int id)
        {
            PessoaModel pessoaById = await GetById(id) ?? throw new Exception("Usuário não encontrado!");

            pessoaById.TipoPessoa = pessoa.TipoPessoa;
            pessoaById.CPF_CNPJ = pessoa.CPF_CNPJ;
            pessoaById.Nome_RazaoSocial = pessoa.Nome_RazaoSocial;
            pessoaById.Telefone = pessoa.Telefone;
            pessoaById.Email = pessoa.Email;
            pessoaById.Endereco = pessoa.Endereco;

            _dbContext.Pessoa.Update(pessoaById);
            await _dbContext.SaveChangesAsync();

            return pessoaById;
        }

        public async Task<bool> DeleteById(int id)
        {
            PessoaModel categoryById = await GetById(id) ?? throw new Exception("Usuário não encontrado!");

            _dbContext.Pessoa.Remove(categoryById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

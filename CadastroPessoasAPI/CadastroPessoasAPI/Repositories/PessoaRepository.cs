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
            var query = from pessoa in _dbContext.Pessoa
                        join endereco in _dbContext.Endereco
                            on pessoa.Id equals endereco.PessoaId into enderecoJoin
                            select new PessoaModel
                            {
                                Id = pessoa.Id,
                                CPF_CNPJ = pessoa.CPF_CNPJ,
                                TipoPessoa = pessoa.TipoPessoa,
                                Nome_RazaoSocial = pessoa.Nome_RazaoSocial,
                                Telefone = pessoa.Telefone,
                                Email = pessoa.Email,
                                Endereco = enderecoJoin.ToList(),
                            };

            return await query.ToListAsync();
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
            PessoaModel PessoaById = await GetById(id) ?? throw new Exception("Usuário não encontrado!");

            _dbContext.Pessoa.Remove(PessoaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

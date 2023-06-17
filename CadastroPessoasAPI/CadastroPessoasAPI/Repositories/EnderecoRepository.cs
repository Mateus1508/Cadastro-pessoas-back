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

        public async Task<EnderecoModel> GetById(int id)
        {
            return await _dbContext.Endereco.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EnderecoModel> UpdateEndereco(EnderecoModel endereco, int id)
        {
            EnderecoModel enderecoById = await GetById(id);

            if (enderecoById == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            enderecoById.TipoEndereco = endereco.TipoEndereco;
            enderecoById.Pessoa = endereco.Pessoa;
            enderecoById.Endereco = endereco.Endereco;
            enderecoById.CEP = endereco.CEP;
            enderecoById.UF = endereco.UF;
            enderecoById.Cidade = endereco.Cidade;
            enderecoById.Bairro = endereco.Bairro;
            enderecoById.Numero = endereco.Numero;
            enderecoById.Complemento = endereco.Complemento;

            _dbContext.Endereco.Update(enderecoById);
            await _dbContext.SaveChangesAsync();

            return enderecoById;
        }
        
        public async Task<bool> DeleteById(int id)
        {
            EnderecoModel enderecoById = await GetById(id);

            if (enderecoById == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            _dbContext.Endereco.Remove(enderecoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

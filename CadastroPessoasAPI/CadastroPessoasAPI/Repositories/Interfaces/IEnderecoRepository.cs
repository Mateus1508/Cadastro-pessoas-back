using CadastroPessoasAPI.Models;

namespace CadastroPessoasAPI.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<List<EnderecoModel>> GetAll();

        Task<EnderecoModel> GetById(int id);

        Task<List<EnderecoModel>> GetByPessoaId(int pessoaId);

        Task<bool> DeleteById(int id);
    }
}

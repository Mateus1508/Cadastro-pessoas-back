using CadastroPessoasAPI.Models;

namespace CadastroPessoasAPI.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<PessoaModel>> GetAll();

        Task<PessoaModel> GetById(int id);

        Task<PessoaModel> AddPessoa(PessoaModel pessoa);

        Task<PessoaModel> UpdatePessoa(PessoaModel pessoa, int id);

        Task<bool> DeleteById(int id);

    }
}

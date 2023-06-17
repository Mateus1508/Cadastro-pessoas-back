using CadastroPessoasAPI.Models;

namespace CadastroPessoasAPI.Repositories.Interfaces
{
    public interface IEnderecoRepository 
    {
        Task<EnderecoModel> GetById(int id);

        Task<EnderecoModel> UpdateEndereco(EnderecoModel endereco, int id);

        Task<bool> DeleteById(int id);
    }
}

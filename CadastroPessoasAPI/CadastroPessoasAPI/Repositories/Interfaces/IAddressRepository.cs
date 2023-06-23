using CadastroPersonsAPI.Models;

namespace CadastroPersonsAPI.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<AddressModel>> GetAll();

        Task<AddressModel> GetById(int id);

        Task<List<AddressModel>> GetByPessoaId(int pessoaId);

        Task<bool> DeleteById(int id);
    }
}

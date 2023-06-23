using CadastroPersonsAPI.Models;

namespace CadastroPersonsAPI.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<PersonModel>> GetAll();

        Task<PersonModel> GetById(int id);

        Task<PersonModel> AddPerson(PersonModel pessoa);

        Task<PersonModel> UpdatePerson(PersonModel pessoa, int id);

        Task<bool> DeleteById(int id);

    }
}

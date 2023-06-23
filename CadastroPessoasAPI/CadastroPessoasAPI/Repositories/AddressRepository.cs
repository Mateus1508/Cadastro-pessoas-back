using CadastroPersonsAPI.Models;
using CadastroPersonsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroPersonsAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly RegisterDbContext _dbContext;

        public AddressRepository(RegisterDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<AddressModel>> GetAll()
        {
            return await _dbContext.Address.ToListAsync();
        }

        public async Task<List<AddressModel>> GetByPessoaId(int pessoaId)
        {
            return await _dbContext.Address.Where(x => x.PessoaId == pessoaId).AsNoTracking().ToListAsync();
        }

        public async Task<AddressModel> GetById(int id)
        {
            return await _dbContext.Address.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteById(int id)
        {
            AddressModel AddressById = await GetById(id) ?? throw new ExCeption("Usuário não encontrado!");

            _dbContext.Address.Remove(AddressById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

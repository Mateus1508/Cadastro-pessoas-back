using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_pedidos.Repositories
{
    public class ItensDePedidoRepository : IItensDePedidoRepository
    {
        private readonly ControlePedidosDbContext _dbContext;

        public ItensDePedidoRepository(ControlePedidosDbContext controlePedidosDbContext)
        {
            _dbContext = controlePedidosDbContext;
        }

        public async Task<List<ItensDePedidoModel>> GetAll()
        {
            return await _dbContext.ItensDePedido.ToListAsync();
        }

        public async Task<ItensDePedidoModel> GetById(int id)
        {
            return await _dbContext.ItensDePedido.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItensDePedidoModel> AddItem(ItensDePedidoModel item)
        {
            await _dbContext.ItensDePedido.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteById(int id)
        {
            ItensDePedidoModel itemById = await GetById(id) ?? throw new Exception("Usuário não encontrado!");

            _dbContext.ItensDePedido.Remove(itemById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

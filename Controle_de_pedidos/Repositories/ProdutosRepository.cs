using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_pedidos.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ControlePedidosDbContext _dbContext;

        public ProdutosRepository(ControlePedidosDbContext controlePedidosDbContext)
        {
            _dbContext = controlePedidosDbContext;
        }

        public async Task<List<ProdutosModel>> GetAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<ProdutosModel> GetById(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProdutosModel> AddProduto(ProdutosModel produtos)
        {
            await _dbContext.Produtos.AddAsync(produtos);
            await _dbContext.SaveChangesAsync();
            return produtos;
        }

        public Task<ProdutosModel> UpdateProduto(ProdutosModel produtos, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteById(int id)
        {
            ProdutosModel produtoById = await GetById(id) ?? throw new Exception("Produto não encontrado!");

            _dbContext.Produtos.Remove(produtoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

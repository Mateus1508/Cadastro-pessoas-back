using System.Collections.ObjectModel;

namespace Controle_de_pedidos.Models
{
    public class ItensDePedidoModel
    {
        public ItensDePedidoModel()
        {
            Produto = new Collection<ProdutosModel>();
        }

        public int Id { get; set; }
        public int PedidoId { get; set;}
        public PedidosModel Pedido { get; set;}
        public int ProdutoId { get; set; }
        public ICollection<ProdutosModel> Produto { get; set; }
        public int Quantidade { get; set;}
        public decimal Valor { get; set;}
    }
}

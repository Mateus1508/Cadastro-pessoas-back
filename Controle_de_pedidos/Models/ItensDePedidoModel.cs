using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "decimal(9,2)")]
        public decimal Valor { get; set;}
    }
}

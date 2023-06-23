namespace Controle_de_pedidos.Models
{
    public class PedidosModel
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

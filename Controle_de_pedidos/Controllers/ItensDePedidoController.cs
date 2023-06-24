using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_pedidos.Controllers
{
    [Route("api/itens")]
    [ApiController]
    public class ItensDePedidoController : Controller
    {
        private readonly IItensDePedidoRepository _itensDePedidosRepository;

        public ItensDePedidoController(IItensDePedidoRepository iTensDePedidosRepository)
        {
            _itensDePedidosRepository = iTensDePedidosRepository;
        }
    }
}

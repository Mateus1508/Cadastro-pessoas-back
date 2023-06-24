using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_pedidos.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosController(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository  = pedidosRepository;
        }
    }
}

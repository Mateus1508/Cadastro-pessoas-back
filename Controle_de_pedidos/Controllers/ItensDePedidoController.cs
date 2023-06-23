using Microsoft.AspNetCore.Mvc;

namespace Controle_de_pedidos.Controllers
{
    public class ItensDePedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

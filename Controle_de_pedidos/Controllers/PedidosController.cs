using Microsoft.AspNetCore.Mvc;

namespace Controle_de_pedidos.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

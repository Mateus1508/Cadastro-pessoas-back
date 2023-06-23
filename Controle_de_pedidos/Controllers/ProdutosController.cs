using Microsoft.AspNetCore.Mvc;

namespace Controle_de_pedidos.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

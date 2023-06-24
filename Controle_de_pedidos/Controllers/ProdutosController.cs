using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_pedidos.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
    }
}

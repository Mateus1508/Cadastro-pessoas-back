using CadastroPessoasAPI.Models;
using CadastroPessoasAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CadastroPessoasAPI.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnderecoModel>>> GetAll()
        {
            try
            {
                List<EnderecoModel> endereco = await _enderecoRepository.GetAll();
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
        
        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<List<EnderecoModel>>> GetByPessoaId([BindRequired] int pessoaId)
        {
            try
            {
                List<EnderecoModel> endereco = await _enderecoRepository.GetByPessoaId(pessoaId);
                if (endereco == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoModel>> DeleteEndereco([BindRequired] int id)
        {
            try

            {
                bool deletedEndereco = await _enderecoRepository.DeleteById(id);
                return Ok(deletedEndereco);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
    }
}

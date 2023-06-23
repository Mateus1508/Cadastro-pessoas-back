using CadastroPersonsAPI.Models;
using CadastroPersonsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CadastroPersonsAPI.Controllers
{
    [Route("api/endereco")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _enderecoRepository;

        public AddressController(IAddressRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressModel>>> GetAll()
        {
            try
            {
                List<AddressModel> endereco = await _enderecoRepository.GetAll();
                return Ok(endereco);
            }
            catch (ExCeption ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
        
        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<List<AddressModel>>> GetByPessoaId([BindRequired] int pessoaId)
        {
            try
            {
                List<AddressModel> endereco = await _enderecoRepository.GetByPessoaId(pessoaId);
                if (endereco == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(endereco);
            }
            catch (ExCeption ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressModel>> DeleteAddress([BindRequired] int id)
        {
            try

            {
                bool deletedAddress = await _enderecoRepository.DeleteById(id);
                return Ok(deletedAddress);
            }
            catch (ExCeption ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
    }
}

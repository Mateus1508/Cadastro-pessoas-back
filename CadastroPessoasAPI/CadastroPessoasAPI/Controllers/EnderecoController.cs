using CadastroPessoasAPI.Models;
using CadastroPessoasAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CadastroPessoasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EnderecoModel>>> GetById([BindRequired] int id)
        {
            try
            {
                EnderecoModel endereco = await _enderecoRepository.GetById(id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<EnderecoModel>> UpdateItem([FromBody] EnderecoModel enderecoModel, int id)
        {
            try
            {
                enderecoModel.Id = id;
                EnderecoModel endereco = await _enderecoRepository.UpdateEndereco(enderecoModel, id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoModel>> DeleteCategory([BindRequired] int id)
        {
            try
            {
                bool deletedCategory = await _enderecoRepository.DeleteById(id);
                return Ok(deletedCategory);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
    }
}
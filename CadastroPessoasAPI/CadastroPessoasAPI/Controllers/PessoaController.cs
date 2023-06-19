using CadastroPessoasAPI.Models;
using CadastroPessoasAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CadastroPessoasAPI.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> GetAll()
        {
            
                List<PessoaModel> pessoa = await _pessoaRepository.GetAll();
                return Ok(pessoa);
          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PessoaModel>>> GetById([BindRequired] int id)
        {
            try
            {
                PessoaModel pessoa = await _pessoaRepository.GetById(id);
                if (pessoa == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PessoaModel>> AddPessoa([FromBody] PessoaModel pessoaModel)
        {
            try
            {
                PessoaModel pessoa = await _pessoaRepository.AddPessoa(pessoaModel);
                return Ok(pessoa.Id);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaModel>> UpdatePessoa([FromBody] PessoaModel pessoaModel, int id)
        {
            try
            {
                pessoaModel.Id = id;
                PessoaModel item = await _pessoaRepository.UpdatePessoa(pessoaModel, id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaModel>> DeleteEndereco([BindRequired] int id)
        {
            try
            {
                bool deletedPessoa = await _pessoaRepository.DeleteById(id);
                return Ok(deletedPessoa);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
    }
}

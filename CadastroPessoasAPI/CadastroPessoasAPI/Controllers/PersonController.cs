using CadastroPersonsAPI.Models;
using CadastroPersonsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CadastroPersonsAPI.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _pessoaRepository;

        public PersonController(IPersonRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonModel>>> GetAll()
        {
            
                List<PersonModel> pessoa = await _pessoaRepository.GetAll();
                return Ok(pessoa);
          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PersonModel>>> GetById([BindRequired] int id)
        {
            try
            {
                PersonModel pessoa = await _pessoaRepository.GetById(id);
                if (pessoa == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(pessoa);
            }
            catch (ExCeption ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> AddPerson([FromBody] PersonModel pessoaModel)
        {
            try
            {
                PersonModel pessoa = await _pessoaRepository.AddPerson(pessoaModel);
                return Ok(pessoa.Id);
            }
            catch (ExCeption ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonModel>> UpdatePerson([FromBody] PersonModel pessoaModel, int id)
        {
           
                pessoaModel.Id = id;
                PersonModel item = await _pessoaRepository.UpdatePerson(pessoaModel, id);
                return Ok(item);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonModel>> DeleteAddress([BindRequired] int id)
        {
            try
            {
                bool deletedPerson = await _pessoaRepository.DeleteById(id);
                return Ok(deletedPerson);
            }
            catch (ExCeption ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
    }
}

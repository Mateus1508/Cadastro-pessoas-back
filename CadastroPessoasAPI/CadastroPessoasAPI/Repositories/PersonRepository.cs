using CadastroPersonsAPI.Models;
using CadastroPersonsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroPersonsAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly RegisterDbContext _dbContext;

        public PersonRepository(RegisterDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<PersonModel>> GetAll()
        {
            var query = from pessoa in _dbContext.Person
                        join endereco in _dbContext.Address
                            on pessoa.Id equals endereco.PessoaId into enderecoJoin
                            select new PersonModel
                            {
                                Id = pessoa.Id,
                                Cpf_cnpj = pessoa.Cpf_cnpj,
                                TipoPerson = pessoa.TipoPerson,
                                Nome_RazaoSocial = pessoa.Nome_RazaoSocial,
                                Telefone = pessoa.Telefone,
                                Email = pessoa.Email,
                                Address = enderecoJoin.ToList(),
                            };

            return await query.ToListAsync();
        }

        public async Task<PersonModel> GetById(int id)
        {
            var query = from pessoa in _dbContext.Person
                        join endereco in _dbContext.Address
                        on pessoa.Id equals endereco.PessoaId into enderecoJoin
                        where pessoa.Id == id
                        select new PersonModel
                        {
                            Id = pessoa.Id,
                            Cpf_cnpj = pessoa.Cpf_cnpj,
                            TipoPerson = pessoa.TipoPerson,
                            Nome_RazaoSocial = pessoa.Nome_RazaoSocial,
                            Telefone = pessoa.Telefone,
                            Email = pessoa.Email,
                            Address = enderecoJoin.ToList(),
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PersonModel> AddPerson(PersonModel pessoa)
        {
            await _dbContext.Person.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<PersonModel> UpdatePerson(PersonModel pessoa, int id)
        {
            PersonModel pessoaById = await GetById(id);

            if (pessoaById != null)
            {
                pessoaById.TipoPerson = pessoa.TipoPerson;
                pessoaById.Cpf_cnpj = pessoa.Cpf_cnpj;
                pessoaById.Nome_RazaoSocial = pessoa.Nome_RazaoSocial;
                pessoaById.Telefone = pessoa.Telefone;
                pessoaById.Email = pessoa.Email;

                foreach (var enderecoModel in pessoa.Address)
                {
                    var enderecoExistente = pessoaById.Address.FirstOrDefault(e => e.Id == enderecoModel.Id);

                    if (enderecoExistente != null)
                    {
                        enderecoExistente.TipoAddress = enderecoModel.TipoAddress;
                        enderecoExistente.Address = enderecoModel.Address;
                        enderecoExistente.Numero = enderecoModel.Numero;
                        enderecoExistente.Complemento = enderecoModel.Complemento;
                        enderecoExistente.Bairro = enderecoModel.Bairro;
                        enderecoExistente.Cep = enderecoModel.Cep;
                        enderecoExistente.Cidade = enderecoModel.Cidade;
                        enderecoExistente.UF = enderecoModel.UF;
                    }
                    else
                    {
                        pessoaById.Address.Add(enderecoModel);
                    }
                }

                _dbContext.Person.Update(pessoaById);
                await _dbContext.SaveChangesAsync();

                return pessoaById;
            }
            else
            {
                throw new ExCeption("Usuário não encontrado!");
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            PersonModel PersonById = await GetById(id) ?? throw new ExCeption("Usuário não encontrado!");

            _dbContext.Person.Remove(PersonById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

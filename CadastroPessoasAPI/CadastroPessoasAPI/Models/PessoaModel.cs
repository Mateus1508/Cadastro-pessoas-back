using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroPessoasAPI.Models
{
    public class PessoaModel
    {

        public PessoaModel() {
            Endereco = new Collection<EnderecoModel>();
        }    

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF_CNPJ { get; set; }

        [Required]
        public string TipoPessoa { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome_RazaoSocial { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public ICollection<EnderecoModel> Endereco { get; set; }
    }
}

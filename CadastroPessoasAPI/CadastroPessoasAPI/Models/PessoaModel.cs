using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroPessoasAPI.Models
{
    public class PessoaModel
    {
        [Key]
        [JsonIgnore]
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

        [JsonIgnore]
        public EnderecoModel? Endereco { get; set; }
    }
}

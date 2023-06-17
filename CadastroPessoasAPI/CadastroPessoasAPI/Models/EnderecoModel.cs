using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroPessoasAPI.Models
{
    public class EnderecoModel
    {

        public EnderecoModel()
        {
            Pessoa = new Collection<PessoaModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public ICollection<PessoaModel>? Pessoa { get; set; }

        public int PessoaId { get; set;}

        [Required]
        public string TipoEndereco { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [StringLength(10)]
        public int? Numero { get; set; }

        [StringLength(300)]
        public string? Complemento { get; set; }

        [Required]
        [StringLength(200)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(8)]
        public int CEP { get; set; }

        [Required]
        [StringLength(200)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }
    }
}

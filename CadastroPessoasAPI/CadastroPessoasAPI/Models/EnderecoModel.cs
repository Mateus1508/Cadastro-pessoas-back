using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace CadastroPessoasAPI.Models
{
    public class EnderecoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PessoaId { get; set; }

        [JsonIgnore]
        public PessoaModel? Pessoa { get; set; }

        [Required]
        public string TipoEndereco { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        public int? Numero { get; set; }

        [StringLength(300)]
        public string? Complemento { get; set; }

        [Required]
        [StringLength(200)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(9)]
        public string CEP { get; set; }

        [Required]
        [StringLength(200)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }
    }
}

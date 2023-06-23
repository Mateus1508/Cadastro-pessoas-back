using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroPersonsAPI.Models
{
    public class PersonModel
    {

        public PersonModel() {
            Address = new Collection<AddressModel>();
        }    

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(14)]
        public string Cpf_cnpj { get; set; }

        [Required]
        public string TipoPerson { get; set; }

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
        public ICollection<AddressModel> Address { get; set; }
    }
}

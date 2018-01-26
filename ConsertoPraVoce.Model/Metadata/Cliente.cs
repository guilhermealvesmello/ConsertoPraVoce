using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Model
{
    [DisplayName("Cliente")]
    [MetadataTypeAttribute(typeof(Cliente.Metadata))]
    public partial class Cliente
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Nome")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            public string Nome { get; set; }

            [MaxLength(100, ErrorMessage = "Máximo número de caracteres: 100")]
            public string Email { get; set; }

            [DisplayName("Telefone 1")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            public string Telefone1 { get; set; }

            [DisplayName("Telefone 2")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            public string Telefone2 { get; set; }

            [DisplayName("Data de Nascimento")]
            public DateTime DataNascimento { get; set; }

            [DisplayName("Notas")]
            [MaxLength(500, ErrorMessage = "Máximo número de caracteres: 500")]
            public string Notas { get; set; }

            [DisplayName("Data")]
            public DateTime Data { get; set; }

        }

    }
}
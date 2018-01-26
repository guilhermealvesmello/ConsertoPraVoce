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
    [DisplayName("Usuário")]
    [MetadataTypeAttribute(typeof(Usuario.Metadata))]
    public partial class Usuario
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

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Email")]
            [MaxLength(150, ErrorMessage = "Máximo número de caracteres: 150")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Senha")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            public string Senha { get; set; }

        }

    }
}
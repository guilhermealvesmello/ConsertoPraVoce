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
    [DisplayName("Tipo de Aparelho")]
    [MetadataTypeAttribute(typeof(TipoAparelho.Metadata))]
    public partial class TipoAparelho
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Descrição")]
            [MaxLength(25, ErrorMessage = "Máximo número de caracteres: 25")]
            public string Descricao { get; set; }

        }

    }
}
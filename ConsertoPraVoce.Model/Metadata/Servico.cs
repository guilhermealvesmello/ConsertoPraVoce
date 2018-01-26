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
    [DisplayName("Serviço")]
    [MetadataTypeAttribute(typeof(Servico.Metadata))]
    public partial class Servico
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Descrição")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            public string Descricao { get; set; }

        }

    }
}
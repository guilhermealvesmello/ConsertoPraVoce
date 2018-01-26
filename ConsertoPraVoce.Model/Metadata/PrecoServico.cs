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
    [DisplayName("Preço do Serviço")]
    [MetadataTypeAttribute(typeof(PrecoServico.Metadata))]
    public partial class PrecoServico
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Código do Seviço")]
            public int IdServico { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Editado em")]
            public DateTime DataAtualizacao { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Preço em Dinheiro")]
            public decimal PrecoDinheiro { get; set; }

            [DisplayName("Preço no Débito")]
            public decimal PrecoDebito { get; set; }

            [DisplayName("Preço no Crédito")]
            public decimal PrecoCredito { get; set; }

        }

    }
}
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
    [DisplayName("Método de Pagamento")]
    [MetadataTypeAttribute(typeof(MetodoPagamento.Metadata))]
    public partial class MetodoPagamento
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

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Parcelas")]
            public int Parcelas { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Taxa")]
            public int Taxa { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Prazo para Pagamento")]
            public int PrazoPagamento { get; set; }

        }

    }
}
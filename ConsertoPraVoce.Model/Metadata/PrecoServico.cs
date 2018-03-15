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
            [DisplayName("Seviço")]
            public int IdServico { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Editado em")]
			[DataType(DataType.Date)]
			[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "")]
			public DateTime DataAtualizacao { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Preço em Dinheiro")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
			//[DisplayFormat(DataFormatString = "{0:C0,00}", ApplyFormatInEditMode = true)]
			public decimal PrecoDinheiro { get; set; }

            [DisplayName("Preço no Débito")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
			//[DisplayFormat(DataFormatString = "{0:C0,00}", ApplyFormatInEditMode = true)]
			public decimal PrecoDebito { get; set; }

            [DisplayName("Preço no Crédito")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
			//[UIHint("Currency")]
			//[DisplayFormat(DataFormatString = "{0:C0,00}", ApplyFormatInEditMode = true)]
			public decimal PrecoCredito { get; set; }

        }

    }
}
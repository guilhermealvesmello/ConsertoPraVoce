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
			[DataType(DataType.Date)]
			[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "")]
			public DateTime DataAtualizacao { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Preço em Dinheiro")]
			[DataType(DataType.Currency)]
			[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
			public decimal PrecoDinheiro { get; set; }

            [DisplayName("Preço no Débito")]
			[DataType(DataType.Currency)]
			[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
			public decimal PrecoDebito { get; set; }

            [DisplayName("Preço no Crédito")]
			[DataType(DataType.Currency)]
			[UIHint("Currency")]
			[DisplayFormat(DataFormatString ="{0:C0}", ApplyFormatInEditMode = true)]
			public decimal PrecoCredito { get; set; }

        }

    }
}
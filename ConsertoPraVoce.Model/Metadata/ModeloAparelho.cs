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
    [DisplayName("Modelos de Aparelhos")]
    [MetadataTypeAttribute(typeof(ModeloAparelho.Metadata))]
    public partial class ModeloAparelho
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
            
            [DisplayName("Número do Modelo")]            
			public string NumeroModelo { get; set; }

			[Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
			[DisplayName("Tipo do Aparelho")]			
			public int IdTipoAparelho { get; set; }

			[Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
			[DisplayName("Marca")]
			public int IdMarca { get; set; }
		}

    }
}
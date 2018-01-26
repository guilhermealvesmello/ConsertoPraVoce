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
    [DisplayName("Categoria da Transação")]
    [MetadataTypeAttribute(typeof(CategoriaTransacao.Metadata))]
    public partial class CategoriaTransacao
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            [DisplayName("Descrição")]
            public string Descricao { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Descrição Longa")]
            public string DescricaoLonga { get; set; }

        }

    }
}
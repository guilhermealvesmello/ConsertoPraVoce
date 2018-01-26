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
    [DisplayName("Ordem de Serviço")]
    [MetadataTypeAttribute(typeof(OrdemServico.Metadata))]
    public partial class OrdemServico
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Descrição Curta")]
            [MaxLength(50, ErrorMessage = "Máximo número de caracteres: 50")]
            public string DescricaoCurta { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Descrição Longa")]
            [MaxLength(500, ErrorMessage = "Máximo número de caracteres: 500")]
            public string DescricaoLonga { get; set; }

            [DisplayName("Criada em")]
            public DateTime DataCriacao { get; set; }
            
            [DisplayName("Editada em")]
            public DateTime DataEdicao { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Prazo")]
            public DateTime Prazo { get; set; }

        }

    }
}
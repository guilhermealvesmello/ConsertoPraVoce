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
    [DisplayName("Transação")]
    [MetadataTypeAttribute(typeof(Transacao.Metadata))]
    public partial class Transacao
    {
        internal sealed class Metadata
        {
            [Required]
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Data da Trasação")]
            public DateTime DataTransacao { get; set; }

            [DisplayName("Descrição")]
            [MaxLength(150, ErrorMessage = "Máximo número de caracteres: 150")]
            public string Descricao { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Valor Bruto")]
            public decimal ValorBruto { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Valor Líquido")]
            public decimal ValorLiquido { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Categoria da Transação")]
            public int IdCategoriaTransacao { get; set; }

            [DisplayName("Cliente")]
            public int IdCliente { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Pagamento Efetuado")]
            public bool PagamentoEfetuado { get; set; }

            [DisplayName("Detalhes")]
            [MaxLength(500, ErrorMessage = "Máximo número de caracteres: 500")]
            public string Detalhes { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Conta")]
            public int IdConta { get; set; }

            [DisplayName("Ordem de Serviço")]
            public int IdOrdemServico { get; set; }

            [Required(ErrorMessage = "Você não pode deixar este campo em branco.")]
            [DisplayName("Tipo de Entrada")]
            public string TipoEntrada { get; set; }

        }

    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsertoPraVoce.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransacaoItem
    {
        public int Id { get; set; }
        public int IdTransacao { get; set; }
        public string Observacao { get; set; }
        public System.DateTime DataTransacao { get; set; }
        public System.DateTime DataPrevistaCredito { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public Nullable<int> QuantidadeParcelas { get; set; }
        public Nullable<int> NumeroParcela { get; set; }
        public bool PagamentoEfetuado { get; set; }
        public System.DateTime DataAlteracao { get; set; }
    
        public virtual Transacao Transacao { get; set; }
    }
}
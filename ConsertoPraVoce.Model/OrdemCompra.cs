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
    
    public partial class OrdemCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdemCompra()
        {
            this.Entrada = new HashSet<Entrada>();
            this.Transacao = new HashSet<Transacao>();
        }
    
        public int Id { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public Nullable<System.DateTime> DataEdicao { get; set; }
        public Nullable<int> IdFornecedor { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrada> Entrada { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacao> Transacao { get; set; }
    }
}

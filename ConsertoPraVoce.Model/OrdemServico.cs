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
    
    public partial class OrdemServico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdemServico()
        {
            this.Transacao = new HashSet<Transacao>();
            this.Saida = new HashSet<Saida>();
        }
    
        public int Id { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public Nullable<System.DateTime> DataEdicao { get; set; }
        public Nullable<System.DateTime> Prazo { get; set; }
        public int IdCliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacao> Transacao { get; set; }
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Saida> Saida { get; set; }
    }
}

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
    
    public partial class CategoriaTransacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaTransacao()
        {
            this.Transacoes = new HashSet<Transacoes>();
        }
    
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoLonga { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacoes> Transacoes { get; set; }
    }
}

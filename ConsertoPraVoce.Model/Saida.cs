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
    
    public partial class Saida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Saida()
        {
            this.ItemSaida = new HashSet<ItemSaida>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdOrdemServico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSaida> ItemSaida { get; set; }
        public virtual OrdemServico OrdemServico { get; set; }
    }
}

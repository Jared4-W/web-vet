//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen1_JaredChavez.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbMunicipios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbMunicipios()
        {
            this.tbLocalidades = new HashSet<tbLocalidades>();
        }
    
        public short IdMunicipio { get; set; }

        [Required(ErrorMessage = "Debes capturar el nombre del municipio.")]
        public string Municipio { get; set; }
        public Nullable<byte> IdEstado { get; set; }
    
        public virtual tbEstados tbEstados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbLocalidades> tbLocalidades { get; set; }
    }
}

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

    public partial class tbLocalidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbLocalidades()
        {
            this.tbVeterinarios = new HashSet<tbVeterinarios>();
        }
    
        public int IdLocalidad { get; set; }

        [Required(ErrorMessage = "Debes capturar el nombre de la localidad.")]
        public string Localidad { get; set; }
        public Nullable<short> IdMunicipio { get; set; }
    
        public virtual tbMunicipios tbMunicipios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbVeterinarios> tbVeterinarios { get; set; }
    }
}
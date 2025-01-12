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

    public partial class tbVeterinarios
    {
        public byte IdVet { get; set; }

        [Required(ErrorMessage = "Debes capturar el nombre del veterinario.")]
        [StringLength(30, ErrorMessage = "El nombre debe tener 30 letras.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debes capturar el apellido paterno del veterinario.")]
        [StringLength(30, ErrorMessage = "El apellido paterno debe tener 30 letras.")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Debes capturar el apellido materno del veterinario.")]
        [StringLength(30, ErrorMessage = "El apellido materno debe tener 30 letras.")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Debes capturar el nombre de la calle.")]
        [StringLength(60, ErrorMessage = "La calle debe tener 60 letras.")]
        public string Calle { get; set; }
        public Nullable<int> NumExt { get; set; }
        public string NumInt { get; set; }
        public int CodigoPostal { get; set; }
        public int IdLocalidad { get; set; }
        public string NSS { get; set; }

        [Required(ErrorMessage = "Debes capturar el CURP del veterinario.")]
        [StringLength(18, ErrorMessage = "El CURP debe tener 18 caracteres.")]
        public string CURP { get; set; }

        [Required(ErrorMessage = "Debes capturar el numero de telefono del veterinario.")]
        [StringLength(10, ErrorMessage = "El numero de telefono debe tener 10 numeros.")]
        public string Telefono { get; set; }
        public decimal SueldoXDia { get; set; }
        public int TarjetaCredito { get; set; }
        public Nullable<byte> IdTipoPer { get; set; }
        public Nullable<short> IdArea { get; set; }
    
        public virtual tbAreas tbAreas { get; set; }
        public virtual tbLocalidades tbLocalidades { get; set; }
        public virtual tbTipoPersonal tbTipoPersonal { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class reclamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reclamo()
        {
            this.historialDeCambios = new HashSet<historialDeCambios>();
        }
    
        public int numero { get; set; }
        public string estado { get; set; }
        public System.DateTime fechaIngreso { get; set; }
        public string observaciones { get; set; }
        public string comentario { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string emailUsuario { get; set; }
        public int numeroTipoReclamo { get; set; }
        public int numeroCuadrilla { get; set; }
        public int numeroZona { get; set; }
    
        public virtual cuadrilla cuadrilla { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historialDeCambios> historialDeCambios { get; set; }
        public virtual tipoReclamo tipoReclamo { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual zona zona { get; set; }
    }
}

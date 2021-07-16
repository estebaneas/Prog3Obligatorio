using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoHistorialCambios
    {
        public int numero { get; set; }
        [DisplayName("Numero de reclamo")]
        public int numeroReclamo { get; set; }
        [DisplayName("Nombre ")]
        public string nombreFunc { get; set; }
        [DisplayName("Apellido")]
        public string apellidoFunc { get; set; }
        [DisplayName("Fecha cambio")]
        public DateTime fechaCambio { get; set; }
        [DisplayName("Fecha ingreso")]
        public DateTime fechaIngreso { get; set; }
        [DisplayName("Observaciones")]
        public string observaciones { get; set; }
        [DisplayName("Comentario")]
        public string comentario { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }
        public DtoReclamo dtoReclamo { get; set; }

    }
}

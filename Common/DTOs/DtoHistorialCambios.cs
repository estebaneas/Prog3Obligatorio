using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoHistorialCambios
    {
        public int numero { get; set; }
        public int numeroReclamo { get; set; }
        public string nombreFunc { get; set; }
        public string apellidoFunc { get; set; }
        public DateTime fechaCambio { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string observaciones { get; set; }
        public string comentario { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string estado { get; set; }
        public DtoReclamo dtoReclamo { get; set; }

    }
}

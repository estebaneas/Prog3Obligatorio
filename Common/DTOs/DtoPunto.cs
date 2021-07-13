using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoPunto
    {
        public DtoPunto() { }
        public DtoPunto(decimal latitud, decimal longitud)
        {
            this.latitud = latitud;
            this.longitud = longitud;
        }
        public int numero;
        public int numeroZona;
        public decimal latitud;
        public decimal longitud;
       //si pasa algo es porque borre esto: public string colDtoPunto;
    }
}

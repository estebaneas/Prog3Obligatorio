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
        public DtoPunto(double latitud, double longitud)
        {
            this.latitud = latitud;
            this.longitud = longitud;
        }
        public int numero;
        public int numeroZona;
        public double latitud;
        public double longitud;
       //si pasa algo es porque borre esto: public string colDtoPunto;
    }
}

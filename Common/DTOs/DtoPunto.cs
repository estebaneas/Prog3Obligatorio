using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoPunto
    {
        public int numero;
        public int numeroZona;
        public decimal latitud;
        public decimal longitud;
        public DtoZona dtoZona;

        public int Numero { get => numero; set => numero = value; }
        public int NumeroZona { get => numeroZona; set => numeroZona = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public DtoZona DtoZona { get => dtoZona; set => dtoZona = value; }
    }
}

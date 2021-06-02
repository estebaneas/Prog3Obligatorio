using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoHistorialCambios
    {
        private int numero;
        private int numeroReclamo;
        private DateTime fecha;
        private string estado;
        private DtoReclamo dtoReclamo;

        public int Numero { get => numero; set => numero = value; }
        public int NumeroReclamo { get => numeroReclamo; set => numeroReclamo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
        public DtoReclamo DtoReclamo { get => dtoReclamo; set => dtoReclamo = value; }
    }
}

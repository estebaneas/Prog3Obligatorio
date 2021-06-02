using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoTipoReclamo
    {
        private int numero;
        private string nombre;
        private string descripcion;
        private List<DtoReclamo> colDtoReclamo;

        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public List<DtoReclamo> ColDtoReclamo { get => colDtoReclamo; set => colDtoReclamo = value; }
    }
}

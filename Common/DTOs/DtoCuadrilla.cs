using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoCuadrilla
    {
        public int numero;
        public string nombre;
        public string encargado;
        public int cantidadPeones;
        public List<DtoReclamo> colDtoReclamo;
        public List<DtoZona> colDtoZona;


        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Encargado { get => encargado; set => encargado = value; }
        public int CantidadPeones { get => cantidadPeones; set => cantidadPeones = value; }
        public List<DtoReclamo> ColDtoReclamo { get => colDtoReclamo; set => colDtoReclamo = value; }
        public List<DtoZona> ColDtoZona { get => colDtoZona; set => colDtoZona = value; }
    }
}

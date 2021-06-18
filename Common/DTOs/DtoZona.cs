using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoZona
    {
        public int numero;
        public string nombre;
        public string color;
        public List<DtoPunto> colDtoPunto;
        public List<DtoReclamo> colDtoReclamo;
        public List<DtoCuadrilla> colDtoCuadrilla;

        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Color { get => color; set => color = value; }
        public List<DtoPunto> ColDtoPunto { get => colDtoPunto; set => colDtoPunto = value; }
        public List<DtoReclamo> ColDtoReclamo { get => colDtoReclamo; set => colDtoReclamo = value; }
        public List<DtoCuadrilla> ColDtoCuadrilla { get => colDtoCuadrilla; set => colDtoCuadrilla = value; }
    }
}

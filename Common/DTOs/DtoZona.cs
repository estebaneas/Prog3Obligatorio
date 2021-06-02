using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoZona
    {
        private int numero;
        private string nombre;
        private string color;
        private List<DtoPunto> colDtoPunto;
        private List<DtoReclamo> colDtoReclamo;
        private List<DtoCuadrilla> colDtoCuadrilla;

        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Color { get => color; set => color = value; }
        public List<DtoPunto> ColDtoPunto { get => colDtoPunto; set => colDtoPunto = value; }
        public List<DtoReclamo> ColDtoReclamo { get => colDtoReclamo; set => colDtoReclamo = value; }
        public List<DtoCuadrilla> ColDtoCuadrilla { get => colDtoCuadrilla; set => colDtoCuadrilla = value; }
    }
}

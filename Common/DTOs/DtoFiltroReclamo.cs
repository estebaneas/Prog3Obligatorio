using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoFiltroReclamo
    {
        public List<DtoReclamo> colReclamos { get; set; }
        public string estado { get; set; }
        public int paginaActual { get; set; }
        public int? numZona { get; set; }
        public int? numCuadrilla { get; set; }
        public string targetID { get; set; }
        public DateTime? ini { get; set; }
        public int cantPorPag { get; set; }
        public string colRelJavVar { get; set; }
        public string BtnTarget { get; set; }
        public int? tipo { get; set; }

        // "colRecJava_" + item.numero;
    }
}

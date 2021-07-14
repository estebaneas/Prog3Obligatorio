using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.DTOs
{
    public class DtoZona
    {
        [Required(ErrorMessage = "• El {0} es requerido")]
        public int numero { get; set; }
        [Required(ErrorMessage = "• El {0} es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "• El {0} es requerido")]
        public string color { get; set; }

        [Required(ErrorMessage = "• No ha dibujado una zona")]
        [Remote("ValidarPoligono", "Zona")]
        public string Puntos { get; set; }

        public List<DtoReclamo> colReclamos { get; set; }
        public List<DtoPunto> colDtoPunto { get; set; }

    }
}

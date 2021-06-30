using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoZona
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        public int numero { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        public string color { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public string Puntos { get; set; }
        public List<DtoPunto> colDtoPunto { get; set; }

    }
}

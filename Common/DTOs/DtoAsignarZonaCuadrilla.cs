using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoAsignarZonaCuadrilla
    {

        public string nombreCuadrilla { get; set; }
        public int numCuadrilla { get; set; }
        [Required(ErrorMessage ="No se selecciono una zona")]
        
        public int numeroZona { get; set; }

        public string nombreZona { get; set; }
      

    }
}

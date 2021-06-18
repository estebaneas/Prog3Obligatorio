using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class DtoTipoReclamo
    {
        public int numero;
        public string nombre;
        public string descripcion;
        //public List<DtoReclamo> colDtoReclamo;

        [Required(ErrorMessage ="El {0} es requerido")]
        [StringLength(25,ErrorMessage ="El nombre no puede ser superar los {1} carácteres")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "la descripcion es requerida")]
        [StringLength(100, ErrorMessage = "La descripcion no puede superar los {1} carácteres")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        //public List<DtoReclamo> ColDtoReclamo { get => colDtoReclamo; set => colDtoReclamo = value; }
    }
}

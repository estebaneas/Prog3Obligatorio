using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoCuadrilla
    {
        public int numero;

        [DisplayName("Nombre: ")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25, ErrorMessage = "El nombre no puede superar los {1} caracteres")]
        public string nombre { get; set; }

        [DisplayName("Encargado: ")]
        [Required(ErrorMessage = "El encargado es requerido")]
        [StringLength(25, ErrorMessage = "El encargado no puede superar los {1} caracteres")]
        public string encargado { get; set; }

        [DisplayName("Cantidad de peones: ")]
        [Required(ErrorMessage = "La cantidad de peones es requerida")]
        public int cantidadPeones { get; set; }
        
        public List<DtoReclamo> colDtoReclamo;
        public List<DtoZona> colDtoZona;

        
    }
}

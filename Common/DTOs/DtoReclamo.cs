using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoReclamo
    {
        public int numero { get; set; }
        [DisplayName("Estado: ")]
        [Required(ErrorMessage ="El estado es requerido")]
        public string estado { get; set; }
        public DateTime fechaIngreso;

        [DisplayName("Observaciones: ")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100, ErrorMessage = "La descripción no debe superar los {1} caracteres")]
        public string observaciones { get; set; }
        public string comentario;

        [DisplayName("Latitud: ")]
        [Required(ErrorMessage = "La ubicación es requerida")]
        public decimal latitud { get; set; }

        [DisplayName("Longitud: ")]
        [Required(ErrorMessage = "La ubicación es requerida")]
        public decimal longitud { get; set; }

        [DisplayName("Tipo de reclamo: ")]
        [Required(ErrorMessage = "El tipo de reclamo es requerido")]

        public int numTipoReclamo { get; set; }


        public string emailUsuario { get; set; }
        public int numeroCuadrilla { get; set; }
        public int numeroZona { get; set; }
        public DtoCuadrilla dtoCuadrilla;
        public List<DtoHistorialCambios> colDtoHistorialCambios;
        public DtoUsuario dtoUsuario;
        public DtoZona dtoZona;
        
    }
}

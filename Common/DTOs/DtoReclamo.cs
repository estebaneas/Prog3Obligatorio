using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.DTOs
{
    public class DtoReclamo
    {
     
        [DisplayName("Número de reclamo: ")]
        public int numero { get; set; }
        [DisplayName("Estado: ")]
        [Required(ErrorMessage ="El estado es requerido")]
        public estadoReclamo estado { get; set; }
        public DateTime fechaIngreso { get; set; }
        [DisplayName("Observaciones: ")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100, ErrorMessage = "La descripción no debe superar los {1} caracteres")]
        public string observaciones { get; set; }
        public string comentario { get; set; }

        [Required]
        [Remote("ValidarPunto", "Reclamo", AdditionalFields = "longitud", ErrorMessage = "El punto seleccionado esta fuera de las zonas validas")]
        public double latitud { get; set; }
        [Required]
        public double longitud { get; set; }

        [DisplayName("Tipo de reclamo: ")]
        [Required(ErrorMessage = "El tipo de reclamo es requerido")]

        public int numTipoReclamo { get; set; }
        public string emailUsuario { get; set; }
        public int numeroCuadrilla { get; set; }
        public int numeroZona { get; set; }

        public string latString;
        public string lngString;
        public string fechaString;
        public DtoTipoReclamo tipoReclamo { get; set; }
        public DtoCuadrilla dtoCuadrilla;
        public List<DtoHistorialCambios> colDtoHistorialCambios;
        public DtoUsuario dtoUsuario;
        public DtoZona dtoZona;
    }
}

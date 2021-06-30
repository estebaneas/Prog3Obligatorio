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
        public int numero;
        public string estado;
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
       
        /*
        [DisplayName("Tipo de reclamo: ")]
        [Required(ErrorMessage = "El tipo de reclamo es requerido")]
        public DtoTipoReclamo dtoTipoReclamo { get; set; }
        */
        public decimal longitud { get; set; }
        public string emailUsuario;
        public int numTipoReclamo;
        public int numeroCuadrilla;
        public int numeroZona;
        public DtoCuadrilla dtoCuadrilla;
        public List<DtoHistorialCambios> colDtoHistorialCambios;
        public DtoUsuario dtoUsuario;
        public DtoZona dtoZona;
    }
}

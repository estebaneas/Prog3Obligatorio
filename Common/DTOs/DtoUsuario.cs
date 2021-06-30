using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoUsuario
    {
        [Required]
        [DisplayName("Email: ")]
        public string email { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string usario { get; set; }
        [Required]
        public string contrasena { get; set; }
        [Required]
        public string telefono { get; set; }

        public Nullable<bool> funcionario; 



        /*
       
        public List<DtoReclamo> colDtoReclamo;*/

    }
}

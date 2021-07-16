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
    public class DtoUsuario
    {
        [Remote("ValidarEmail", "Usuario", ErrorMessage = "Ya existe una cuenta asociada a este email")]
        [Required(ErrorMessage = "Ingrese una dirección email")]
        [DisplayName("Email: ")]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        [DisplayName("Nombre: ")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido")]
        [DisplayName("Apellido: ")]
        public string apellido { get; set; }

        [Remote("ValidarUsuario", "Usuario", ErrorMessage = "Este nombre de usuario ya está en uso")]
        [Required(ErrorMessage = "Ingrese un nombre de Usuario")]
        [DisplayName("Nombre de usuario: ")]
        public string usario { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [DisplayName("Contraseña: ")]
        public string contrasena { get; set; }
        [Required(ErrorMessage = "Ingrese un teléfono")]
        [DisplayName("Teléfono: ")]
        public string telefono { get; set; }

        public Nullable<bool> funcionario; 



        /*
       
        public List<DtoReclamo> colDtoReclamo;*/

    }
}

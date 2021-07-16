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
    public class DtoLogin
    {
        [Required(ErrorMessage = "Nombre de usuario requerido")]
        [DisplayName("Nombre de usuario: ") ]
        public string username { get; set; }
        [Required(ErrorMessage = "Contraseña requerida")]
        [DisplayName("Contraseña: ")]
        public string password { get; set; }
    }
}

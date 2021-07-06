using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoLogin
    {
        [Required]
        [DisplayName("Nombre de usuario: ") ]
        public string username { get; set; }
        [Required]
        [DisplayName("Contraseña: ")]
        public string password { get; set; }
    }
}

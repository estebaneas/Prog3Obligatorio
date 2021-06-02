using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoUsuario
    {
        private string email;
        private string nombre;
        private string apellido;
        private string usario;
        private string contraseña;
        private string telefono;
        private Nullable<bool> funcionario;
        private List<DtoReclamo> colDtoReclamo;

        public string Email { get => email; set => email = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Usario { get => usario; set => usario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool? Funcionario { get => funcionario; set => funcionario = value; }
        public List<DtoReclamo> ColDtoReclamo { get => colDtoReclamo; set => colDtoReclamo = value; }
    }
}

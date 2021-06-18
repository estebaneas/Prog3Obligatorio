using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoUsuario
    {
        public string email;
        public string nombre;
        public string apellido;
        public string usario;
        public string contraseña;
        public string telefono;
        public Nullable<bool> funcionario;
        public List<DtoReclamo> colDtoReclamo;

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

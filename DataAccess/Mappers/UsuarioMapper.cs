using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class UsuarioMapper
    {
        public DtoUsuario mapToDto(usuario _usuario)
        {
            DtoUsuario dto = new DtoUsuario();
            dto.Email = _usuario.email;
            dto.Nombre = _usuario.nombre;
            dto.Apellido = _usuario.apellido;
            dto.Usario = _usuario.nombreDeUsuario;
            dto.Contraseña = _usuario.contraseña;
            dto.Telefono = _usuario.telefono;
            dto.Funcionario = _usuario.funcionario;
            

            return dto;
        }

        public usuario mapToEntity(DtoUsuario dto)
        {
            usuario _usuario = new usuario();
            _usuario.email = dto.Email;
            _usuario.nombre = dto.Nombre;
            _usuario.apellido = dto.Apellido;
            _usuario.nombreDeUsuario = dto.Usario;
            _usuario.contraseña = dto.Contraseña;
            _usuario.telefono = dto.Telefono;
            _usuario.funcionario = dto.Funcionario;
           

            return _usuario;
        }
    }


}

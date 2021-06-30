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
            dto.email = _usuario.email;
            dto.nombre = _usuario.nombre;
            dto.apellido = _usuario.apellido;
            dto.usario = _usuario.nombreDeUsuario;
            dto.contrasena = _usuario.contraseña;
            dto.telefono = _usuario.telefono;
            dto.funcionario = _usuario.funcionario;
            return dto;
        }

        public usuario mapToEntity(DtoUsuario dto)
        {
            usuario _usuario = new usuario();
            _usuario.email = dto.email;
            _usuario.nombre = dto.nombre;
            _usuario.apellido = dto.apellido;
            _usuario.nombreDeUsuario = dto.usario;
            _usuario.contraseña = dto.contrasena;
            _usuario.telefono = dto.telefono;
            _usuario.funcionario = dto.funcionario;
           

            return _usuario;
        }
    }


}

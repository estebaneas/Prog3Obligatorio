using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class CuadrillaMapper
    {
        public DtoCuadrilla mapToDto(cuadrilla _cuadrilla)
        {
            DtoCuadrilla dto = new DtoCuadrilla();
            dto.Numero = _cuadrilla.numero;
            dto.Nombre = _cuadrilla.nombre;
            dto.Encargado = _cuadrilla.encargado;
            dto.CantidadPeones = _cuadrilla.cantidadPeones;
            
            return dto;
        }

        public cuadrilla mapToEntity(DtoCuadrilla dto)
        {
            cuadrilla _cuadrilla = new cuadrilla();
            _cuadrilla.numero = dto.Numero;
            _cuadrilla.nombre = dto.Nombre;
            _cuadrilla.encargado = dto.Encargado;
            _cuadrilla.cantidadPeones = dto.CantidadPeones;
            
            return _cuadrilla;
        }
    }
}

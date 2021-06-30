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
            dto.numero = _cuadrilla.numero;
            dto.nombre = _cuadrilla.nombre;
            dto.encargado = _cuadrilla.encargado;
            dto.cantidadPeones = _cuadrilla.cantidadPeones;
            
            return dto;
        }
        

        public cuadrilla mapToEntity(DtoCuadrilla dto)
        {
            cuadrilla _cuadrilla = new cuadrilla();
            _cuadrilla.numero = dto.numero;
            _cuadrilla.nombre = dto.nombre;
            _cuadrilla.encargado = dto.encargado;
            _cuadrilla.cantidadPeones = dto.cantidadPeones;
            
            return _cuadrilla;
        }

        public List<DtoCuadrilla> mapToDto(List<cuadrilla> colCuadrillas)
        {
            List<DtoCuadrilla> colDtoCuadrilla = new List<DtoCuadrilla>();
            foreach (cuadrilla item in colCuadrillas)
            {
                colDtoCuadrilla.Add(this.mapToDto(item));
            }

            return colDtoCuadrilla;
        }
    }
}

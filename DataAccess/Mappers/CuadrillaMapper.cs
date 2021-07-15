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
        private ZonaMapper zonamapper;
        private ReclamoMapper reclamoMapper;
       
        public CuadrillaMapper() {
            this.reclamoMapper = new ReclamoMapper();
            this.zonamapper = new ZonaMapper();
        }
        public DtoCuadrilla mapToDto(cuadrilla _cuadrilla)
        {
            DtoCuadrilla dto = new DtoCuadrilla();
            dto.numero = _cuadrilla.numero;
            dto.nombre = _cuadrilla.nombre;
            dto.encargado = _cuadrilla.encargado;
            dto.cantidadPeones = _cuadrilla.cantidadPeones;
            dto.colDtoReclamo = this.reclamoMapper.MapToDto(_cuadrilla.reclamo.ToList());
            //dto.colDtoZona = this.zonamapper.mapToDto(_cuadrilla.zona.ToList());
            
            return dto;
        }
        

        public cuadrilla mapToEntity(DtoCuadrilla dto)
        {
            cuadrilla _cuadrilla = new cuadrilla();
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

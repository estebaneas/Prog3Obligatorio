using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class ZonaMapper
    {
        private PuntoMapper _puntoMapper;
        private ReclamoMapper reclamoMapper;
        public ZonaMapper()
        {
            this._puntoMapper = new PuntoMapper();
            this.reclamoMapper = new ReclamoMapper();
        }
        public DtoZona mapToDto(zona _zona)
        {
            DtoZona dto = new DtoZona();
            dto.numero = _zona.numero;
            dto.nombre = _zona.nombre;
            dto.color = _zona.color;
            dto.colDtoPunto = _puntoMapper.mapToDto(_zona.punto.ToList());
            dto.colReclamos = reclamoMapper.MapToDto(_zona.reclamo.ToList());
            return dto;
        }

        public List<DtoZona> mapToDto(List<zona> _colZonas)
        {
            List<DtoZona> colDtoZonas = new List<DtoZona>();
            foreach(zona item in _colZonas)
            {
                colDtoZonas.Add(this.mapToDto(item));
            }

            return colDtoZonas;
        }



        public zona mapToEntity(DtoZona dto)
        {
            zona _zona = new zona();
           // _zona.numero = dto.numero;
            _zona.nombre = dto.nombre;
            _zona.color = dto.color;
            _zona.punto = this._puntoMapper.mapToEntity(dto.colDtoPunto);
            return _zona;
        }

        public List<zona> mapToEntity(List<DtoZona> colDto)
        {
            List<zona> colZonas = new List<zona>();
            foreach(DtoZona item in colDto)
            {
                colZonas.Add(this.mapToEntity(item));
            }
            return colZonas;
        }
    }
}

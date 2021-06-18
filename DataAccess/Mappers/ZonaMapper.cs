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
        public DtoZona mapToDto(zona _zona)
        {
            DtoZona dto = new DtoZona();
            dto.Numero = _zona.numero;
            dto.Nombre = _zona.nombre;
            dto.Color = _zona.color;
            

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
            _zona.numero = dto.Numero;
            _zona.nombre = dto.Nombre;
            _zona.color = dto.Color;
            return _zona;
        }
    }
}

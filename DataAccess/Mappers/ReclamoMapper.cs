using Common.DTOs;
using DataAccess.Model;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class ReclamoMapper
    {
        

        public DtoReclamo MapToDto(reclamo entity)
        {
            DtoReclamo dto = null;
            if (entity != null)
            {
                dto = new DtoReclamo();
               
                dto.observaciones = entity.observaciones;
                dto.latitud = entity.latitud;
                dto.longitud = entity.longitud;
                

            }
            return dto;
        }

        public reclamo mapToEntity(DtoReclamo dto)
        {
            reclamo _reclamo = new reclamo();
            
            _reclamo.observaciones = dto.observaciones;
            _reclamo.latitud = dto.latitud;
            _reclamo.longitud = dto.longitud;
           

            return _reclamo;
        }

        public List<DtoReclamo> MapToDto(List<reclamo> colEntity)
        {
            List<DtoReclamo> colDto = new List<DtoReclamo>();
            foreach (reclamo item in colEntity)
            {
                DtoReclamo dto = this.MapToDto(item);
                colDto.Add(dto);
            }

            return colDto;
        }
    }
}

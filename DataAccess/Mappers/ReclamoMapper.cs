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

        private TipoReclamoMapper tipoReclamoMapper;
        public ReclamoMapper()
        {
            this.tipoReclamoMapper = new TipoReclamoMapper();
        }
        public DtoReclamo MapToDto(reclamo entity)
        {
            DtoReclamo dto = null;
            if (entity != null)
            {
                dto = new DtoReclamo();
                dto.numero = entity.numero;
                dto.estado = (estadoReclamo)Enum.Parse(typeof(estadoReclamo), entity.estado);
                dto.fechaIngreso = entity.fechaIngreso;
                dto.observaciones = entity.observaciones;
                dto.comentario = entity.comentario;
                dto.latitud = entity.latitud;
                dto.longitud = entity.longitud;
                dto.emailUsuario = entity.emailUsuario;
                dto.numTipoReclamo = entity.numeroTipoReclamo;
                dto.numeroCuadrilla = entity.numeroCuadrilla;
                dto.numeroZona = entity.numeroZona;
                dto.tipoReclamo = this.tipoReclamoMapper.mapToDto(entity.tipoReclamo);
            }
            return dto;
        }

        public reclamo mapToEntity(DtoReclamo dto)
        {
            reclamo _reclamo = new reclamo();
            _reclamo.numero = dto.numero;
            _reclamo.estado = dto.estado.ToString();
            _reclamo.fechaIngreso = dto.fechaIngreso;
            _reclamo.observaciones = dto.observaciones;
            _reclamo.comentario = dto.comentario;
            _reclamo.latitud = dto.latitud;
            _reclamo.longitud = dto.longitud;
            _reclamo.emailUsuario = dto.emailUsuario;
            _reclamo.numeroTipoReclamo = dto.numTipoReclamo;
            _reclamo.numeroCuadrilla = dto.numeroCuadrilla;
            _reclamo.numeroZona = dto.numeroZona;
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

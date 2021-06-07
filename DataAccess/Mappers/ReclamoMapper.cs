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
        /*public DtoReclamo mapToDto(reclamo _reclamo)
        {
            DtoReclamo dto = new DtoReclamo();
            dto.Numero = _reclamo.numero;
            dto.Estado = _reclamo.estado;
            dto.FechaIngreso = _reclamo.fechaIngreso;
            dto.Observaciones = _reclamo.observaciones;
            dto.Latitud = _reclamo.latitud;
            dto.Longitud = _reclamo.longitud;
            dto.EmailUsuario = _reclamo.emailUsuario;
            dto.NumTipoReclamo = _reclamo.numeroTipoReclamo;
            dto.NumeroCuadrilla = _reclamo.numeroCuadrilla;
            dto.NumeroZona = _reclamo.numeroZona;

            

            return dto;
        }*/

        public DtoReclamo MapToDto(reclamo entity)
        {
            DtoReclamo dto = null;
            if (entity != null)
            {
                dto = new DtoReclamo();
                dto.Numero = entity.numero;
                dto.Estado = entity.estado;
                dto.FechaIngreso = entity.fechaIngreso;
                dto.Observaciones = entity.observaciones;
                dto.Latitud = entity.latitud;
                dto.Longitud = entity.longitud;
                dto.EmailUsuario = entity.emailUsuario;
                dto.NumTipoReclamo = entity.numeroTipoReclamo;
                dto.NumeroCuadrilla = entity.numeroCuadrilla;
                dto.NumeroZona = entity.numeroZona;

            }
            return dto;
        }

        public reclamo mapToEntity(DtoReclamo dto)
        {
            reclamo _reclamo = new reclamo();
            _reclamo.numero = dto.Numero;
            _reclamo.estado = dto.Estado;
            _reclamo.fechaIngreso = dto.FechaIngreso;
            _reclamo.observaciones = dto.Observaciones;
            _reclamo.latitud = dto.Latitud;
            _reclamo.longitud = dto.Longitud;
            _reclamo.emailUsuario = dto.EmailUsuario;
            _reclamo.numeroTipoReclamo = dto.NumTipoReclamo;
            _reclamo.numeroCuadrilla = dto.NumeroCuadrilla;
            _reclamo.numeroZona = dto.NumeroZona;

           

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

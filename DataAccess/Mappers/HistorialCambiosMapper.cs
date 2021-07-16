using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class HistorialCambiosMapper
    {
        public DtoHistorialCambios mapToDto(historialDeCambios _historialCambios)
        {
            DtoHistorialCambios dto = new DtoHistorialCambios();
            dto.numero = _historialCambios.numero;
            dto.numeroReclamo = _historialCambios.numeroReclamo;
            dto.nombreFunc = _historialCambios.nombreFunc;
            dto.apellidoFunc = _historialCambios.apellidoFunc;
            dto.fechaCambio = _historialCambios.fechaCambio;
            dto.fechaIngreso = _historialCambios.fechaIngreso;
            dto.latitud = _historialCambios.latitud;
            dto.longitud = _historialCambios.longitud;
            dto.observaciones = _historialCambios.observaciones;
            dto.comentario = _historialCambios.comentario;
            dto.estado = _historialCambios.estado;


            return dto;
        }

        public List<DtoHistorialCambios> mapToDto(List<historialDeCambios> colEntity)
        {
            List<DtoHistorialCambios> colDto = new List<DtoHistorialCambios>();
            foreach (historialDeCambios item in colEntity)
            {
                DtoHistorialCambios dto = this.mapToDto(item);
                colDto.Add(dto);
            }

            return colDto;
        }

        public historialDeCambios mapToEntity(DtoHistorialCambios dto)
        {
            historialDeCambios _historialCambios = new historialDeCambios();
            _historialCambios.numero = dto.numero;
            _historialCambios.numeroReclamo = dto.numeroReclamo;
            _historialCambios.nombreFunc = dto.nombreFunc;
            _historialCambios.apellidoFunc = dto.apellidoFunc;
            _historialCambios.fechaCambio = dto.fechaCambio;
            _historialCambios.fechaIngreso = dto.fechaIngreso;
            _historialCambios.latitud = dto.latitud;
            _historialCambios.longitud = dto.longitud;
            _historialCambios.observaciones = dto.observaciones;
            _historialCambios.comentario = dto.comentario;
            _historialCambios.estado = dto.estado;


            return _historialCambios;
        }

        public DtoHistorialCambios convertMap(DtoReclamo dto)
        {
            DtoHistorialCambios dtoHistorialCambios = new DtoHistorialCambios();
            dtoHistorialCambios.numeroReclamo = dto.numero;
            dtoHistorialCambios.fechaIngreso = dto.fechaIngreso;
            dtoHistorialCambios.latitud = dto.latitud;
            dtoHistorialCambios.longitud = dto.longitud;
            dtoHistorialCambios.observaciones = dto.observaciones;
            dtoHistorialCambios.comentario = dto.comentario;
            dtoHistorialCambios.estado = dto.estado.ToString();


            return dtoHistorialCambios;
        }
    }
}

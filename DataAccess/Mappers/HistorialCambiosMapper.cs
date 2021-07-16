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
            dto.fechaCambio = _historialCambios.fechaCambio;
            dto.fechaIngreso = _historialCambios.fechaIngreso;
            dto.latitud = _historialCambios.latitud;
            dto.longitud = _historialCambios.longitud;
            dto.observaciones = _historialCambios.observaciones;
            dto.comentario = _historialCambios.comentario;
            dto.estado = _historialCambios.estado;
            

            return dto;
        }

        public historialDeCambios mapToEntity(DtoHistorialCambios dto)
        {
            historialDeCambios _historialCambios = new historialDeCambios();
            _historialCambios.numero = dto.numero;
            _historialCambios.numeroReclamo = dto.numeroReclamo;
            _historialCambios.fechaCambio = dto.fechaCambio;
            _historialCambios.fechaIngreso = dto.fechaIngreso;
            _historialCambios.latitud = dto.latitud;
            _historialCambios.longitud = dto.longitud;
            _historialCambios.observaciones = dto.observaciones;
            _historialCambios.comentario = dto.comentario;
            _historialCambios.estado = dto.estado;


            return _historialCambios;
        }

        public historialDeCambios mapToEntity(DtoReclamo dto)
        {
            historialDeCambios _historialCambios = new historialDeCambios();
            _historialCambios.numeroReclamo = dto.numero;
            _historialCambios.fechaIngreso = dto.fechaIngreso;
            _historialCambios.latitud = dto.latitud;
            _historialCambios.longitud = dto.longitud;
            _historialCambios.observaciones = dto.observaciones;
            _historialCambios.comentario = dto.comentario;
            _historialCambios.estado = dto.estado.ToString();


            return _historialCambios;
        }
    }
}

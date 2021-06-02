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
            dto.Numero = _historialCambios.numero;
            dto.NumeroReclamo = _historialCambios.numeroReclamo;
            dto.FechaCambio = _historialCambios.fechaCambio;
            dto.FechaIngreso = _historialCambios.fechaIngreso;
            dto.Latitud = _historialCambios.latitud;
            dto.Longitud = _historialCambios.longitud;
            dto.Observaciones = _historialCambios.observaciones;
            dto.Comentario = _historialCambios.comentario;
            dto.Estado = _historialCambios.estado;
            

            return dto;
        }

        public historialDeCambios mapToEntity(DtoHistorialCambios dto)
        {
            historialDeCambios _historialCambios = new historialDeCambios();
            _historialCambios.numero = dto.Numero;
            _historialCambios.numeroReclamo = dto.NumeroReclamo;
            _historialCambios.fechaCambio = dto.FechaCambio;
            _historialCambios.fechaIngreso = dto.FechaIngreso;
            _historialCambios.latitud = dto.Latitud;
            _historialCambios.longitud = dto.Longitud;
            _historialCambios.observaciones = dto.Observaciones;
            _historialCambios.comentario = dto.Comentario;
            _historialCambios.estado = dto.Estado;


            return _historialCambios;
        }
    }
}

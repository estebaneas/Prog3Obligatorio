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
        public DtoHistorialCambios mapToDto(historialCambios _historialCambios)
        {
            DtoHistorialCambios dto = new DtoHistorialCambios();
            dto.Numero = _historialCambios.numero;
            dto.NumeroReclamo = _historialCambios.numeroReclamo;
            dto.Fecha = _historialCambios.fecha;
            dto.Estado = _historialCambios.estado;
            

            return dto;
        }

        public historialCambios mapToEntity(DtoHistorialCambios dto)
        {
            historialCambios _historialCambios = new historialCambios();
            _historialCambios.numero = dto.Numero;
            _historialCambios.numeroReclamo = dto.NumeroReclamo;
            _historialCambios.fecha = dto.Fecha;
            _historialCambios.estado = dto.Estado;
            

            return _historialCambios;
        }
    }
}

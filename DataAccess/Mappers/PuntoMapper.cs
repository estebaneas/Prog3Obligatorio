using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class PuntoMapper
    {
        public DtoPunto mapToDto(punto _punto)
        {
            DtoPunto dto = new DtoPunto();
            dto.numero = _punto.numero;
            dto.numeroZona = _punto.numeroZona;
            dto.latitud = _punto.latitud;
            dto.longitud = _punto.longitud;
            

            return dto;
        }
        public List<DtoPunto> mapToDto(List<punto> colPutnos)
        {
            List<DtoPunto> colDtoPuntos = new List<DtoPunto>();
            foreach(punto item in colPutnos)
            {
                colDtoPuntos.Add(this.mapToDto(item));
            }
            return colDtoPuntos;
        }

        public punto mapToEntity(DtoPunto dto)
        {
            punto _punto = new punto();
            _punto.numero = dto.numero;
            _punto.numeroZona = dto.numeroZona;
            _punto.latitud = dto.latitud;
            _punto.longitud = dto.longitud;

            

            return _punto;
        }
        public List<punto> mapToEntity(List<DtoPunto> colDto)
        {
            List<punto> colPunto = new List<punto>();
            foreach(DtoPunto item in colDto)
            {
                colPunto.Add(this.mapToEntity(item));
            }
            return colPunto;
        }
    }
}

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
            dto.Numero = _punto.numero;
            dto.NumeroZona = _punto.numeroZona;
            dto.Latitud = _punto.latitud;
            dto.Longitud = _punto.longitud;
            

            return dto;
        }

        public punto mapToEntity(DtoPunto dto)
        {
            punto _punto = new punto();
            _punto.numero = dto.Numero;
            _punto.numeroZona = dto.NumeroZona;
            _punto.latitud = dto.Latitud;
            _punto.longitud = dto.Longitud;

            return _punto;
        }

        public List<punto> mapToEntity(List<DtoPunto> dto)
        {
            List<punto> colPuntos = new List<punto>();
            foreach(DtoPunto item in dto)
            {
                colPuntos.Add(this.mapToEntity(item));
            }
            return colPuntos;
        }
    }
}

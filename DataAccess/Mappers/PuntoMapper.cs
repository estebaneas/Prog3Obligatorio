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
            _punto.numero = dto.Numero;
            _punto.numeroZona = dto.NumeroZona;
            _punto.latitud = dto.Latitud;
            _punto.longitud = dto.Longitud;
            

            return _punto;
        }
    }
}

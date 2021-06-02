using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class TipoReclamoMapper
    {
        public DtoTipoReclamo mapToDto(tipoReclamo _tipo)
        {
            DtoTipoReclamo dto = new DtoTipoReclamo();
            dto.Numero = _tipo.numero;
            dto.Nombre = _tipo.nombre;
            dto.Descripcion = _tipo.descripcion;
            

            return dto;
        }

        public tipoReclamo mapToEntity(DtoTipoReclamo dto)
        {
            tipoReclamo _tipo = new tipoReclamo();
            _tipo.numero = dto.Numero;
            _tipo.nombre = dto.Nombre;
            _tipo.descripcion = dto.Descripcion;
            

            return _tipo;
        }
    }
}

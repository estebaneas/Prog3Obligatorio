using System;
using DataAccess.Model;
using DataAccess.Mappers;
using DataAccess;
using Common.DTOs;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TipoReclamoRepository
    {
        TipoReclamoMapper _tipoReclamoMapper;
        public TipoReclamoRepository()
        {
            this._tipoReclamoMapper = new TipoReclamoMapper();
        }

        //Metodos
        //Alta Tipo Reclamo
        public void altaTipoDeReclamo(DtoTipoReclamo dtoTipoReclamo)
        {
            tipoReclamo newTipoReclamo = new tipoReclamo();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        newTipoReclamo = this._tipoReclamoMapper.mapToEntity(dtoTipoReclamo);
                        context.tipoReclamo.Add(newTipoReclamo);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        //Verificar existencia
        public bool existeTipoDeReclamo(int numeroTipoReclamo)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
               return context.tipoReclamo.AsNoTracking().Any(t => t.numero == numeroTipoReclamo);
            }
        }

        //Devolver un Tipo De Reclamo
        public DtoTipoReclamo GetTipoReclamo(int numeroTipoReclamo)
        {
            tipoReclamo getTipoReclamo = new tipoReclamo();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                getTipoReclamo = context.tipoReclamo.AsNoTracking().FirstOrDefault(t=>t.numero==numeroTipoReclamo);
            }
            return this._tipoReclamoMapper.mapToDto(getTipoReclamo);
        }

        //Devolver todos los tipos de reclamo
        public List<DtoTipoReclamo> getCollTipoDeReclamo()
        {
            List<DtoTipoReclamo> colDtoTiposReclamo = new List<DtoTipoReclamo>();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                colDtoTiposReclamo = this._tipoReclamoMapper.mapToDto(context.tipoReclamo.AsNoTracking().ToList());
            }
            return colDtoTiposReclamo;
        }
        //Modificar Tipo de reclamo
        public void modificarTipoDeReclamo(DtoTipoReclamo dtoTipoReclamo)
        {
            tipoReclamo modTipoReclamo = new tipoReclamo();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        modTipoReclamo = context.tipoReclamo.FirstOrDefault(t=>t.numero==dtoTipoReclamo.Numero);
                        modTipoReclamo.nombre = dtoTipoReclamo.Nombre;
                        modTipoReclamo.descripcion = dtoTipoReclamo.Descripcion;
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        //Baja de tipo pendiente por dudas
    }
}

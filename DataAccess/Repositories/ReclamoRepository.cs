using Common.DTOs;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReclamoRepository
    {
        private ReclamoMapper reclamoMapper;
        public ReclamoRepository()
        {
            this.reclamoMapper = new ReclamoMapper();
        }
        public void AgregarReclamo(DtoReclamo dto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        reclamo reclamoEntity = this.reclamoMapper.mapToEntity(dto);
                        context.reclamo.Add(reclamoEntity);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public bool existeReclamo(int numReclamo)
        {
            bool result = false;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                result = context.reclamo.Any(a => a.numero == numReclamo);
            }

            return result;
        }

        public void modificarReclamo(DtoReclamo reclamo)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        reclamo currReclamoEntity = context.reclamo.FirstOrDefault(f => f.numero == reclamo.numero);

                        
                        currReclamoEntity.observaciones = reclamo.observaciones;
                        currReclamoEntity.latitud = reclamo.latitud;
                        currReclamoEntity.longitud = reclamo.longitud;

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public void BorrarReclamo(int numero)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        reclamo currReclamo = context.reclamo.FirstOrDefault(f => f.numero == numero);

                        if (currReclamo != null)
                        {
                            context.reclamo.Remove(currReclamo);
                            context.SaveChanges();
                            trann.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }

        }

        public List<DtoReclamo> ReclamosOrdenCronologico()
        {
            List<DtoReclamo> colDtoReclamos = null;

            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                List<reclamo> colReclamos = context.reclamo.AsNoTracking().OrderByDescending(w => w.fechaIngreso).ToList();
                colDtoReclamos = this.reclamoMapper.MapToDto(colReclamos);
            }

            return colDtoReclamos;
        }
    }
}

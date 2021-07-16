using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
using DataAccess.Mappers;
using DataAccess.Model;
using System.Data;
using System.Data.Entity;


namespace DataAccess.Repositories
{
    public class PuntoRepository
    {
        public PuntoMapper _PuntoMapper;
        public PuntoRepository()
        {
            this._PuntoMapper = new PuntoMapper();
        }

        public void AltaPunto(DtoPunto dtoPunto)
        {
            punto nuevoPunto = new punto();
            int numPunto;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                numPunto = context.punto.Count(p => p.numeroZona == dtoPunto.numeroZona)+1;
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        nuevoPunto = this._PuntoMapper.mapToEntity(dtoPunto);
                        nuevoPunto.numero = numPunto;
                        context.punto.Add(nuevoPunto);
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

        public void BajaPunto(DtoPunto dtoPunto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {

                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.punto.Remove(this._PuntoMapper.mapToEntity(dtoPunto));
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

        public bool ExistePunto(DtoPunto dtoPunto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return context.punto.AsNoTracking().Any(p=>p.numero==dtoPunto.numero&&p.numeroZona==dtoPunto.numeroZona);
            }
        }


        public List<DtoPunto> ListarPuntos()
        {
            List<DtoPunto> colPuntos = new List<DtoPunto>();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return this._PuntoMapper.mapToDto(context.punto.AsNoTracking().ToList());
            }
        }

        public bool hayPuntos()
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return context.punto.AsNoTracking().GroupBy(p=>p.numeroZona).Any(p=>p.Count()>=3);
            }
        }
    }
}

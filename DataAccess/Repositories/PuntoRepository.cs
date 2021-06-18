using System;
using DataAccess.Model;
using DataAccess.Mappers;
using Common.DTOs;
using System.Data.Entity;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PuntoRepository
    {
        private PuntoMapper _puntoMapper;
        public PuntoRepository()
        {
            this._puntoMapper = new PuntoMapper();
        }

        public void altaPunto(DtoPunto dtoPunto)
        {
            punto nPunto = new punto();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    context.punto.Add(this._puntoMapper.mapToEntity(dtoPunto));
                }
            }
        }

        public bool existePunto(DtoPunto dtoPunto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return context.punto.AsNoTracking().Any(p => p.numero == dtoPunto.numero&&p.numeroZona==dtoPunto.numeroZona);
            }
        }


        public void bajaPunto(DtoPunto dtoPunto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    context.punto.Remove(this._puntoMapper.mapToEntity(dtoPunto));
                }
            }
        }



        //funcion de prueba
        public void altaPuntos(List<DtoPunto> colDtoPuntos)
        {
            List<punto> colPuntos = new List<punto>();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    context.punto.AddRange(this._puntoMapper.mapToEntity(colDtoPuntos));
                }
            }
        }



    }
}

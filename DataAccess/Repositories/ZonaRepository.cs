using System;
using DataAccess.Model;
using DataAccess.Mappers;
using Common.DTOs;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ZonaRepository
    {
        private ZonaMapper _zonaMapper;
        public ZonaRepository()
        {
            this._zonaMapper = new ZonaMapper();
        }

        public void altaZona(DtoZona dtoZona)
        {
            zona nZona = new zona();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.zona.Add(this._zonaMapper.mapToEntity(dtoZona));
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

        public void bajaZona(int numeroZona)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        zona zonaEnt = new zona();
                        zonaEnt = context.zona.FirstOrDefault(z => z.numero == numeroZona);
                        context.zona.Remove(zonaEnt);
                        context.SaveChanges();
                        trans.Commit();

                        //context.zona.Remove(context.zona.FirstOrDefault(z => z.numero == numeroZona));
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        public void modificarZona(DtoZona dtoZona)
        {
            zona modZona = new zona();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        modZona = context.zona.FirstOrDefault(z => z.numero == dtoZona.Numero);
                        modZona.color = dtoZona.Color;
                        modZona.nombre = dtoZona.Nombre;
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

        public DtoZona darZona(int numeroZona)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return this._zonaMapper.mapToDto(context.zona.AsNoTracking().FirstOrDefault(Z => Z.numero == numeroZona));
            }
        }

        public List<DtoZona> listarZonas()
        {
            List<DtoZona> colDtoZona = new List<DtoZona>();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return this._zonaMapper.mapToDto(context.zona.AsNoTracking().ToList());
            }
        }

        public bool existeZona(int numeroZona)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return context.zona.AsNoTracking().Any(z => z.numero == numeroZona);
            }
        }
    }
}

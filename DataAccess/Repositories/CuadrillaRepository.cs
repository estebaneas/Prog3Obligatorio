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
    public class CuadrillaRepository
    {
        private CuadrillaMapper cuadrillaMapper;
        public CuadrillaRepository()
        {
            this.cuadrillaMapper = new CuadrillaMapper();
        }

        //Alta de cuadrilla
        public void AgregarCuadrilla(DtoCuadrilla dto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        cuadrilla cuadrillaEntity = this.cuadrillaMapper.mapToEntity(dto);
                        context.cuadrilla.Add(cuadrillaEntity);
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

        // Existe cuadrilla
        public bool existeCuadrilla(int numCuadrilla)
        {
            bool result = false;

            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                result = context.cuadrilla.Any(a => a.numero == numCuadrilla);
            }

            return result;
        }

        // Modificacion de cuadrilla
        public void modificarCuadrilla(DtoCuadrilla cuadrilla)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        cuadrilla currCuadrillaEntity = context.cuadrilla.FirstOrDefault(f => f.numero == cuadrilla.numero);

                        currCuadrillaEntity.nombre = cuadrilla.nombre;
                        currCuadrillaEntity.encargado = cuadrilla.encargado;
                        currCuadrillaEntity.cantidadPeones = cuadrilla.cantidadPeones;

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

        //Borrado de cuadrilla
        public void BorrarCuadrilla(int numero)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        cuadrilla currCuadrilla = context.cuadrilla.FirstOrDefault(f => f.numero == numero);

                        if (currCuadrilla != null)
                        {
                            context.cuadrilla.Remove(currCuadrilla);
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

        //Listar cuadrilla
        public List<DtoCuadrilla> getColCuadrilla()
        {
            List<DtoCuadrilla> colCuadrilla = new List<DtoCuadrilla>();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return this.cuadrillaMapper.mapToDto(context.cuadrilla.AsNoTracking().ToList());
            }
            
        }

        public List<DtoCuadrilla> getCuadrillaPorZona(int numZona)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return this.cuadrillaMapper.mapToDto(context.zona.FirstOrDefault(s => s.numero == numZona).cuadrilla.ToList());
            }
        }

        public DtoCuadrilla getCuadrilla(int numCuadrilla)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                return this.cuadrillaMapper.mapToDto(context.cuadrilla.AsNoTracking().FirstOrDefault(c => c.numero == numCuadrilla));
            }
        }

        public void asignarCuadrillaZona(DtoAsignarZonaCuadrilla asignacion)
        {
            using (ControlDeReclamosEntities context= new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        cuadrilla cuadrilla = context.cuadrilla.FirstOrDefault(c => c.numero == asignacion.numCuadrilla);
                        zona zona = context.zona.FirstOrDefault(z => z.numero == asignacion.numeroZona);
                        zona.cuadrilla.Add(cuadrilla);
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
       
    }
}

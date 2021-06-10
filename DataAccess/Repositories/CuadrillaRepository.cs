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
                        cuadrilla currCuadrillaEntity = context.cuadrilla.FirstOrDefault(f => f.numero == cuadrilla.Numero);

                        currCuadrillaEntity.nombre = cuadrilla.Nombre;
                        currCuadrillaEntity.encargado = cuadrilla.Encargado;
                        currCuadrillaEntity.cantidadPeones = cuadrilla.CantidadPeones;

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

       
    }
}

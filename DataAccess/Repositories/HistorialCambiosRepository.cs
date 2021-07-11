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
    public class HistorialCambiosRepository
    {
        public HistorialCambiosRepository()
        {

        }

        private HistorialCambiosMapper cambiosMapper;
        private ReclamoMapper reclamoMapper;

        public void AltaCambiosHistorial(DtoHistorialCambios dto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        historialDeCambios historialEntity = this.cambiosMapper.mapToEntity(dto);
                        context.historialDeCambios.Add(historialEntity);
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

        public void BajaCambiosHistorial(int _numero)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        historialDeCambios currHistorial = context.historialDeCambios.FirstOrDefault(f => f.numero == _numero);

                        if (currHistorial != null)
                        {
                            context.historialDeCambios.Remove(currHistorial);
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

        public void ModificarCambiosHistorial(DtoHistorialCambios dto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        historialDeCambios currHistorial = context.historialDeCambios.FirstOrDefault(f => f.numero == dto.numero);

                        if (currHistorial != null)
                        {
                            currHistorial.numero = dto.numero;
                            currHistorial.numeroReclamo = dto.numeroReclamo;
                            currHistorial.fechaCambio = dto.fechaCambio;
                            currHistorial.fechaIngreso = dto.fechaIngreso;
                            currHistorial.observaciones = dto.observaciones;
                            currHistorial.comentario = dto.comentario;
                            currHistorial.latitud = dto.latitud;
                            currHistorial.longitud = dto.longitud;
                            currHistorial.estado = dto.estado;
                            currHistorial.reclamo = this.reclamoMapper.mapToEntity(dto.dtoReclamo);

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

        public DtoHistorialCambios LeerHistorialCambios(int _numero)
        {
            DtoHistorialCambios dto = new DtoHistorialCambios();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                historialDeCambios _historialCambios = context.historialDeCambios.AsNoTracking().FirstOrDefault(w => w.numero == _numero);
                dto = this.cambiosMapper.mapToDto(_historialCambios);
            }
            return dto;
        }

        public bool ExisteCambio(int _numero)
        {
            bool existe = false;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                existe = context.historialDeCambios.AsNoTracking().Any(i => i.numero == _numero);
            }
            return existe;
        }
    }
}

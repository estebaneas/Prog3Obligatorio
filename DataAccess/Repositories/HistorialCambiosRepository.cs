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
                        historialDeCambios currHistorial = context.historialDeCambios.FirstOrDefault(f => f.numero == dto.Numero);

                        if (currHistorial != null)
                        {
                            currHistorial.numero = dto.Numero;
                            currHistorial.numeroReclamo = dto.NumeroReclamo;
                            currHistorial.fechaCambio = dto.FechaCambio;
                            currHistorial.fechaIngreso = dto.FechaIngreso;
                            currHistorial.observaciones = dto.Observaciones;
                            currHistorial.comentario = dto.Comentario;
                            currHistorial.latitud = dto.Latitud;
                            currHistorial.longitud = dto.Longitud;
                            currHistorial.estado = dto.Estado;
                            currHistorial.reclamo = this.reclamoMapper.mapToEntity(dto.DtoReclamo);

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

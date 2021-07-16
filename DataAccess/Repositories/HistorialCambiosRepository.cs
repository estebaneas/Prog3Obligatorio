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
        private HistorialCambiosMapper cambiosMapper;
        private ReclamoMapper reclamoMapper;

        public HistorialCambiosRepository()
        {
            this.cambiosMapper = new HistorialCambiosMapper();
            this.reclamoMapper = new ReclamoMapper();
        }

        public void AltaCambiosHistorial(DtoHistorialCambios dtoHistorial)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        historialDeCambios historialEntity = this.cambiosMapper.mapToEntity(dtoHistorial);
                        historialEntity.fechaCambio = DateTime.Now;
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

        public List<DtoHistorialCambios> LeerHistorialCambios(int _numero)
        {
            List<DtoHistorialCambios> colDto = new List<DtoHistorialCambios>();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                List<historialDeCambios> colHistorialCambios = context.historialDeCambios.AsNoTracking().Where(w => w.numeroReclamo == _numero).ToList();
                colDto = this.cambiosMapper.mapToDto(colHistorialCambios);
            }
            return colDto;
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

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
    public class UsuarioRepository
    {
        private UsuarioMapper usuarioMapper;

        public UsuarioRepository()
        {
            this.usuarioMapper = new UsuarioMapper();
        }

        public void AltaUsuario(DtoUsuario dto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        usuario usuarioEntity = this.usuarioMapper.mapToEntity(dto);
                        context.usuario.Add(usuarioEntity);
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

        public void BajaUsuario(string email)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        usuario currUsuario = context.usuario.FirstOrDefault(f => f.email == email);

                        if (currUsuario != null)
                        {
                            context.usuario.Remove(currUsuario);
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

        public bool ExisteEmail(string email)
        {
            bool existe = false;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                existe = context.usuario.Any(i => i.email == email);
            }
            return existe;
        }

        public void ModificarUsuario(DtoUsuario dto)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        usuario currUsuario = context.usuario.FirstOrDefault(f => f.email == dto.email);

                        if (currUsuario != null)
                        {
                            currUsuario.nombre = dto.nombre;
                            currUsuario.apellido = dto.apellido;
                            currUsuario.nombreDeUsuario = dto.usario;
                            currUsuario.contraseña = dto.contrasena;
                            currUsuario.telefono = dto.telefono;
                            currUsuario.funcionario = dto.funcionario;

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

        public DtoUsuario LeerUsuario(string username)
        {
            DtoUsuario dto = new DtoUsuario();
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                usuario _usuario = context.usuario.FirstOrDefault(w => w.nombreDeUsuario == username);
                dto = this.usuarioMapper.mapToDto(_usuario);
            }
            return dto;
        }

        public bool ExisteUsuario(string email)
        {
            bool existe = false;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                existe = context.usuario.AsNoTracking().Any(i => i.email == email);
            }
            return existe;
        }

        public bool ExisteNombreUsuario(string usario)
        {
            bool existe = false;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                existe = context.usuario.Any(i => i.nombreDeUsuario == usario);
            }
            return existe;
        }

        public bool VerificarUsuarioPassword(string nombreUsuario, string password)
        {
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {

                return context.usuario.AsNoTracking().Any(i => i.nombreDeUsuario == nombreUsuario && i.contraseña == password);
            }

        }

        public bool? EsFuncionario(string nombreUsuario)
        {
            bool? funcionario;
            using (ControlDeReclamosEntities context = new ControlDeReclamosEntities())
            {
                usuario currUsuario = context.usuario.FirstOrDefault(i => i.nombreDeUsuario == nombreUsuario);
                funcionario = currUsuario.funcionario;
            }
            return funcionario;
        }

        public string getEmail(string username)
        {
            DtoUsuario dto = this.LeerUsuario(username);
            string email = dto.email;
            return email;
        }
    }
}


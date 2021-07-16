using Common.DTOs;
using DataAccess.Model;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class BLUsuarioController
    {
        private Repository repository;

        public BLUsuarioController()
        {
            this.repository = new Repository();
        }

        public List<string> altaUsuario(DtoUsuario dto)
        {
            List<string> colErrores = this.ValidarUsuario(dto, false);

            if (colErrores.Count == 0)
            {
                this.repository.GetUsuarioRepository().AltaUsuario(dto);
            }

            return colErrores;
        }

        public List<string> bajaUsuario(string email)
        {
            List<string> colErrores = this.ValidarBorrado(email);

            if (colErrores.Count == 0)
            {
                this.repository.GetUsuarioRepository().BajaUsuario(email);
            }

            return colErrores;
        }

        public bool ExisteNombreUsuario(string usario)
        {
            return this.repository.GetUsuarioRepository().ExisteNombreUsuario(usario);
        }

        public List<string> ValidarUsuario(DtoUsuario dto, bool esModificacion)
        {
            List<string> errores = new List<string>();

            if (esModificacion && !this.repository.GetUsuarioRepository().ExisteUsuario(dto.email))
            {
                errores.Add("El usuario no existe");
            }

            return errores;
        }

        public bool ExisteEmail(string email)
        {
            return this.repository.GetUsuarioRepository().ExisteEmail(email);
        }

        public List<string> ValidarBorrado(string email)
        {
            List<string> colErrores = new List<string>();

            if (!this.repository.GetUsuarioRepository().ExisteUsuario(email))
            {
                colErrores.Add("El cliente no existe");
            }

            return colErrores;
        }

        public bool VerificarUsuarioPassword(string _nombreUsuario, string password)
        {
            return this.repository.GetUsuarioRepository().VerificarUsuarioPassword(_nombreUsuario, password);
        }

        public bool EsFuncionario(string nombreUsuario)
        {
            if(this.repository.GetUsuarioRepository().EsFuncionario(nombreUsuario) == null)
            {
                return false;
            }
            else
            {
                return bool.Parse(this.repository.GetUsuarioRepository().EsFuncionario(nombreUsuario).ToString());
            }
            
        }
    }
}


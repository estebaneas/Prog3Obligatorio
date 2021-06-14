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
    public class UsuarioController
    {
        private Repository repository;

        public UsuarioController()
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

        public List<string> ValidarUsuario(DtoUsuario dto, bool esModificacion)
        {
            List<string> errores = new List<string>();

            if (!this.repository.GetUsuarioRepository().ExisteUsuario(dto.Email))
            {
                errores.Add("El usuario no existe");
            }

            return errores;
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
    }
}


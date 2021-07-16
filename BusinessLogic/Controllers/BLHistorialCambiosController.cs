using Common.DTOs;
using DataAccess.Mappers;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class BLHistorialCambiosController
    {
        private Repository repository;
        public HistorialCambiosMapper _historialMap;

        public BLHistorialCambiosController()
        {
            this.repository = new Repository();
            this._historialMap = new HistorialCambiosMapper();
        }

        public void altaHistorialCambios(int nroReclamo, string username)
        {
            DtoReclamo dtoReclamo = this.repository.GetReclamoRepository().getReclamo(nroReclamo);
            DtoHistorialCambios dto = this._historialMap.convertMap(dtoReclamo);
            DtoUsuario usuario = this.repository.GetUsuarioRepository().LeerUsuario(username);
            dto.nombreFunc = usuario.nombre;
            dto.apellidoFunc = usuario.apellido;
            this.repository.GetCambiosRepository().AltaCambiosHistorial(dto);
        }

        public List<string> bajaHistorialCambios(int _numero)
        {
            List<string> colErrores = this.ValidarBorrado(_numero);

            if (colErrores.Count == 0)
            {
                this.repository.GetCambiosRepository().BajaCambiosHistorial(_numero);
            }

            return colErrores;
        }

        public List<string> ValidarHistorialCambios(DtoHistorialCambios dto, bool esModificacion)
        {
            List<string> errores = new List<string>();

            if (!this.repository.GetCambiosRepository().ExisteCambio(dto.numero))
            {
                errores.Add("El historial de cambios que busca no existe");
            }

            return errores;
        }

        public List<string> ValidarBorrado(int _numero)
        {
            List<string> colErrores = new List<string>();

            if (!this.repository.GetCambiosRepository().ExisteCambio(_numero))
            {
                colErrores.Add("El cliente no existe");
            }

            return colErrores;
        }

        public List<DtoHistorialCambios> ListarCambios(int nroReclamo)
        {
            List<DtoHistorialCambios> dtoCambios = this.repository.GetCambiosRepository().LeerHistorialCambios(nroReclamo);
            return dtoCambios;
        }
    }
}

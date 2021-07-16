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
    public class BLReclamoController
    {
        private Repository _Repository;

        public BLReclamoController()
        {
            this._Repository = new Repository();
        }


        public DtoReclamo GetById(int nroReclamo)
        {

            return this._Repository.GetReclamoRepository().getReclamo(nroReclamo);

        }

        public List<string> agregarReclamo(DtoReclamo dto)
        {
            List<string> colErrores = this.ValidarReclamo(dto, false);

            if (colErrores.Count == 0)
            {
                this._Repository.GetReclamoRepository().AgregarReclamo(dto);
            }
            return colErrores;
        }

        public List<string> ValidarReclamo(DtoReclamo dto, bool modificable)
        {
            List<string> errores = new List<string>();


            if (dto.observaciones == null)
            {
                errores.Add("Las observaciones son requeridas");
            }
            else
            {
                if (dto.observaciones.Length > 150)
                {
                    errores.Add("La descripcion no debe superar los 150 caracteres");
                }

            }
           /* if (dto.DtoTipoReclamo == null)
            {
                errores.Add("El tipo de reclamo es requerido");
            }*/

            
            if (dto.latitud == null && dto.longitud == null)
            {
                errores.Add("La ubicación es requerida");
            }

            if (modificable == true)
            {
                if (!this.ExisteReclamo(dto.numero))
                {
                    errores.Add("El número de reclamo no existe");
                }
            }

            return errores;
        }

        public bool ExisteReclamo(int numReclamo)
        {
            return this._Repository.GetReclamoRepository().existeReclamo(numReclamo);
        }

        public List<string> modificarReclamo(DtoReclamo dto, string username)
        {
            List<string> colErrores = this.ValidarReclamo(dto, true);

            if (colErrores.Count == 0)
            {
                this._Repository.GetReclamoRepository().modificarReclamo(dto);

                BLHistorialCambiosController cambiosController = new BLHistorialCambiosController();
                cambiosController.altaHistorialCambios(dto.numero, username);
            }


            return colErrores;
        }

        public List<string> BorrarReclamo(int numero)
        {
            List<string> colErrores = this.ValidarBorrado(numero);

            if (colErrores.Count == 0)
            {
                this._Repository.GetReclamoRepository().BorrarReclamo(numero);
            }

            return colErrores;
        }

        public List<string> ValidarBorrado(int numero)
        {
            List<string> colErrores = new List<string>();

            if (!this._Repository.GetReclamoRepository().existeReclamo(numero))
            {
                colErrores.Add("El reclamo no existe");
            }

            return colErrores;
        }

        public List<DtoReclamo> reclamosCronologicamente()
        {
            return this._Repository.GetReclamoRepository().ReclamosOrdenCronologico();
        }

        public List<DtoReclamo> reclamosByUsuario(string username)
        {
            List<DtoReclamo> dtoReclamos = this.reclamosCronologicamente();
            List<DtoReclamo> dtoReclamosFiltrados = new List<DtoReclamo>();
            string _email = this._Repository.GetUsuarioRepository().getEmail(username);

            foreach (DtoReclamo item in dtoReclamos)
            {
                if(item.emailUsuario == _email)
                {
                    dtoReclamosFiltrados.Add(item);
                }
            }

            return dtoReclamosFiltrados;
        }


        public List<DtoReclamo> reclamosSinTerminar()
        {
            return this._Repository.GetReclamoRepository().recEnProcesoAsign();
        }


        public List<DtoReclamo> getReclamos(int? numZona, int? numCuadrilla, string estado, DateTime? ini, DateTime? fin)
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();

            if (numCuadrilla != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorCuadrilla(numCuadrilla);
            }
            else if (numZona != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorZona(numZona);
            }
            else if (estado != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorEstado(estado);
            }
            else if (ini != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorFecha(ini);
            }
            else if (ini != null && fin != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosEntreFechas(ini, fin);
            }
            else
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamos();
            }
            return colReclamos;
        }

        public long totPorZona(int numZona)
        {
            return this._Repository.GetReclamoRepository().getTotalReclamosPorZona(numZona);
        }
    }
}

using Common.DTOs;
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

        public List<string> modificarReclamo(DtoReclamo dto)
        {
            List<string> colErrores = this.ValidarReclamo(dto, true);

            if (colErrores.Count == 0)
            {
                this._Repository.GetReclamoRepository().modificarReclamo(dto);
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


        public List<DtoReclamo> reclamosSinTerminar()
        {
            return this._Repository.GetReclamoRepository().recEnProcesoAsign();
        }


        public List<DtoReclamo> getReclamos(int? numZona,int? numCuadrilla,string estado,DateTime? ini,DateTime? fin)
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
         
            if (numCuadrilla!=null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorCuadrilla(numCuadrilla);
            }
            else if(numZona!=null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorZona(numZona);
            }
            else if (estado != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorEstado(estado);
            }
            else if(ini!=null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorFecha(ini,DateTime.Now);
            }
            else if (fin != null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorFecha(DateTime.MinValue, fin);
            }
            else if(ini!=null&&fin!=null)
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamosPorFecha(ini, fin);
            }
            else
            {
                colReclamos = this._Repository.GetReclamoRepository().getReclamos();
            }
            return colReclamos;
        }
    }
}

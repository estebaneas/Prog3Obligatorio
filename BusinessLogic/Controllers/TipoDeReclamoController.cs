using BusinessLogic;
using Common.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class TipoDeReclamoController
    {
        private Repository _Repository;
        public TipoDeReclamoController()
        {
            this._Repository = new Repository();
        }

        //Agregar Tipo de reclamo
        public List<string> agregarTipoReclamo(DtoTipoReclamo dtoTipoReclamo)
        {
            List<string> colErrores = this.validarTipoDeReclamo(dtoTipoReclamo, false);
            if(colErrores.Count==0)
            {
                this._Repository.GetTipoReclamoRepository().altaTipoDeReclamo(dtoTipoReclamo);
            }
            return colErrores;
        }

        //Modificar Tipo de reclamo
        public List<string> modificarTipoReclamo(DtoTipoReclamo dtoTipoReclamo)
        {
            List<string> colErrores = this.validarTipoDeReclamo(dtoTipoReclamo,true);
            if(colErrores.Count==0)
            {
                this._Repository.GetTipoReclamoRepository().modificarTipoDeReclamo(dtoTipoReclamo);
            }
            return colErrores;
        }

        //Listar tipos de reclamos
        public List<DtoTipoReclamo> getTiposDeReclamos()
        {
            return this._Repository.GetTipoReclamoRepository().getCollTipoDeReclamo();
        }

        //borrar tipo de reclamo queda pendiente por duda

        //Validar tipo de reclamo
        public List<string> validarTipoDeReclamo(DtoTipoReclamo dtoTipoReclamo,bool modificacion)
        {
            List<string> colErrores = new List<string>();
            if(modificacion)
            {
                if (!this._Repository.GetTipoReclamoRepository().existeTipoDeReclamo(dtoTipoReclamo.Numero))
                {
                    colErrores.Add("El tipo de reclamo que esta intentando midifcar no existe o dejo de existir y no se encuentra en la base de datos");
                }
            }
            if(dtoTipoReclamo.Descripcion==null)
            {
                colErrores.Add("La descripcion del tipo de Reclamo no puede estar vacio");
            }
            if(dtoTipoReclamo.Nombre==null)
            {
                colErrores.Add("El nombre del tipo de Reclamo no puede estar vacio");
            }
            return colErrores;
        }
    }
}

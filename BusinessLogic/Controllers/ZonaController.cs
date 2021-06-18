using DataAccess.Persistence;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    class ZonaController
    {
        private Repository _Repository;

        public ZonaController()
        {
            this._Repository = new Repository();
        }

        public List<string> agregarZona(DtoZona nDtoZona)
        {
            List<string> colErrores = validarZona(nDtoZona,false);
            if (colErrores.Count() == 0)
            {
                this._Repository.GetZonaRepository().altaZona(nDtoZona);
            }
            return colErrores;
        }

        public List<string> eliminarZona (int numeroZona)
        {
            List<string> colErrores = new List<string>();
            if(colErrores.Count()==0&&this._Repository.GetZonaRepository().existeZona(numeroZona))
            {
                this._Repository.GetZonaRepository().bajaZona(numeroZona);
            }
            else
            {
                colErrores.Add("Zona no encontrada en la base de datos");
            }
            return colErrores;
        }


        public List<string> modificarZona(DtoZona mDtoZona)
        {
            List<string> colErrores = validarZona(mDtoZona, true);
            if(colErrores.Count()==0)
            {
                this._Repository.GetZonaRepository().modificarZona(mDtoZona);
            }
            return colErrores;
        }

        public List<DtoZona> listarZonas()
        {
            return this._Repository.GetZonaRepository().listarZonas();
        }



        //validacion
        public List<string> validarZona(DtoZona dtoZona, bool modificacion)
        {
            List<string> colErrores = new List<string>();

            if(dtoZona.Nombre==null)
            {
                colErrores.Add("El nombre de la zona no puede estar vacio");
            }
            if(dtoZona.Color==null)
            {
                colErrores.Add("La zona debe tener un color asignado");
            }
            if(!this._Repository.GetZonaRepository().existeZona(dtoZona.Numero))
            {
                colErrores.Add("La zona no existe");
            }


            return colErrores;
        }

    }
}

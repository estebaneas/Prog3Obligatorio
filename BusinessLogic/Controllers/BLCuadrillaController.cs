using Common.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class BLCuadrillaController
    {
        private Repository _Repository;

        public BLCuadrillaController()
        {
            this._Repository = new Repository();
        }

        //agregar cuadrilla
        public List<string> agregarCuadrilla(DtoCuadrilla dto)
        {
            List<string> colErrores = this.ValidarCuadrilla(dto, false);

            if(colErrores.Count == 0)
            {
                this._Repository.GetCuadrillaRepository().AgregarCuadrilla(dto);
            }

            return colErrores;
        }
        //validacion cuadrilla
        public List<string> ValidarCuadrilla(DtoCuadrilla dto, bool Modificable)
        {
            List<string> errores = new List<string>();

            if (dto.nombre == null)
            {
                errores.Add("Debe de asignarle un nombre a la cuadrilla");
            }
            else if (dto.nombre.Length > 25)
            {
                errores.Add("El nombre de la cuadrilla no debe superar los 25 caracteres");
            }

            if(dto.encargado == null)
            {
                errores.Add("Se debe asignar un encargado a la cuadrilla");
            }
            else if (dto.encargado.Length > 25)
            {
                errores.Add("No debe superar los 25 carcteres para encargados");
            }

            if (dto.cantidadPeones == null)
            {
                errores.Add("Debe de de asignar una cantidad de peones para la cuadrilla");
            }

            if (Modificable == true)
            {
                if (!this.ExisteCuadrilla(dto.numero))
                {
                    errores.Add("El número de cuadrilla no existe");
                }
            }
            return errores;
        }

        //existe cuadrilla
        public bool ExisteCuadrilla(int numCuadrilla)
        {
            return this._Repository.GetCuadrillaRepository().existeCuadrilla(numCuadrilla);
        }

        //modificar cuadrilla
        public List<string> modificarCuadrilla(DtoCuadrilla dto)
        {
            List<string> colErrores = this.ValidarCuadrilla(dto, true);

            if (colErrores.Count == 0)
            {
                this._Repository.GetCuadrillaRepository().modificarCuadrilla(dto);
            }


            return colErrores;
        }

        //borrar cuadrilla
        public List<string> BorrarCuadrilla(int numero)
        {
            List<string> colErrores = this.ValidarBorradoCuadrilla(numero);

            if (colErrores.Count == 0)
            {
                this._Repository.GetCuadrillaRepository().BorrarCuadrilla(numero);
            }

            return colErrores;
        }

        //validacion borrado cuadrilla
        public List<string> ValidarBorradoCuadrilla(int numero)
        {
            List<string> colErrores = new List<string>();

            if (!this._Repository.GetCuadrillaRepository().existeCuadrilla(numero))
            {
                colErrores.Add("La cuadrilla no existe");
            }

            return colErrores;
        }

        //listar cuadrilla
        public List<DtoCuadrilla> getColCuadrilla()
        {
            return this._Repository.GetCuadrillaRepository().getColCuadrilla();
        }


    }
}

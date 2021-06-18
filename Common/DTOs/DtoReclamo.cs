﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoReclamo
    {
        public int numero;
        public string estado;
        public DateTime fechaIngreso;
        public string observaciones;
        public string comentario;
        public decimal latitud;
        public decimal longitud;
        public string emailUsuario;
        public int numTipoReclamo;
        public int numeroCuadrilla;
        public int numeroZona;
        public DtoCuadrilla dtoCuadrilla;
        public List<DtoHistorialCambios> colDtoHistorialCambios;
        public DtoUsuario dtoUsuario;
        public DtoZona dtoZona;
        public DtoTipoReclamo dtoTipoReclamo;

        public int Numero { get => numero; set => numero = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public string EmailUsuario { get => emailUsuario; set => emailUsuario = value; }
        public int NumTipoReclamo { get => numTipoReclamo; set => numTipoReclamo = value; }
        public int NumeroCuadrilla { get => numeroCuadrilla; set => numeroCuadrilla = value; }
        public int NumeroZona { get => numeroZona; set => numeroZona = value; }
        public DtoCuadrilla DtoCuadrilla { get => dtoCuadrilla; set => dtoCuadrilla = value; }
        public List<DtoHistorialCambios> ColDtoHistorialCambios { get => colDtoHistorialCambios; set => colDtoHistorialCambios = value; }
        public DtoUsuario DtoUsuario { get => dtoUsuario; set => dtoUsuario = value; }
        public DtoZona DtoZona { get => dtoZona; set => dtoZona = value; }
        public DtoTipoReclamo DtoTipoReclamo { get => dtoTipoReclamo; set => dtoTipoReclamo = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class DtoHistorialCambios
    {
        public int numero;
        public int numeroReclamo;
        public DateTime fechaCambio;
        public DateTime fechaIngreso;
        public string observaciones;
        public string comentario;
        public decimal latitud;
        public decimal longitud;
        public string estado;
        public DtoReclamo dtoReclamo;

        public int Numero { get => numero; set => numero = value; }
        public int NumeroReclamo { get => numeroReclamo; set => numeroReclamo = value; }
        public DateTime FechaCambio { get => fechaCambio; set => fechaCambio = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public string Estado { get => estado; set => estado = value; }
        public DtoReclamo DtoReclamo { get => dtoReclamo; set => dtoReclamo = value; }
    }
}

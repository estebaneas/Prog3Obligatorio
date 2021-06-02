using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class Repository
    {
        public Repository()
        {
            this.cuadrillaRepository = new CuadrillaRepository();
            this.cambiosRepository = new HistorialCambiosRepository();
            this.puntoRepository = new PuntoRepository();
            this.reclamoRepository = new ReclamoRepository();
            this.tipoRepository = new TipoReclamoRepository();
            this.usuarioRepository = new UsuarioRepository();
            this.zonaRepository = new ZonaRepository();
        }


        private CuadrillaRepository cuadrillaRepository;
        private HistorialCambiosRepository cambiosRepository;
        private PuntoRepository puntoRepository;
        private ReclamoRepository reclamoRepository;
        private TipoReclamoRepository tipoRepository;
        private UsuarioRepository usuarioRepository;
        private ZonaRepository zonaRepository;

        public CuadrillaRepository GetCuadrillaRepository()
        {
            return this.cuadrillaRepository;
        }

        public HistorialCambiosRepository GetCambiosRepository()
        {
            return this.cambiosRepository;
        }

        public PuntoRepository GetPuntoRepository()
        {
            return this.puntoRepository;
        }

        public ReclamoRepository GetReclamoRepository()
        {
            return this.reclamoRepository;
        }

        public TipoReclamoRepository GetTipoReclamoRepository()
        {
            return this.tipoRepository;
        }

        public UsuarioRepository GetUsuarioRepository()
        {
            return this.usuarioRepository;
        }

        public ZonaRepository GetZonaRepository()
        {
            return this.zonaRepository;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo.Servicios;
using MadScienceAdo.MSSQL;
using MadScienceAdo.ACCESS;
using MadScienceBE;

namespace MadScienceAdo
{
    public class DaoFactory
    {
        private static DaoFactory fabrica;

        private DaoFactory() { }

        public static DaoFactory getFabrica()
        {
            if (fabrica == null)
            {
                fabrica = new DaoFactory();
            }
            return fabrica;
        }

        public ServicioGenerico<DetalleReservaEntity> getDetalleReserva(int tipo)
        {
            ServicioGenerico<DetalleReservaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new DetalleReservaAccess(); break;
                case Util.SQL: servicio = new DetalleReservaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TipoFiestaEntity> getTipoFiesta(int tipo)
        {
            ServicioGenerico<TipoFiestaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TipoFiestaAccess(); break;
                case Util.SQL: servicio = new TipoFiestaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<AsignacionEntity> getAsignacion(int tipo)
        {
            ServicioGenerico<AsignacionEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new AsignacionAccess(); break;
                case Util.SQL: servicio = new AsignacionSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TortaEntity> getTorta(int tipo)
        {
            ServicioGenerico<TortaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TortaAccess(); break;
                case Util.SQL: servicio = new TortaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }
        public ServicioGenerico<CebeEmpresaEntity> getCebeEmpresa(int tipo)
        {
            ServicioGenerico<CebeEmpresaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new CebeEmpresaAccess(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<SaborEntity> getSabor(int tipo)
        {
            ServicioGenerico<SaborEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new SaborAccess(); break;
                case Util.SQL: servicio = new SaborSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<FiestaEventoEntity> getFiestaEvento(int tipo)
        {
            ServicioGenerico<FiestaEventoEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new FiestaEventoAccess(); break;
                case Util.SQL: servicio = new FiestaEventoSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<DisponibilidadEntity> getDisponibilidad(int tipo)
        {
            ServicioGenerico<DisponibilidadEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new DisponibilidadAccess(); break;
                case Util.SQL: servicio = new DisponibilidadSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<EspecialidadEntity> getEspecialidad(int tipo)
        {
            ServicioGenerico<EspecialidadEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new EspecialidadAccess(); break;
                case Util.SQL: servicio = new EspecialidadSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }


        public ServicioGenerico<FiestaEntity> getFiesta(int tipo)
        {
            ServicioGenerico<FiestaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new FiestaAccess(); break;
                case Util.SQL: servicio = new FiestaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<HorarioEntity> getHorario(int tipo)
        {
            ServicioGenerico<HorarioEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new HorarioAccess(); break;
                case Util.SQL: servicio = new HorarioSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<PagoFiestaEntity> getPagoFiesta(int tipo)
        {
            ServicioGenerico<PagoFiestaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new PagoFiestaAccess(); break;
                case Util.SQL: servicio = new PagoFiestaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<ReservaEntity> getReserva(int tipo)
        {
            ServicioGenerico<ReservaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new ReservaAccess(); break;
                case Util.SQL: servicio = new ReservaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TiendaEntity> getTienda(int tipo)
        {
            ServicioGenerico<TiendaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TiendaAccess(); break;
                case Util.SQL: servicio = new TiendaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TipoEventoEntity> getTipoEvento(int tipo)
        {
            ServicioGenerico<TipoEventoEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TipoEventoAccess(); break;
                case Util.SQL: servicio = new TipoEventoSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TipoPagoEntity> getTipoPago(int tipo)
        {
            ServicioGenerico<TipoPagoEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TipoPagoAccess(); break;
                case Util.SQL: servicio = new TipoPagoSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TipoMovilidadEntity> getTipoMovilidad(int tipo)
        {
            ServicioGenerico<TipoMovilidadEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TipoMovilidadAccess(); break;
               // case Util.SQL: servicio = new TipoPagoSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<TrabajadorEntity> getTrabajador(int tipo)
        {
            ServicioGenerico<TrabajadorEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new TrabajadorAccess(); break;
                case Util.SQL: servicio = new TrabajadorSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<UsuarioEntity> getUsuario(int tipo)
        {
            ServicioGenerico<UsuarioEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new UsuarioAccess(); break;
                case Util.SQL: servicio = new UsuarioSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }

        public ServicioGenerico<ZonaEntity> getZona(int tipo)
        {
            ServicioGenerico<ZonaEntity> servicio;
            switch (tipo)
            {
                case Util.ACCESS: servicio = new ZonaAccess(); break;
                case Util.SQL: servicio = new ZonaSQL(); break;
                default: servicio = null; break;
            }
            return servicio;
        }



    }
}

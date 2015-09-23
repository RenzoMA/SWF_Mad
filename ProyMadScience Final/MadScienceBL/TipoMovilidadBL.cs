using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class TipoMovilidadBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TipoMovilidadEntity> servicioTipoMovilidad;

        public TipoMovilidadBL()
        {
            servicioTipoMovilidad = servicio.getTipoMovilidad(Constantes.COM);
        }
        public List<TipoMovilidadEntity> listarTodos()
        {
            return servicioTipoMovilidad.ListarTodos();
        }
        public TipoMovilidadEntity Consultar(int codigo)
        {
            return servicioTipoMovilidad.Consultar(codigo);
        }
        public bool Actualizar(TipoMovilidadEntity objTipo)
        {
            return servicioTipoMovilidad.Actualizar(objTipo);
        }
        public bool Agregar(TipoMovilidadEntity objTipo)
        {
            objTipo.Estado = "A";
            return servicioTipoMovilidad.Agregar(objTipo);
        }


    }
}

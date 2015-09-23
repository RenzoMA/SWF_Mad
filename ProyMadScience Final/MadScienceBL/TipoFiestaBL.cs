using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;


namespace MadScienceBL
{
    public class TipoFiestaBL
    {
         DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TipoFiestaEntity> servicioTipoFiesta;

        public TipoFiestaBL()
        {
            servicioTipoFiesta = servicio.getTipoFiesta(Constantes.COM);
        }
        public List<TipoFiestaEntity> ListarTodos()
        {
            return servicioTipoFiesta.ListarTodos();
        }
        public bool Agregar(TipoFiestaEntity obj)
        {
            return servicioTipoFiesta.Agregar(obj);
        }
        public bool Actualizar(TipoFiestaEntity obj)
        {
            return servicioTipoFiesta.Actualizar(obj);
        }
        public TipoFiestaEntity Consultar(int codigo)
        {
            return servicioTipoFiesta.Consultar(codigo);
        }
    }
}

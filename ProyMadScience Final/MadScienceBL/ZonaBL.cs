using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class ZonaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<ZonaEntity> servicioZona;
        public ZonaBL()
        {
            servicioZona = servicio.getZona(Constantes.COM);   
        }

        public List<ZonaEntity> ListarTodos()
        {
            return servicioZona.ListarTodos();
        }

        public List<ZonaEntity> ListarTodosCombo()
        {
            ZonaEntity objZona = new ZonaEntity();
            objZona.Codigo = 0;
            objZona.Nombre = "[--NINGUNO--]";
            List<ZonaEntity> listaZonas = servicioZona.ListarTodos();
            listaZonas.Insert(0, objZona);

            return listaZonas;
        }

        public bool Agregar(ZonaEntity objZona)
        {
            return servicioZona.Agregar(objZona);
        }
        public ZonaEntity Consultar(int codigo)
        {
            return servicioZona.Consultar(codigo);
        }
        public bool Actualizar(ZonaEntity objZona)
        {
            return servicioZona.Actualizar(objZona);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{

    public class TiendaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TiendaEntity> servicioTienda;
        ServicioGenerico<ZonaEntity> servicioZona;

        public TiendaBL()
        {
            servicioTienda = servicio.getTienda(Constantes.COM);
            servicioZona = servicio.getZona(Constantes.COM);
        }
        public List<TiendaEntity> ListarTodos()
        {
            List<TiendaEntity> lTienda = servicioTienda.ListarTodos();
            List<ZonaEntity> lZona = servicioZona.ListarTodos();

            var query = from li in lTienda
                        from zo in lZona.Where(o => li.CodigoZona == o.Codigo).DefaultIfEmpty()
                        select new {TiendaEntity = li,ZonaEntity = zo};

            List<TiendaEntity> listaTienda = new List<TiendaEntity>();
            foreach (var resultado in query)
            {
                TiendaEntity objTienda = new TiendaEntity();
                objTienda.Codigo = resultado.TiendaEntity.Codigo;
                objTienda.NombreZona = resultado.ZonaEntity == null ? "Ninguno" : resultado.ZonaEntity.Nombre;
                objTienda.Nombre = resultado.TiendaEntity.Nombre;
                objTienda.Estado = resultado.TiendaEntity.Estado == "A" ? "Activo" : "Inactivo";
                objTienda.Direccion = resultado.TiendaEntity.Direccion;
                objTienda.CodigoZona = resultado.TiendaEntity.CodigoZona;
                objTienda.CebeTienda = resultado.TiendaEntity.CebeTienda;
                listaTienda.Add(objTienda);
            }

            return listaTienda;
        }
        public TiendaEntity Consultar(int codigo)
        {
            return servicioTienda.Consultar(codigo);
        }

        public List<TiendaEntity> ListarTodoOpciones()
        {

            TiendaEntity objTip = new TiendaEntity();
            objTip.Codigo = 0;
            objTip.Estado = "A";
            objTip.Nombre = "[--TODOS--]";
            List<TiendaEntity> listaTipo = servicioTienda.ListarTodos();
            listaTipo.Insert(0, objTip);

            return listaTipo;
        }

        public bool Agregar(TiendaEntity objTienda)
        {
            if (objTienda.CodigoZona == 0)
            {
                objTienda.CodigoZona = null;
            }
            return servicioTienda.Agregar(objTienda);
        }

        public bool Actualizar(TiendaEntity objTienda)
        {
            if (objTienda.CodigoZona == 0)
            {
                objTienda.CodigoZona = null;
            }
            return servicioTienda.Actualizar(objTienda);
        }

    }
}

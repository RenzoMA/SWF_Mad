using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;


namespace MadScienceBL
{
    public class TipoEventoBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TipoEventoEntity> servicioTipoEvento;

        public TipoEventoBL()
        {
            servicioTipoEvento = servicio.getTipoEvento(Constantes.COM);
        }

        public List<TipoEventoEntity> ListarTodo()
        {
            return servicioTipoEvento.ListarTodos();
        }

        public List<TipoEventoEntity> ListarTodoOpciones()
        {
            
            TipoEventoEntity objTip = new TipoEventoEntity();
            objTip.Codigo = 0;
            objTip.Estado = "A";
            objTip.Nombre = "[--TODOS--]";
            List<TipoEventoEntity> listaTipo = servicioTipoEvento.ListarTodos();
            listaTipo.Insert(0, objTip);

            return listaTipo;
        }

        public List<TipoEventoEntity> ListarTodoGrilla()
        {
            List<TipoEventoEntity> lista = servicioTipoEvento.ListarTodos();
            foreach (TipoEventoEntity tipo in lista)
            {
                tipo.Estado = tipo.Estado== "A"? "Activo":"Inactivo";
            }
            return lista;
        }

        public bool Agregar(TipoEventoEntity obj)
        {
            return servicioTipoEvento.Agregar(obj);
        }
        public TipoEventoEntity Consultar(int codigo)
        {
            return servicioTipoEvento.Consultar(codigo);
        }
        public bool Actualizar(TipoEventoEntity objTipo)
        {
            return servicioTipoEvento.Actualizar(objTipo);
        }

        public TipoEventoEntity ValidarNombre(string nombre)
        {
            TipoEventoEntity objTipo = servicioTipoEvento.ListarTodos().Where(tx => tx.Nombre == nombre).ToList().FirstOrDefault();
            return objTipo;
        }
    }
}

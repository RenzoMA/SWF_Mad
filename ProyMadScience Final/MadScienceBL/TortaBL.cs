using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;


namespace MadScienceBL
{
    public class TortaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TortaEntity> servicioTorta;
        public TortaBL()
        {
            servicioTorta = servicio.getTorta(Constantes.COM);   
        }

        public List<TortaEntity> ListarTodo()
        {
            return servicioTorta.ListarTodos();
        }
        public bool Agregar(TortaEntity obj)
        {
            return servicioTorta.Agregar(obj);
        }
        public bool Actualizar(TortaEntity obj)
        {
            return servicioTorta.Actualizar(obj);
        }
        public bool ValidarNombre(String nombre, int codigo)
        {
            TortaEntity obj = ListarTodo().Where(tx => tx.Nombre == nombre && tx.Codigo != codigo).ToList().FirstOrDefault();
            if (obj != null)
            {
                return false;
            }
            return true;
        }
        public TortaEntity Consultar(int codigo)
        {
            return servicioTorta.Consultar(codigo);
        }

        public List<TortaEntity> ListarTodoSelectivo()
        {
            List<TortaEntity> lista = servicioTorta.ListarTodos();
            TortaEntity obj = new TortaEntity();
            obj.Codigo = 0;
            obj.Nombre = "[--SELECCIONE--]";
            lista.Insert(0, obj);
            return lista;
        }

        public bool ValidarNombreTorta(string nombre)
        {
            TortaEntity obj = servicioTorta.ListarTodos().Where(tx => tx.Nombre == nombre).ToList().FirstOrDefault();
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

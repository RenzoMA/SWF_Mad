using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class SaborBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<SaborEntity> servicioSabor;
        public SaborBL()
        {
            servicioSabor = servicio.getSabor(Constantes.COM);   
        }

        public List<SaborEntity> ListarTodo()
        {
            return servicioSabor.ListarTodos();
        }
        public bool Agregar(SaborEntity obj)
        {
            return servicioSabor.Agregar(obj);
        }
        public bool Actualizar(SaborEntity obj)
        {
            return servicioSabor.Actualizar(obj);
        }
        public bool ValidarNombre(String nombre, int codigo)
        {
            SaborEntity obj = ListarTodo().Where(tx => tx.Nombre == nombre && tx.Codigo != codigo).ToList().FirstOrDefault();
            if (obj != null)
            {
                return false;
            }
            return true;
        }
        public SaborEntity Consultar(int codigo)
        {
            return servicioSabor.Consultar(codigo);
        }

        public List<SaborEntity> ListarTodoSelectivo()
        {
            List<SaborEntity> lista = servicioSabor.ListarTodos();
            SaborEntity obj = new SaborEntity();
            obj.Codigo = 0;
            obj.Nombre = "[--SELECCIONE--]";
            lista.Insert(0, obj);
            return lista;
        }

        public bool ValidarNombreSabor(String nombre)
        {
            SaborEntity objSabor = servicioSabor.ListarTodos().Where(tx => tx.Nombre == nombre).ToList().FirstOrDefault();
            if (objSabor != null)
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

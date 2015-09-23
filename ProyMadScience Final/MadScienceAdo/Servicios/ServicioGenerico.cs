using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceAdo.Servicios
{
    public interface ServicioGenerico <T>
    {
         bool Agregar(T t);
         bool Actualizar(T t);
         bool Eliminar(T t);
         List<T> ListarTodos();
         T Consultar(object codigo);
         int Insertar(T t);
         List<T> ListarFecha(DateTime fechaInicio, DateTime fechaFin);
    }
}

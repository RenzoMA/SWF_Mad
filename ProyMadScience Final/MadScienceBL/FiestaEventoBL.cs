using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceBL
{
    public class FiestaEventoBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<FiestaEventoEntity> servicioFiestaEvento;
        ServicioGenerico<TipoEventoEntity> servicioEvento;

        public FiestaEventoBL()
        {
            servicioFiestaEvento = servicio.getFiestaEvento(Constantes.COM);
            servicioEvento = servicio.getTipoEvento(Constantes.COM);
        }
        public bool ValidarDuplicidad(FiestaEventoEntity obj)
        {
            FiestaEventoEntity objCons = servicioFiestaEvento.ListarTodos().Where(tx => tx.CodigoFiesta == obj.CodigoFiesta
                                                                              && tx.CodigoTipoEvento == obj.CodigoTipoEvento).ToList().FirstOrDefault();
            if (objCons != null)
            {
                return false;
            }
            return true;
        }
        public List<FiestaEventoEntity> ListarTodos()
        {
            return servicioFiestaEvento.ListarTodos();
        }

        public List<FiestaEventoEntity> ListarPorFiesta(int codigo)
        {
            List<FiestaEventoEntity> listaEventoFiesta = servicioFiestaEvento.ListarTodos()
                                     .Where(tx => tx.CodigoFiesta == codigo).ToList();
            List<TipoEventoEntity> listaEvento = servicioEvento.ListarTodos();

            var query = from ef in listaEventoFiesta
                        join evento in listaEvento
                        on ef.CodigoTipoEvento equals evento.Codigo
                        select new {Codigo = ef.CodigoTipoEvento,Nombre=evento.Nombre,FechaCreacion = ef.FechaCreacion};

            List<FiestaEventoEntity> lCompuesta = new List<FiestaEventoEntity>();
            foreach (var resultado in query)
            {
                FiestaEventoEntity aux = new FiestaEventoEntity();
                aux.NombreEvento = resultado.Nombre;
                aux.CodigoTipoEvento = resultado.Codigo;
                aux.FechaCreacion = resultado.FechaCreacion;
                lCompuesta.Add(aux);
            }

            return lCompuesta;
        }

        public bool Agregar(FiestaEventoEntity obj)
        {
            return servicioFiestaEvento.Agregar(obj);
        }
        public bool Eliminar(FiestaEventoEntity obj)
        {
            return servicioFiestaEvento.Eliminar(obj);
        }


    }
}

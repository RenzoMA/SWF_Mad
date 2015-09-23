using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceBE;
using MadScienceAdo.Servicios;


namespace MadScienceBL
{
    public class FiestaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<FiestaEntity> servicioFiesta;
        ServicioGenerico<FiestaEventoEntity> servicioFiestaEvento;
        ServicioGenerico<TipoFiestaEntity> servicioTipoFiesta;
        TipoFiestaBL tipoFiestaBL;

        public FiestaBL()
        {
            servicioFiesta = servicio.getFiesta(Constantes.COM);
            servicioTipoFiesta = servicio.getTipoFiesta(Constantes.COM);
            servicioFiestaEvento = servicio.getFiestaEvento(Constantes.COM);
            tipoFiestaBL = new TipoFiestaBL();
        }

        public List<FiestaEntity> ListarTodos()
        {
            List<TipoFiestaEntity> listaTipo = tipoFiestaBL.ListarTodos();
            List<FiestaEntity> lFiesta = servicioFiesta.ListarTodos();
            foreach (FiestaEntity fi in lFiesta)
            {
                fi.Estado = fi.Estado == "A" ? "Activo" : "Inactivo";
                fi.NombreTipo = listaTipo.Where(tx => tx.Codigo == fi.CodigoTipoFiesta).FirstOrDefault().Nombre;
            }
            return lFiesta;
        }
        public List<FiestaEntity> ListarFiltrado(int codigoTipo)
        {
            List<FiestaEntity> lFiesta = servicioFiesta.ListarTodos().Where(tx => tx.CodigoTipoFiesta == codigoTipo).ToList();
            foreach (FiestaEntity fi in lFiesta)
            {
                fi.Estado = fi.Estado == "A" ? "Activo" : "Inactivo";
            }
            return lFiesta;
        }

        public List<FiestaEntity> ListarFiltro(String filtro)
        {
            List<TipoFiestaEntity> listaTipo = tipoFiestaBL.ListarTodos();
            List<FiestaEntity> lFiesta = servicioFiesta.ListarTodos().Where(tx => tx.Nombre.Contains(filtro)).ToList();
            foreach (FiestaEntity fi in lFiesta)
            {
                fi.Estado = fi.Estado == "A" ? "Activo" : "Inactivo";
                fi.NombreTipo = listaTipo.Where(tx => tx.Codigo == fi.CodigoTipoFiesta).FirstOrDefault().Nombre;
            }
            return lFiesta;
        }
        public bool ValidarNombreFiesta(String nombre,int codigo)
        {
            FiestaEntity obj = servicioFiesta.ListarTodos().Where(tx => tx.Nombre == nombre && tx.Codigo!=codigo).ToList().FirstOrDefault();
            if (obj != null)
            {
                return false;
            }
            return true;
        }
        public FiestaEntity Consultar(int codigo)
        {
            return servicioFiesta.Consultar(codigo);
        }

        public bool Agregar(FiestaEntity obj)
        {
            return servicioFiesta.Agregar(obj);
        }

        public bool Actualizar(FiestaEntity obj)
        {
            return servicioFiesta.Actualizar(obj);
        }
        public List<FiestaEntity> ListarEventoAndTipo(int codigoTipoEvento, int codigoTipoFiesta)
        {
            List<FiestaEntity> listaFiesta = servicioFiesta.ListarTodos()
                                            .Where(tx => tx.CodigoTipoFiesta == codigoTipoFiesta).ToList();
            List<FiestaEventoEntity> listaFiestaEvento = servicioFiestaEvento.ListarTodos()
                                            .Where(tx => tx.CodigoTipoEvento == codigoTipoEvento).ToList();

            var query = from fiesta in listaFiesta
                        join fevento in listaFiestaEvento
                        on fiesta.Codigo equals fevento.CodigoFiesta
                        select new { Codigo = fiesta.Codigo, Nombre = fiesta.Nombre };

            List<FiestaEntity> listaCompuesta = new List<FiestaEntity>();
            foreach (var resultado in query)
            {
                FiestaEntity objFiesta = new FiestaEntity();
                objFiesta.Codigo = resultado.Codigo;
                objFiesta.Nombre = resultado.Nombre;
                listaCompuesta.Add(objFiesta);
            }
            return listaCompuesta;
            
        }

        public FiestaEntity ValidarNombreExiste(string nombre)
        {
            FiestaEntity objFiesta = servicioFiesta.ListarTodos().Where(tx => tx.Nombre == nombre).ToList().FirstOrDefault();
            if (objFiesta != null)
            {
                return objFiesta;
            }
            return null;
        }

    }
}

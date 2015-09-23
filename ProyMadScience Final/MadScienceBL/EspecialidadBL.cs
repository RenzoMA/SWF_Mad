using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceBL
{
    public class EspecialidadBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<EspecialidadEntity> servicioEspecialidad;
        ServicioGenerico<FiestaEntity> servicioFiesta;
        ServicioGenerico<TipoFiestaEntity> servicioTipoFiesta;

        public EspecialidadBL()
        {
            servicioEspecialidad = servicio.getEspecialidad(Constantes.COM);
            servicioFiesta = servicio.getFiesta(Constantes.COM);
            servicioTipoFiesta = servicio.getTipoFiesta(Constantes.COM);
        }

        public bool Agregar(EspecialidadEntity objEspe)
        {
            return servicioEspecialidad.Agregar(objEspe);
        }
        public bool Validar(EspecialidadEntity objEspe)
        {
            EspecialidadEntity obj = servicioEspecialidad.ListarTodos().Where(tx => tx.CodigoFiesta == objEspe.CodigoFiesta && tx.CodigoTrabajador == objEspe.CodigoTrabajador).ToList().FirstOrDefault();
            if (obj != null)
            {
                return false;
            }
            return true;
        }

        public List<EspecialidadEntity> ListarPorTrabajador(int codigo)
        {
            List<EspecialidadEntity> lEspecialidad = servicioEspecialidad.ListarTodos().Where(tx => tx.CodigoTrabajador == codigo).ToList();
            List<FiestaEntity> lFiesta = servicioFiesta.ListarTodos();
            List<TipoFiestaEntity> lTipoFiesta = servicioTipoFiesta.ListarTodos();

            var query = from especialidad in lEspecialidad
                        join fiesta in lFiesta
                        on especialidad.CodigoFiesta equals fiesta.Codigo into fiestax
                        from cod in fiestax
                        join tipo in lTipoFiesta
                        on cod.CodigoTipoFiesta equals tipo.Codigo
                        select new { Especialidad =  cod.Nombre, Tipo = tipo.Nombre, Cod = cod.Codigo};

            List<EspecialidadEntity> objLista = new List<EspecialidadEntity>();
            foreach (var resultado in query)
            {
                EspecialidadEntity objEspe = new EspecialidadEntity();
                objEspe.NombreFiesta = resultado.Especialidad;
                objEspe.TipoFiesta = resultado.Tipo;
                objEspe.CodigoFiesta = resultado.Cod;
                objLista.Add(objEspe);
            }
            return objLista;

        }

        public bool Eliminar(EspecialidadEntity obj)
        {
            return servicioEspecialidad.Eliminar(obj);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.ACCESS;
using MadScienceBE;
using MadScienceAdo.Servicios;


namespace MadScienceBL
{
    public class CebeEmpresaBL
    {
        ServicioGenerico<CebeEmpresaEntity> servicioEmpresa;
        public CebeEmpresaBL()
        {
            servicioEmpresa = DaoFactory.getFabrica().getCebeEmpresa(Constantes.COM);
        }

        public List<CebeEmpresaEntity> ListarTodos()
        {
            return servicioEmpresa.ListarTodos();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class HorarioBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<HorarioEntity> servicioHorario;

        public HorarioBL()
        {
            servicioHorario = servicio.getHorario(Constantes.COM);
        }
        public List<HorarioEntity> ListarPorDia(string nombre)
        {
            List<HorarioEntity> lHorario = servicioHorario.ListarTodos().Where(tx => tx.NomDia == nombre).ToList();
            return lHorario;
        }
    }
}

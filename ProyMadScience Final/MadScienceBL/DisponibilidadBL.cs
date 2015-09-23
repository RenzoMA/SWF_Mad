using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceBL
{
    public class DisponibilidadBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<DisponibilidadEntity> servicioDisponibilidad;
        ServicioGenerico<HorarioEntity> servicioHorario;

        public DisponibilidadBL()
        {
            servicioDisponibilidad = servicio.getDisponibilidad(Constantes.COM);
            servicioHorario = servicio.getHorario(Constantes.COM);
        }

        public bool Agregar(DisponibilidadEntity dispo)
        {
            return servicioDisponibilidad.Agregar(dispo);
        }

        public bool ValidarDuplicidad(DisponibilidadEntity dispo)
        {
            DisponibilidadEntity obj = servicioDisponibilidad.ListarTodos().Where(tx => tx.CodigoHorario == dispo.CodigoHorario && tx.CodigoTrabajador == dispo.CodigoTrabajador).ToList().FirstOrDefault();
            if (obj != null)
            {
                return false;
            }
            return true;
        }

        public bool Actualizar(DisponibilidadEntity dispo)
        {
            return servicioDisponibilidad.Actualizar(dispo);
        }

        public bool Eliminar(DisponibilidadEntity dispo)
        {
            return servicioDisponibilidad.Eliminar(dispo);
        }
        public List<DisponibilidadEntity> ListarPorTrabajadorDia(int codigo,String dia)
        {
            List<DisponibilidadEntity> lDisponibilidad = servicioDisponibilidad.ListarTodos();
            List<HorarioEntity> lHorario = servicioHorario.ListarTodos();

            var query = from dispo in lDisponibilidad
                        join horario in lHorario
                        on dispo.CodigoHorario equals horario.Codigo
                        where horario.NomDia==dia && dispo.CodigoTrabajador == codigo
                        select new { Codigo = dispo.CodigoHorario, Horario = horario.HoraInicio + " - " + horario.HoraFin };

            List<DisponibilidadEntity> listaDisponibilidad = new List<DisponibilidadEntity>();
            foreach (var resultado in query)
            {
                DisponibilidadEntity objDisponibilidad = new DisponibilidadEntity();
                objDisponibilidad.CodigoHorario = resultado.Codigo;
                objDisponibilidad.Horario = resultado.Horario;
                listaDisponibilidad.Add(objDisponibilidad);
            }

            return listaDisponibilidad;
        }

    }
}

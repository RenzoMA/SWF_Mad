using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo.Servicios;
using MadScienceAdo;
using MadScienceBE;


namespace MadScienceBL
{
    public class TrabajadorBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<TrabajadorEntity> servicioTrabajador;
        ServicioGenerico<EspecialidadEntity> servicioEspecialidad;
        ServicioGenerico<DisponibilidadEntity> servicioDisponibilidad;
        ServicioGenerico<AsignacionEntity> servicioAsignacion;
        ServicioGenerico<HorarioEntity> servicioHorario;
        ServicioGenerico<ReservaEntity> servicioReserva;
        ServicioGenerico<ZonaEntity> servicioZona;


        public TrabajadorBL()
        {
            servicioTrabajador = servicio.getTrabajador(Constantes.COM);
            servicioEspecialidad = servicio.getEspecialidad(Constantes.COM);
            servicioDisponibilidad = servicio.getDisponibilidad(Constantes.COM);
            servicioAsignacion = servicio.getAsignacion(Constantes.COM);
            servicioHorario = servicio.getHorario(Constantes.COM);
            servicioReserva = servicio.getReserva(Constantes.COM);
            servicioZona = servicio.getZona(Constantes.COM);
        }

        public List<TrabajadorEntity> ListarTodos()
        {
            List<TrabajadorEntity> lTrabajador= servicioTrabajador.ListarTodos();
            List<ZonaEntity> lZona = servicioZona.ListarTodos();

            foreach (TrabajadorEntity tra in lTrabajador)
            {
                tra.NombreZona = lZona.Where(tx => tx.Codigo == tra.CodigoZona).FirstOrDefault().Nombre;
                tra.Estado = tra.Estado == "A" ? "Activo" : "Inactivo";
            }
            return lTrabajador;
        }

        public List<TrabajadorEntity> ListarTodosMultiple()
        {
            List<TrabajadorEntity> lTrabajador = servicioTrabajador.ListarTodos();
            lTrabajador = lTrabajador.OrderBy(tx => tx.Nombre).ToList();
            TrabajadorEntity obj = new TrabajadorEntity();
            obj.Codigo = 0;
            obj.Nombre = "[--TODOS--]";
            lTrabajador.Insert(0, obj);
            foreach (TrabajadorEntity tra in lTrabajador)
            {
                tra.Estado = tra.Estado == "A" ? "Activo" : "Inactivo";
            }
            return lTrabajador;
        }

        public bool Agregar(TrabajadorEntity obj)
        {
            return servicioTrabajador.Agregar(obj);
        }

        public bool Actualizar(TrabajadorEntity obj)
        {
            return servicioTrabajador.Actualizar(obj);
        }

        public TrabajadorEntity Consultar(int codigo)
        {
            return servicioTrabajador.Consultar(codigo);
        }

        public bool ValidarNombre(string nombre)
        {
            TrabajadorEntity objTrabajador = ListarTodos().Where(tx => tx.Nombre == nombre).ToList().FirstOrDefault();
            if (objTrabajador != null)
            {
                return false;
            }
            return true;
        }
        public List<TrabajadorEntity> ListarPorNombre(string nombre)
        {
            List<TrabajadorEntity> lTrabajador = servicioTrabajador.ListarTodos().Where(tx => tx.Nombre.Contains(nombre)).ToList();
            List<ZonaEntity> lZona = servicioZona.ListarTodos();
            foreach (TrabajadorEntity tra in lTrabajador)
            {
                tra.NombreZona = lZona.Where(tx => tx.Codigo == tra.CodigoZona).FirstOrDefault().Nombre;
                tra.Estado = tra.Estado == "A" ? "Activo" : "Inactivo";
            }
            return lTrabajador;
        }

        public List<TrabajadorHorario>ListarTrabajadorAsignaciones(DateTime fechaCelebracion,String dia,double horaInicio,double horaFin,int codigoFiesta,int codigoReserva)
        {
            List<TrabajadorHorario> lista = new List<TrabajadorHorario>();
            List<TrabajadorEntity> listaTraBD = ListarTodos();

            List<HorarioEntity> listaHorario = servicioHorario.ListarTodos().Where(tx => tx.NomDia == dia).ToList();
            // Lista los horarios base para el dia de la fiesta.
            List<DisponibilidadEntity> listaDisponibilidad = servicioDisponibilidad.ListarTodos();
            // Lista las disponibilidades de todos los trabajadores.
            List<EspecialidadEntity> listaEspecialidad = servicioEspecialidad.ListarTodos().Where(tx => tx.CodigoFiesta == codigoFiesta).ToList();
            // Lista las especialidades de todos los trabajadores.

            var query = (from horario in listaHorario
                        join dispo in listaDisponibilidad
                        on horario.Codigo equals dispo.CodigoHorario
                        select new {Disponibilidad = dispo,Horario= horario})
                        .OrderBy(tx=>tx.Disponibilidad.CodigoTrabajador)
                        .ThenBy(n=>n.Horario.HoraInicio);

            // Query hace el match, solo quedan los trabajadores que estan disponibles ese dia (aun no valida la hora).


            foreach (var dispo in query)
            {
                int valida = 0;
                foreach(TrabajadorHorario tra in lista)
                {
                    if (tra.CodigoTrabajador == dispo.Disponibilidad.CodigoTrabajador)
                    {
                        if (tra.HoraMax == dispo.Horario.HoraInicio)
                        {
                            tra.HoraMax = dispo.Horario.HoraFin;
                            //Agrupamos en minimos y maximos para poder aplicarlo a cualquier evento.
                            valida = 1;
                            break;
                        }
                    }
                }
                if (valida == 0)
                {
                    TrabajadorHorario trabajador = new TrabajadorHorario();
                    trabajador.CodigoTrabajador = dispo.Disponibilidad.CodigoTrabajador;
                    trabajador.HoraMin = dispo.Horario.HoraInicio;
                    trabajador.HoraMax = dispo.Horario.HoraFin;
                    lista.Add(trabajador);
                }
            }

            
            List<TrabajadorHorario> listaTrabajador = lista.Where(tx => horaInicio>=tx.HoraMin && horaFin<=tx.HoraMax).ToList();
            //Filtramos la lista para que filtre la hora del evento.
            // Hasta aqui ya tenemos la lista de los que pueden por skill y por horario.

            List<AsignacionEntity> listaAsignacion = servicioAsignacion.ListarFecha(fechaCelebracion,fechaCelebracion)//modificado
                                        .Where(tx => tx.FechaReserva == fechaCelebracion && tx.CodigoReserva!=codigoReserva &&
                                            ((tx.HoraInicio > horaInicio && tx.HoraInicio < horaFin) ||
                                            (tx.HoraFin > horaInicio && tx.HoraFin < horaFin) ||
                                            (tx.HoraInicio < horaInicio && tx.HoraFin > horaFin)||
                                            (tx.HoraInicio==horaInicio && tx.HoraFin==horaFin) ||
                                            (tx.HoraInicio==horaInicio && tx.HoraFin>horaFin))).ToList();
            //listaAsignacion -> todos los que no pueden por cruce.

            foreach (TrabajadorHorario trab in listaTrabajador)
            {
                trab.NombreTrabajador = servicioTrabajador.Consultar(trab.CodigoTrabajador).Nombre;
                foreach (AsignacionEntity asi in listaAsignacion)
                {
                    if (trab.CodigoTrabajador == asi.CodigoTrabajador)
                    {
                        trab.State = "NO";
                        break;
                    }
                }
            }
            listaTrabajador = listaTrabajador.Where(tx => tx.State != "NO").ToList();


            DateTime fechaInicio;
            DateTime fechaFin;
            int actualMonth = DateTime.Now.Month;
            int actualYear = DateTime.Now.Year;
            int actualDay = DateTime.Now.Day;

            if (actualDay > 12)
            {
                fechaInicio = Convert.ToDateTime((13 + "/" + actualMonth + "/" + actualYear));
                if (actualMonth < 12)
                {
                    actualMonth = actualMonth + 1;
                    fechaFin = Convert.ToDateTime((12 + "/" + actualMonth + "/" + actualYear));
                }
                else
                {
                    actualYear = actualYear + 1;
                    fechaFin = Convert.ToDateTime((12 + "/" + 1 + "/" + actualYear));
                }
            }
            else
            {
                if (actualMonth > 1)
                {
                    actualMonth = actualMonth - 1;
                    fechaInicio = Convert.ToDateTime((13 + "/" + actualMonth + "/" + actualYear));
                    actualMonth = actualMonth + 1;
                    fechaFin = Convert.ToDateTime(12 + "/" + actualMonth + "/" + actualYear);
                }
                else
                {
                    actualYear = actualYear - 1;
                    fechaFin = Convert.ToDateTime(12 + "/" + 1 + "/" + (actualYear + 1));
                    fechaInicio = Convert.ToDateTime(13 + "/" + 12 + "/" + actualYear);
                }
            }
            fechaFin = fechaFin.Add(TimeSpan.Parse("23:59:59"));


            //Se agrego ListarFecha
            List<AsignacionEntity> listaCantidad = servicioAsignacion.ListarFecha(fechaInicio,fechaFin).Where(tx => tx.FechaReserva >= fechaInicio && tx.FechaReserva <= fechaFin).ToList();

            var cantidad = listaCantidad.GroupBy(tx => tx.CodigoTrabajador)
                                          .Select(gp => new { CodigoT = gp.Key, Cuenta = gp.Count() })
                                          .OrderBy(x => x.CodigoT);

            foreach (TrabajadorHorario trab in listaTrabajador)
            {
                foreach (var result in cantidad)
                {
                    if (result.CodigoT == trab.CodigoTrabajador)
                    {
                        trab.CantidadAsignaciones = result.Cuenta;
                    }
                }
                trab.NombreTrabajador = trab.CantidadAsignaciones + " - " + trab.NombreTrabajador;
            }
            listaTrabajador = listaTrabajador.OrderBy(tx => tx.CantidadAsignaciones).ToList();
            List<ZonaEntity> lZona = servicioZona.ListarTodos();
            foreach (TrabajadorHorario tra in listaTrabajador)
            {
                tra.CodigoZona = listaTraBD.Where(tx => tx.Codigo == tra.CodigoTrabajador).FirstOrDefault().CodigoZona;
                tra.NombreZona = lZona.Where(tx => tx.Codigo == tra.CodigoZona).FirstOrDefault().Nombre;
            }

            int encontrado=0;
            for (int i = listaTrabajador.Count-1; i >= 0; i--)
            {
                encontrado=0;
                foreach (EspecialidadEntity espe in listaEspecialidad)
                {
                    if (listaTrabajador[i].CodigoTrabajador == espe.CodigoTrabajador)
                    {
                        encontrado = 1;
                        break;
                    }
                }
                if (encontrado == 0)
                {
                    listaTrabajador.RemoveAt(i);
                }
            }


            return listaTrabajador;

        }


    }
}

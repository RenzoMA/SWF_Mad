using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;
using System.Data.Entity;

namespace MadScienceAdo.MSSQL
{
    public class DisponibilidadSQL : ServicioGenerico<DisponibilidadEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(DisponibilidadEntity t)
        {
            tb_disponibilidad objDisponibilidad = null;
            try
            {

                objDisponibilidad = new tb_disponibilidad();
                objDisponibilidad.fch_creacion = t.FechaCreacion;
                objDisponibilidad.id_horario = t.CodigoHorario;
                objDisponibilidad.id_trabajador = t.CodigoTrabajador;
                objDisponibilidad.usr_creacion = t.UsuarioCreacion;
                msEntities.tb_disponibilidad.Add(objDisponibilidad);
                msEntities.SaveChanges();

                return true;
            }
            catch
            {
                msEntities.tb_disponibilidad.Remove(objDisponibilidad);
                return false;
            }
        }

        public bool Actualizar(DisponibilidadEntity t)
        {
            try
            {
                tb_disponibilidad objDisponibilidad = (from var in msEntities.tb_disponibilidad
                                                       where var.id_horario == t.CodigoHorario &&
                                                       var.id_trabajador == t.CodigoTrabajador
                                                       select var).FirstOrDefault();
                objDisponibilidad.fch_creacion = t.FechaCreacion;
                objDisponibilidad.id_horario = t.CodigoHorario;
                objDisponibilidad.id_trabajador = t.CodigoTrabajador;
                objDisponibilidad.usr_creacion = t.UsuarioCreacion;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(DisponibilidadEntity t)
        {
            try
            {
                tb_disponibilidad objDisponibilidad = (from var in msEntities.tb_disponibilidad
                                                       where var.id_horario == t.CodigoHorario &&
                                                       var.id_trabajador == t.CodigoTrabajador
                                                       select var).FirstOrDefault();
                msEntities.tb_disponibilidad.Remove(objDisponibilidad);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DisponibilidadEntity> ListarTodos()
        {
            List<DisponibilidadEntity> objListaDisponibilidad = new List<DisponibilidadEntity>();
            try
            {
                var query = msEntities.tb_disponibilidad.ToList();
                foreach (var resultado in query)
                {
                    DisponibilidadEntity objDisponibilidad = new DisponibilidadEntity();
                    objDisponibilidad.CodigoHorario = resultado.id_horario;
                    objDisponibilidad.CodigoTrabajador = resultado.id_trabajador;
                    objDisponibilidad.FechaCreacion = resultado.fch_creacion;
                    objDisponibilidad.UsuarioCreacion = resultado.usr_creacion;
                    objListaDisponibilidad.Add(objDisponibilidad);
                }

                return objListaDisponibilidad;
            }
            catch
            {
                return objListaDisponibilidad;
            }
        }

        public DisponibilidadEntity Consultar(object codigo)
        {
            try
            {
                DisponibilidadEntity objDipo = (DisponibilidadEntity)codigo;
                var query = msEntities.tb_disponibilidad.Where(tx => tx.id_horario == objDipo.CodigoHorario && tx.id_trabajador == objDipo.CodigoTrabajador).ToList().FirstOrDefault();
                DisponibilidadEntity objDisponibilidad = new DisponibilidadEntity();
                objDipo.CodigoHorario = query.id_horario;
                objDipo.CodigoTrabajador = query.id_trabajador;
                objDipo.FechaCreacion = query.fch_creacion;
                objDipo.UsuarioCreacion = query.usr_creacion;
                return objDisponibilidad;

            }
            catch
            {
                return null;
            }
        }


        public int Insertar(DisponibilidadEntity t)
        {
            throw new NotImplementedException();
        }


        public List<DisponibilidadEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}

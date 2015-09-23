using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class EspecialidadSQL : ServicioGenerico<EspecialidadEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();

        public bool Agregar(EspecialidadEntity t)
        {
            tb_especialidad objEspecialidad = null;
            try
            {
                 objEspecialidad= new tb_especialidad();
                objEspecialidad.fch_creacion = t.FechaCreacion;
                objEspecialidad.id_fiesta = t.CodigoFiesta;
                objEspecialidad.id_trabajador = t.CodigoTrabajador;
                objEspecialidad.usr_creacion = t.UsuarioCreacion;
                msEntities.tb_especialidad.Add(objEspecialidad);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                msEntities.tb_especialidad.Remove(objEspecialidad);
                return false;
            }

        }

        public bool Actualizar(EspecialidadEntity t)
        {
            try
            {
                tb_especialidad objEspecialidad = (from esp in msEntities.tb_especialidad
                                                   where esp.id_fiesta == t.CodigoFiesta &&
                                                   esp.id_trabajador == t.CodigoTrabajador
                                                   select esp).FirstOrDefault();
                objEspecialidad.fch_creacion = t.FechaCreacion;
                objEspecialidad.id_fiesta = t.CodigoFiesta;
                objEspecialidad.id_trabajador = t.CodigoTrabajador;
                objEspecialidad.usr_creacion = t.UsuarioCreacion;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(EspecialidadEntity t)
        {
            try
            {
                tb_especialidad objEspecialidad = (from esp in msEntities.tb_especialidad
                                                   where esp.id_fiesta == t.CodigoFiesta &&
                                                   esp.id_trabajador == t.CodigoTrabajador
                                                   select esp).FirstOrDefault();
                msEntities.tb_especialidad.Remove(objEspecialidad);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<EspecialidadEntity> ListarTodos()
        {
            List<EspecialidadEntity> objListaEspecialidad = new List<EspecialidadEntity>();
            try
            {
                var query = msEntities.tb_especialidad.ToList();
                foreach (var resultado in query)
                {
                    EspecialidadEntity objEspecialidad = new EspecialidadEntity();
                    objEspecialidad.CodigoFiesta = resultado.id_fiesta;
                    objEspecialidad.CodigoTrabajador = resultado.id_trabajador;
                    objEspecialidad.FechaCreacion = resultado.fch_creacion;
                    objEspecialidad.UsuarioCreacion = resultado.usr_creacion;
                    objListaEspecialidad.Add(objEspecialidad);
                }
                return objListaEspecialidad;
            }
            catch
            {
                return null;
            }
        }

        public EspecialidadEntity Consultar(object codigo)
        {
            try
            {
                EspecialidadEntity t = (EspecialidadEntity)codigo;
                tb_especialidad objEspecialidad = (from esp in msEntities.tb_especialidad
                                                   where esp.id_fiesta == t.CodigoFiesta &&
                                                   esp.id_trabajador == t.CodigoTrabajador
                                                   select esp).FirstOrDefault();
                EspecialidadEntity objEspe = new EspecialidadEntity();
                objEspe.UsuarioCreacion = objEspecialidad.usr_creacion;
                objEspe.CodigoFiesta = objEspecialidad.id_fiesta;
                objEspe.CodigoTrabajador = objEspecialidad.id_trabajador;
                objEspe.FechaCreacion = objEspecialidad.fch_creacion;
                return objEspe;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(EspecialidadEntity t)
        {
            throw new NotImplementedException();
        }


        public List<EspecialidadEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}

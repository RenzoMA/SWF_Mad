using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;

namespace MadScienceAdo.MSSQL
{
    public class HorarioSQL : ServicioGenerico<HorarioEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();


        public bool Agregar(HorarioEntity t)
        {
            try
            {
                tb_horario objHorario = new tb_horario();
                objHorario.horaFin = t.HoraFin;
                objHorario.horaInicio = t.HoraInicio;
                objHorario.nomDia = t.NomDia;
                msEntities.tb_horario.Add(objHorario);
                msEntities.SaveChanges();
                return true;

            }
            catch
            {
                // Codigo que elimine todos los cambios no guardados.
                return false;
            }
        }

        public bool Actualizar(HorarioEntity t)
        {
            try
            {
                tb_horario objHorario = (from ho in msEntities.tb_horario
                                         where t.Codigo == ho.id_horario
                                         select ho).FirstOrDefault();
                objHorario.horaFin = t.HoraFin;
                objHorario.horaInicio = t.HoraInicio;
                objHorario.id_horario = t.Codigo;
                objHorario.nomDia = t.NomDia;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(HorarioEntity t)
        {
            try
            {
                tb_horario objHorario = (from ho in msEntities.tb_horario
                                         where t.Codigo == ho.id_horario
                                         select ho).FirstOrDefault();
                msEntities.tb_horario.Remove(objHorario);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<HorarioEntity> ListarTodos()
        {
            List<HorarioEntity> objListaHorario = new List<HorarioEntity>();
            try
            {
                var query = msEntities.tb_horario.ToList();
                foreach (var resultado in query)
                {
                    HorarioEntity objHorario = new HorarioEntity();
                    objHorario.Codigo = resultado.id_horario;
                    objHorario.HoraFin = Convert.ToDouble(resultado.horaFin);
                    objHorario.HoraInicio = Convert.ToDouble(resultado.horaInicio);
                    objHorario.NomDia = resultado.nomDia;
                    objListaHorario.Add(objHorario);
                }
                return objListaHorario;
            }
            catch
            {
                return null;
            }
        }

        public HorarioEntity Consultar(object codigo)
        {
            HorarioEntity objHorarioEntity = null;
            try
            {
                tb_horario objHorario = (from ho in msEntities.tb_horario
                                         where Convert.ToInt32(codigo.ToString()) == ho.id_horario
                                         select ho).FirstOrDefault();
                objHorarioEntity = new HorarioEntity();
                objHorarioEntity.Codigo = objHorario.id_horario;
                objHorarioEntity.HoraFin = Convert.ToDouble(objHorario.horaFin);
                objHorarioEntity.HoraInicio = Convert.ToDouble(objHorario.horaInicio);
                objHorarioEntity.NomDia = objHorario.nomDia;
                return objHorarioEntity;
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(HorarioEntity t)
        {
            throw new NotImplementedException();
        }


        public List<HorarioEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}

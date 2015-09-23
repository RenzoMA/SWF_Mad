using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;
using System.Data.OleDb;
using System.Data;

namespace MadScienceAdo.ACCESS
{
    public class HorarioAccess : ServicioGenerico<HorarioEntity>
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public bool Agregar(HorarioEntity t)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(HorarioEntity t)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(HorarioEntity t)
        {
            throw new NotImplementedException();
        }

        public List<HorarioEntity> ListarTodos()
        {
            List<HorarioEntity> listaHorario = new List<HorarioEntity>();
            try
            {
                cnx.ConnectionString = MiConex.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM TB_HORARIO";
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        HorarioEntity objHorario = new HorarioEntity();
                        objHorario.Codigo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("id_horario")).ToString());
                        objHorario.NomDia = dtr.GetValue(dtr.GetOrdinal("nomDia")).ToString();
                        objHorario.HoraInicio = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaInicio")).ToString());
                        objHorario.HoraFin = Convert.ToDouble(dtr.GetValue(dtr.GetOrdinal("horaFin")).ToString());
                        listaHorario.Add(objHorario);
                    }
                    dtr.Close();
                }
                return listaHorario;
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }          
        }

        public HorarioEntity Consultar(object codigo)
        {
            throw new NotImplementedException();
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

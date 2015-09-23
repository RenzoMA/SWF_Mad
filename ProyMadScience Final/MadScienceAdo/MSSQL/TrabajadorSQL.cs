using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceBE;
using MadScienceAdo.Servicios;


namespace MadScienceAdo.MSSQL
{
    public class TrabajadorSQL : ServicioGenerico<TrabajadorEntity>
    {
        MADSCIENCEEntities msEntities = new MADSCIENCEEntities();
        public bool Agregar(TrabajadorEntity t)
        {
            try
            {
                tb_trabajador tbTrabajador = new tb_trabajador();
                tbTrabajador.flg_estado = t.Estado;
                tbTrabajador.nombre = t.Nombre;
                msEntities.tb_trabajador.Add(tbTrabajador);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool Actualizar(TrabajadorEntity t)
        {
            try
            {
                tb_trabajador tbTrabajador = (from tr in msEntities.tb_trabajador
                                              where tr.id_trabajador == t.Codigo
                                              select tr).FirstOrDefault();

                tbTrabajador.id_trabajador = t.Codigo;
                tbTrabajador.nombre = t.Nombre;
                tbTrabajador.flg_estado = t.Estado;
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TrabajadorEntity t)
        {
            try
            {
                tb_trabajador tbTrabajador = (from tr in msEntities.tb_trabajador
                                              where tr.id_trabajador == t.Codigo
                                              select tr).FirstOrDefault();


                msEntities.tb_trabajador.Remove(tbTrabajador);
                msEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TrabajadorEntity> ListarTodos()
        {
            List<TrabajadorEntity> objListaTrabajador = new List<TrabajadorEntity>();
            try
            {
                var query = msEntities.tb_trabajador.ToList();
                foreach (var resultado in query)
                {
                    TrabajadorEntity objTrabajador = new TrabajadorEntity();
                    objTrabajador.Codigo = resultado.id_trabajador;
                    objTrabajador.Estado = resultado.flg_estado;
                    objTrabajador.Nombre = resultado.nombre;
                    objListaTrabajador.Add(objTrabajador);
                }
                return objListaTrabajador;
            }
            catch
            {
                return null;
            }
        }

        public TrabajadorEntity Consultar(object codigo)
        {
            try
            {
                int codi = Convert.ToInt32(codigo.ToString());
                tb_trabajador tbTrabajador = (from tr in msEntities.tb_trabajador
                                              where tr.id_trabajador == codi
                                              select tr).FirstOrDefault();

                TrabajadorEntity objTrabajador = new TrabajadorEntity();
                objTrabajador.Codigo = tbTrabajador.id_trabajador;
                objTrabajador.Estado = tbTrabajador.flg_estado;
                objTrabajador.Nombre = tbTrabajador.nombre;
                return objTrabajador;
               
            }
            catch
            {
                return null;
            }
        }


        public int Insertar(TrabajadorEntity t)
        {
            throw new NotImplementedException();
        }


        public List<TrabajadorEntity> ListarFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}

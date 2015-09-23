using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;

namespace MadScienceBL
{
    public class UsuarioBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<UsuarioEntity> servicioUsuario;

        public UsuarioBL()
        {
            servicioUsuario = servicio.getUsuario(Constantes.COM);
        }

        public UsuarioEntity ValidarUsuario(String usuario, String contraseña)
        {
            List<UsuarioEntity> objListaUsuario = servicioUsuario.ListarTodos();
            UsuarioEntity objUsuario = objListaUsuario.Where(tx => tx.Login == usuario
                                                            && tx.Contraseña == contraseña).FirstOrDefault();
            return objUsuario;
        }
        public bool CambiarContraseña(String usuario, String contraseñaAntigua,String contraseñaNueva)
        {
            List<UsuarioEntity> objListaUsuario = servicioUsuario.ListarTodos();
            UsuarioEntity objUsuario = objListaUsuario.Where(tx => tx.Login == usuario
                                                            && tx.Contraseña == contraseñaAntigua).FirstOrDefault();
            if (objUsuario != null)
            {
                objUsuario.Contraseña = contraseñaNueva;
                if (servicioUsuario.Actualizar(objUsuario))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<UsuarioEntity> ListarTodo()
        {
            return servicioUsuario.ListarTodos();
        }

        public bool Agregar(UsuarioEntity objUsuario)
        {
            return servicioUsuario.Agregar(objUsuario);
        }

        public bool ValidarLogin(String usuario)
        {
            UsuarioEntity obj = servicioUsuario.ListarTodos().Where(us => us.Login == usuario).FirstOrDefault();
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UsuarioEntity Consultar(int codigo)
        {
            return servicioUsuario.Consultar(codigo);
        }

        public bool Actualizar(UsuarioEntity obj)
        {
            return servicioUsuario.Actualizar(obj);
        }
    }
}

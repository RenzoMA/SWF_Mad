using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class UsuarioEntity
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String apePat;

        public String ApePat
        {
            get { return apePat; }
            set { apePat = value; }
        }
        private String apeMat;

        public String ApeMat
        {
            get { return apeMat; }
            set { apeMat = value; }
        }
        private String estado;

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private String contraseña;

        public String Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        private String login;

        public String Login
        {
            get { return login; }
            set { login = value; }
        }


    }
}

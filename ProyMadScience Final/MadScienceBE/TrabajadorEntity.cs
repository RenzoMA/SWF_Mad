using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class TrabajadorEntity
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
        private String estado;

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int codigoZona;

        public int CodigoZona
        {
            get { return codigoZona; }
            set { codigoZona = value; }
        }
        private string nombreZona;

        public string NombreZona
        {
            get { return nombreZona; }
            set { nombreZona = value; }
        }


    }
}

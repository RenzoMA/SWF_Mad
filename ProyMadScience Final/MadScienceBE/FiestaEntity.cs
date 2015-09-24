using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class FiestaEntity
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int codigoTipoFiesta;

        public int CodigoTipoFiesta
        {
            get { return codigoTipoFiesta; }
            set { codigoTipoFiesta = value; }
        }

        string nombreTipo;

        public string NombreTipo
        {
            get { return nombreTipo; }
            set { nombreTipo = value; }
        }


        private string cuenta;

        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }


        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }


        private int codigoCebeEmpresa;

        public int CodigoCebeEmpresa
        {
            get { return codigoCebeEmpresa; }
            set { codigoCebeEmpresa = value; }
        }

    }
}

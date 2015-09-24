using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class DetalleReservaEntity
    {
        private int codigoReserva;

        public int CodigoReserva
        {
            get { return codigoReserva; }
            set { codigoReserva = value; }
        }
        private int codigoFiesta;

        public int CodigoFiesta
        {
            get { return codigoFiesta; }
            set { codigoFiesta = value; }
        }

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }


        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        private string nombreFiesta;

        public string NombreFiesta
        {
            get { return nombreFiesta; }
            set { nombreFiesta = value; }
        }

        private int cantidadAsignados;

        public int CantidadAsignados
        {
            get { return cantidadAsignados; }
            set { cantidadAsignados = value; }
        }

        private string factCuenta;

        public string FactCuenta
        {
            get { return factCuenta; }
            set { factCuenta = value; }
        }
        private string factCliente;

        public string FactCliente
        {
            get { return factCliente; }
            set { factCliente = value; }
        }
        private double factPrecio;

        public double FactPrecio
        {
            get { return factPrecio; }
            set { factPrecio = value; }
        }

        private string factNomCli;

        public string FactNomCli
        {
            get { return factNomCli; }
            set { factNomCli = value; }
        }

    }
}

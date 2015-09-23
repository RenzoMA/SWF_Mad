using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class AsignacionEntity
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private int codigoDetalle;

        public int CodigoDetalle
        {
            get { return codigoDetalle; }
            set { codigoDetalle = value; }
        }
        private int codigoTrabajador;

        public int CodigoTrabajador
        {
            get { return codigoTrabajador; }
            set { codigoTrabajador = value; }
        }
        private int codigoTipoPago;

        public int CodigoTipoPago
        {
            get { return codigoTipoPago; }
            set { codigoTipoPago = value; }
        }
        private double monto;

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private DateTime fechaReserva;

        public DateTime FechaReserva
        {
            get { return fechaReserva; }
            set { fechaReserva = value; }
        }
        private DateTime fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        private string userCrea;

        public string UserCrea
        {
            get { return userCrea; }
            set { userCrea = value; }
        }

        private double horaInicio;

        public double HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }
        private double horaFin;

        public double HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }

        private int codigoReserva;

        public int CodigoReserva
        {
            get { return codigoReserva; }
            set { codigoReserva = value; }
        }

        private string nombreTrabajador;

        public string NombreTrabajador
        {
            get { return nombreTrabajador; }
            set { nombreTrabajador = value; }
        }

        private string nombreTipoPago;

        public string NombreTipoPago
        {
            get { return nombreTipoPago; }
            set { nombreTipoPago = value; }
        }

        private string nombreFiesta;

        public string NombreFiesta
        {
            get { return nombreFiesta; }
            set { nombreFiesta = value; }
        }

        private string nombreTienda;

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }

        private string nombreTipoFiesta;

        public string NombreTipoFiesta
        {
            get { return nombreTipoFiesta; }
            set { nombreTipoFiesta = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private double montoMovilidad;

        public double MontoMovilidad
        {
            get { return montoMovilidad; }
            set { montoMovilidad = value; }
        }

        private int? tipoMovilidad;

        public int? TipoMovilidad
        {
            get { return tipoMovilidad; }
            set { tipoMovilidad = value; }
        }


    }
}

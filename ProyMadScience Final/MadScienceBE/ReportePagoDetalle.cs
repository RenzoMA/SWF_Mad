using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class ReportePagoDetalle
    {
        private string nombreTrabajador;

        public string NombreTrabajador
        {
            get { return nombreTrabajador; }
            set { nombreTrabajador = value; }
        }
        private string nombreTienda;

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }
        private DateTime fechaReserva;

        public DateTime FechaReserva
        {
            get { return fechaReserva; }
            set { fechaReserva = value; }
        }
        private string horario;

        public string Horario
        {
            get { return horario; }
            set { horario = value; }
        }
        private string nombreFiesta;

        public string NombreFiesta
        {
            get { return nombreFiesta; }
            set { nombreFiesta = value; }
        }
        private string tipoFiesta;

        public string TipoFiesta
        {
            get { return tipoFiesta; }
            set { tipoFiesta = value; }
        }
        private double pago;

        public double Pago
        {
            get { return pago; }
            set { pago = value; }
        }



    }
}

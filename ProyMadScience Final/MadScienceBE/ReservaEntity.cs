using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceBE
{
    public class ReservaEntity
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private int codigoTipoEvento;

        public int CodigoTipoEvento
        {
            get { return codigoTipoEvento; }
            set { codigoTipoEvento = value; }
        }
        private int? codigoTienda;

        public int? CodigoTienda
        {
            get { return codigoTienda; }
            set { codigoTienda = value; }
        }
        private int codigoUsuario;

        public int CodigoUsuario
        {
            get { return codigoUsuario; }
            set { codigoUsuario = value; }
        }
        private string nombreNiño;

        public string NombreNiño
        {
            get { return nombreNiño; }
            set { nombreNiño = value; }
        }
        private DateTime? fechaNacimiento;

        public DateTime? FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private string nombreCliente;

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }
        private DateTime fechaCelebracion;

        public DateTime FechaCelebracion
        {
            get { return fechaCelebracion; }
            set { fechaCelebracion = value; }
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
        private string modeloTorta;

        public string ModeloTorta
        {
            get { return modeloTorta; }
            set { modeloTorta = value; }
        }
        private string saborTorta;

        public string SaborTorta
        {
            get { return saborTorta; }
            set { saborTorta = value; }
        }
        private string obsTorta;

        public string ObsTorta
        {
            get { return obsTorta; }
            set { obsTorta = value; }
        }
        private int invitados;

        public int Invitados
        {
            get { return invitados; }
            set { invitados = value; }
        }
        private string obsGeneral;

        public string ObsGeneral
        {
            get { return obsGeneral; }
            set { obsGeneral = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }


        private string usuarioCrea;

        public string UsuarioCrea
        {
            get { return usuarioCrea; }
            set { usuarioCrea = value; }
        }
        private DateTime fechaCrea;

        public DateTime FechaCrea
        {
            get { return fechaCrea; }
            set { fechaCrea = value; }
        }

        private String nombreTienda;

        public String NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }

        private String nombreTipo;

        public String NombreTipo
        {
            get { return nombreTipo; }
            set { nombreTipo = value; }
        }

        private List<DetalleReservaEntity> listaDetalle;

        public List<DetalleReservaEntity> ListaDetalle
        {
            get { return listaDetalle; }
            set { listaDetalle = value; }
        }

        private string fiestaDoble;

        public string FiestaDoble
        {
            get { return fiestaDoble; }
            set { fiestaDoble = value; }
        }

        private string ultimaHora;

        public string UltimaHora
        {
            get { return ultimaHora; }
            set { ultimaHora = value; }
        }

    }
}

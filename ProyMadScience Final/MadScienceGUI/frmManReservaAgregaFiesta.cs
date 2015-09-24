using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;
using MadScienceBE;

namespace MadScienceGUI
{
    public partial class frmManReservaAgregaFiesta : Form
    {
        FiestaBL servicioFiesta = new FiestaBL();
        TipoFiestaBL servicioTipoFiesta = new TipoFiestaBL();
        DetalleReservaBL servicioDetalle = new DetalleReservaBL();
        ReservaEntity objReserva;
        ReservaBL servicioReserva = new ReservaBL();
        TiendaBL servicioTienda = new TiendaBL();
        TipoEventoBL servicioTipoEvento = new TipoEventoBL();
        public frmManReservaAgregaFiesta()
        {
            InitializeComponent();
        }
        private int codigoReserva;

        public int CodigoReserva
        {
            get { return codigoReserva; }
            set { codigoReserva = value; }
        }

        private int codigoTipoEvento;

        public int CodigoTipoEvento
        {
            get { return codigoTipoEvento; }
            set { codigoTipoEvento = value; }
        }

        private void frmManReservaAgregaFiesta_Load(object sender, EventArgs e)
        {
            objReserva = servicioReserva.Consultar(codigoReserva);
            cboTipo.DisplayMember="nombre";
            cboTipo.ValueMember="codigo";
            cboTipo.DataSource = servicioTipoFiesta.ListarTodos();
            cboFiesta.DisplayMember = "nombre";
            cboFiesta.ValueMember = "codigo";
            int codigoTipoFiesta = Convert.ToInt16(cboTipo.SelectedValue.ToString());
            cboFiesta.DataSource = servicioFiesta.ListarEventoAndTipo(codigoTipoEvento, codigoTipoFiesta);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (objReserva.FechaCelebracion >= DateTime.Now.Date.AddDays(-6))
            {
                if (cboFiesta.SelectedValue != null)
                {
                    DetalleReservaEntity objDetalle = new DetalleReservaEntity();
                    objDetalle.CodigoReserva = codigoReserva;
                    objDetalle.CodigoFiesta = Convert.ToInt16(cboFiesta.SelectedValue.ToString());
                    objDetalle.FechaCreacion = DateTime.Now;
                    objDetalle.Usuario = Sesion.UsuarioActual.Login;
                    if (objReserva.CodigoTienda != null)
                    {
                        TiendaEntity objTienda = servicioTienda.Consultar((int)objReserva.CodigoTienda);
                        objDetalle.FactCliente = objTienda.CebeTienda;
                        objDetalle.FactNomCli = objTienda.Nombre;
                    }
                    else
                    {
                        TipoEventoEntity objTipoEvento = servicioTipoEvento.Consultar(objReserva.CodigoTipoEvento);
                        objDetalle.FactCliente = objTipoEvento.Nombre.ToUpper().Trim();
                        objDetalle.FactNomCli = objReserva.NombreCliente;
                    }
                    FiestaEntity objFiesta = servicioFiesta.Consultar(Convert.ToInt16(cboFiesta.SelectedValue.ToString()));
                    objDetalle.FactCuenta = objFiesta.Cuenta;
                    objDetalle.FactPrecio = objFiesta.Precio;


                    if (servicioDetalle.Agregar(objDetalle))
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Aviso");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ya no se permite realizar modificaciones", "Aviso");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int codigoTipoFiesta = Convert.ToInt16(cboTipo.SelectedValue.ToString());
            cboFiesta.DataSource = servicioFiesta.ListarEventoAndTipo(codigoTipoEvento, codigoTipoFiesta);
        }

    }
}

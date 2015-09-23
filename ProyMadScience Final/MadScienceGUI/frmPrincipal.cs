using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MadScienceGUI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Conectado como: " + Sesion.UsuarioActual.Nombre + " " + Sesion.UsuarioActual.ApePat + " " + Sesion.UsuarioActual.ApeMat;
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    //ctlMDI.BackColor = this.BackColor;
                    ctlMDI.BackgroundImage = MadScienceGUI.Properties.Resources.KRIEGER___v7;
                    ctlMDI.BackColor = Color.White;

                }
                catch
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioContraseña frm = new frmCambioContraseña();
            frm.MdiParent = this;
            frm.Show();
        }

        private void zonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManZona frm = new frmManZona();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManTienda frm = new frmManTienda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tipoEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManTipoEvento frm = new frmManTipoEvento();
            frm.MdiParent = this;
            frm.Show();

        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    //ctlMDI.BackColor = this.BackColor;
                    ctlMDI.BackgroundImage = MadScienceGUI.Properties.Resources.KRIEGER___v7;

                }
                catch
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManUsuario frm = new frmManUsuario();
            frm.MdiParent = this;
            frm.Show();
           
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManTrabajador frm = new frmManTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void fiestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManFiesta frm = new frmManFiesta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tipoPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManTipoPago frm = new frmManTipoPago();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tipoFiestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManTipoFiesta frm = new frmManTipoFiesta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManReserva frm = new frmManReserva();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManTorta frm = new frmManTorta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void saborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManSabor frm = new frmManSabor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void disponibilidadEspecialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaDisponibilidadEspecialidad frm = new frmConsultaDisponibilidadEspecialidad();
            frm.MdiParent = this;
            frm.Show();
        }
        private void reporteTortasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmRptTorta frm = new frmRptTorta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporteAsignacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptAsignaciones frm = new frmRptAsignaciones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPago frm = new frmRptPago();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporteTiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptTienda frm = new frmRptTienda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportePagoDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPagoDetalle frm = new frmRptPagoDetalle();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporteFiestasPorTiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptDetalleFiestaTienda frm = new frmRptDetalleFiestaTienda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msg = MessageBox.Show("¿Seguro de salir?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (msg == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void movilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManMovilidad frm = new frmManMovilidad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportePagosMovilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPagoMovilidad frm = new frmRptPagoMovilidad();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}

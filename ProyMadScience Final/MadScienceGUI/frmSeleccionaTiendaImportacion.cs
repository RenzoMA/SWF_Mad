using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;

namespace MadScienceGUI
{
    public partial class frmSeleccionaTiendaImportacion : Form
    {
        TiendaBL servicioTienda = new TiendaBL();
        public frmSeleccionaTiendaImportacion()
        {
            InitializeComponent();
        }

        private void frmSeleccionaTiendaImportacion_Load(object sender, EventArgs e)
        {
            cboTienda.DisplayMember = "nombre";
            cboTienda.ValueMember = "codigo";
            cboTienda.DataSource = servicioTienda.ListarTodoOpciones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmManReserva.idTienda = "";
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboTienda.SelectedIndex > 0)
            {
                DialogResult pregunta = MessageBox.Show("¿Seguro de seleccionar la tienda " + servicioTienda.Consultar(Convert.ToInt16(cboTienda.SelectedValue.ToString())).Nombre+ "?", "aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.Yes)
                {
                    frmManReserva.idTienda = cboTienda.SelectedValue.ToString();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe elegir una tienda", "Aviso");
            }
        }
    }
}

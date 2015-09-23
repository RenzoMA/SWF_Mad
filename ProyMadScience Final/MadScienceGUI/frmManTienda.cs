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
    public partial class frmManTienda : Form
    {
        TiendaBL objTiendaBL;
        public frmManTienda()
        {
            InitializeComponent();
        }

        private void frmManTienda_Load(object sender, EventArgs e)
        {
            dgvTienda.AutoGenerateColumns = false;
            EnlazarDatos();
        }
        public void EnlazarDatos()
        {
            objTiendaBL = new TiendaBL();
            dgvTienda.DataSource = objTiendaBL.ListarTodos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManTiendaCrea frm = new frmManTiendaCrea();
            frm.ShowDialog();
            EnlazarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmManTiendaActualizar frm = new frmManTiendaActualizar();
            frm.Codigo = Convert.ToInt16(dgvTienda.SelectedRows[0].Cells["Codigo"].Value);
            frm.ShowDialog();
            EnlazarDatos();
        }

    }
}

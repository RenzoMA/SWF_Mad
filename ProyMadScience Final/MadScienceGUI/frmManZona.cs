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
    public partial class frmManZona : Form
    {
        ZonaBL objZonaBL;
        public frmManZona()
        {
            InitializeComponent();
        }

        private void frmManZona_Load(object sender, EventArgs e)
        {
            EnlazarDatos();
            
        }
        public void EnlazarDatos()
        {
            objZonaBL = new ZonaBL();
            dgvZona.DataSource = objZonaBL.ListarTodos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmManZonaCrea frm = new frmManZonaCrea();
            frm.ShowDialog();
            EnlazarDatos();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvZona.SelectedRows.Count > 0)
            {
                frmManZonaActualiza frm = new frmManZonaActualiza();
                frm.Codigo = Convert.ToInt16(dgvZona.SelectedRows[0].Cells["Codigo"].Value);
                frm.ShowDialog();
                EnlazarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro", "Aviso");
            }
        }
    }
}

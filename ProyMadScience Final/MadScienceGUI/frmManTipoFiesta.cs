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
    public partial class frmManTipoFiesta : Form
    {
        TipoFiestaBL objTipoFiesta;
        public frmManTipoFiesta()
        {
            InitializeComponent();
        }
        public void Enlazar()
        {
            objTipoFiesta = new TipoFiestaBL();
            dgvTipoFiestas.DataSource = objTipoFiesta.ListarTodos();
        }

        private void frmManTipoFiesta_Load(object sender, EventArgs e)
        {
            Enlazar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManTipoFiestaCrea frm = new frmManTipoFiestaCrea();
            frm.ShowDialog();
            Enlazar();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvTipoFiestas.Rows.Count > 0)
            {
                frmManTipoFiestaActualiza frm = new frmManTipoFiestaActualiza();
                frm.Codigo = Convert.ToInt32(dgvTipoFiestas.SelectedRows[0].Cells["codigo"].Value.ToString());
                frm.ShowDialog();
                Enlazar();
            }
            else
            {
                MessageBox.Show("Seleccione al menos un registro", "Aviso");
            }
        }
    }
}

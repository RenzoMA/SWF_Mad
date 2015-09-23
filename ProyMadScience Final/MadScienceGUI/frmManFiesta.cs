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
    public partial class frmManFiesta : Form
    {
        FiestaBL objFiesta = new FiestaBL();
        public frmManFiesta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String filtro = txtNombre.Text.ToUpper();
            dgvFiestas.DataSource = objFiesta.ListarFiltro(filtro);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManFiestaCrea frm = new frmManFiestaCrea();
            frm.ShowDialog();
            EnlazarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvFiestas.SelectedRows.Count > 0)
            {
                frmManFiestaActualiza frm = new frmManFiestaActualiza();
                frm.Codigo = Convert.ToInt32(dgvFiestas.SelectedRows[0].Cells["codigo"].Value.ToString());
                frm.ShowDialog();
                EnlazarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Aviso");
            }
        }
        public void EnlazarDatos()
        {
            objFiesta = new FiestaBL();
            dgvFiestas.DataSource = objFiesta.ListarTodos();
        }

        private void frmManFiesta_Load(object sender, EventArgs e)
        {
            dgvFiestas.AutoGenerateColumns = false;
            EnlazarDatos();
        }

        private void dgvFiestas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigo = Convert.ToInt16(dgvFiestas.Rows[e.RowIndex].Cells["codigo"].Value.ToString());
                frmManEventoFiesta frm = new frmManEventoFiesta();
                frm.Codigo = codigo;
                frm.ShowDialog();
                EnlazarDatos();
            }
            if (e.ColumnIndex == 1)
            {
                int codigo = Convert.ToInt16(dgvFiestas.Rows[e.RowIndex].Cells["codigo"].Value.ToString());
                frmPagoFiesta frm = new frmPagoFiesta();
                frm.Codigo = codigo;
                frm.ShowDialog();
                EnlazarDatos();
            }
        }
    }
}

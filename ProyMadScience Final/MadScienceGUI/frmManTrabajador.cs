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
    public partial class frmManTrabajador : Form
    {

        TrabajadorBL objTrabajador;

        public frmManTrabajador()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManTrabajadorCrea frm = new frmManTrabajadorCrea();
            frm.ShowDialog();
            EnlazarDatos();
        }

        private void frmManTrabajador_Load(object sender, EventArgs e)
        {
            objTrabajador = new TrabajadorBL();
            dgvTrabajadores.AutoGenerateColumns = false;
            EnlazarDatos();
        }
        public void EnlazarDatos()
        {
            dgvTrabajadores.DataSource = objTrabajador.ListarTodos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt16(dgvTrabajadores.SelectedRows[0].Cells["codigo"].Value.ToString());
                frmManTrabajadorActualizar frm = new frmManTrabajadorActualizar();
                frm.Codigo = codigo;
                frm.ShowDialog();
                EnlazarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Aviso");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.ToUpper().Trim();
            dgvTrabajadores.DataSource = objTrabajador.ListarPorNombre(filtro);
        }

        private void dgvTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigo = Convert.ToInt32(dgvTrabajadores.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());
                frmDisponibilidad frm = new frmDisponibilidad();
                frm.Codigo = codigo;
                frm.ShowDialog();
            }
            if (e.ColumnIndex == 1)
            {
                int codigo = Convert.ToInt32(dgvTrabajadores.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());
                frmEspecialidad frm = new frmEspecialidad();
                frm.Codigo = codigo;
                frm.ShowDialog();
            }
        }
    }
}

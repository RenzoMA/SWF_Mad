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
    public partial class frmManUsuario : Form
    {
        UsuarioBL objUsuario;
        public frmManUsuario()
        {
            InitializeComponent();
        }

        private void frmManUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            EnlazarDatos();
        }
        public void EnlazarDatos()
        {
            objUsuario = new UsuarioBL();
            dgvUsuarios.DataSource = objUsuario.ListarTodo();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmManUsuarioCrea frm = new frmManUsuarioCrea();
            frm.ShowDialog();
            EnlazarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                frmManUsuarioActualiza frm = new frmManUsuarioActualiza();
                frm.Codigo = Convert.ToInt16(dgvUsuarios.SelectedRows[0].Cells["Codigo"].Value.ToString());
                frm.ShowDialog();
                EnlazarDatos();
            }
        }
        
    }
}

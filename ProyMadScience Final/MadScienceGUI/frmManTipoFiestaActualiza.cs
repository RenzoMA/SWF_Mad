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
    public partial class frmManTipoFiestaActualiza : Form
    {
        TipoFiestaBL objTipoFiestaBL = new TipoFiestaBL();
        TipoFiestaEntity objTipoFiesta;
        public frmManTipoFiestaActualiza()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void frmManTipoFiestaActualiza_Load(object sender, EventArgs e)
        {
            objTipoFiesta = objTipoFiestaBL.Consultar(codigo);
            txtNombre.Text = objTipoFiesta.Nombre;
            cboEstado.SelectedIndex = objTipoFiesta.Estado == "A" ? 0 : 1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Trim().Equals(String.Empty))
            {
                objTipoFiesta.Nombre = txtNombre.Text;
                objTipoFiesta.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
                if (objTipoFiestaBL.Actualizar(objTipoFiesta))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error, verifique", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos", "Aviso");
            }
        }


    }
}

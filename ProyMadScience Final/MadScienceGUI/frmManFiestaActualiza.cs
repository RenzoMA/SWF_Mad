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
    public partial class frmManFiestaActualiza : Form
    {
        TipoFiestaBL objTipoFiesta = new TipoFiestaBL();
        FiestaBL objFiestaBL = new FiestaBL();
        FiestaEntity objFiesta;

        public frmManFiestaActualiza()
        {
            InitializeComponent();
        }

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void frmManFiestaActualiza_Load(object sender, EventArgs e)
        {
            objFiesta = objFiestaBL.Consultar(codigo);
            txtNombre.Text = objFiesta.Nombre;
            cboEstado.SelectedIndex = objFiesta.Estado == "A" ? 0 : 1;
            cboTipo.DataSource = objTipoFiesta.ListarTodos();
            cboTipo.ValueMember = "Codigo";
            cboTipo.DisplayMember = "Nombre";
            cboTipo.SelectedValue = objFiesta.CodigoTipoFiesta;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Trim().Equals(String.Empty))
            {
                objFiesta.Nombre = txtNombre.Text.ToUpper().Trim();
                objFiesta.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
                objFiesta.CodigoTipoFiesta = Convert.ToInt32(cboTipo.SelectedValue.ToString());
                if (objFiestaBL.ValidarNombreFiesta(objFiesta.Nombre,objFiesta.Codigo))
                {
                    if (objFiestaBL.Actualizar(objFiesta))
                    {
                        MessageBox.Show("Registro actualizado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El nombre de la fiesta ya existe", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos", "Aviso");
            }
        }

    }
}

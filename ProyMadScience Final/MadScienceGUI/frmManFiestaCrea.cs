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
    public partial class frmManFiestaCrea : Form
    {
        FiestaBL objFiestaBL = new FiestaBL();
        TipoFiestaBL objTipoFiesta = new TipoFiestaBL();
        public frmManFiestaCrea()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Trim().Equals(String.Empty))
            {
                FiestaEntity objFiesta = new FiestaEntity();
                objFiesta.Nombre = txtNombre.Text.ToUpper().Trim();
                objFiesta.Estado = "A";
                objFiesta.CodigoTipoFiesta = Convert.ToInt32(cboTipo.SelectedValue.ToString());
                if (objFiestaBL.ValidarNombreFiesta(objFiesta.Nombre,0))
                {
                    if (objFiestaBL.Agregar(objFiesta))
                    {
                        MessageBox.Show("Se realizo el proceso correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Atencion!! hubo un error", "Aviso");
                    }

                }
                else
                {
                    MessageBox.Show("El nombre de fiesta ingresado ya existe", "Aviso");
                }

            }
            else
            {
                MessageBox.Show("Debe completar los campos", "Aviso");
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManFiestaCrea_Load(object sender, EventArgs e)
        {
            cboTipo.DataSource = objTipoFiesta.ListarTodos();
            cboTipo.ValueMember = "Codigo";
            cboTipo.DisplayMember = "Nombre";
        }
    }
}

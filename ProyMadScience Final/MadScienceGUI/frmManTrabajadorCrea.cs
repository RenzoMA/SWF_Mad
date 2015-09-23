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
    public partial class frmManTrabajadorCrea : Form
    {
        TrabajadorBL objTrabajadorBL = new TrabajadorBL();
        ZonaBL objZonaBL = new ZonaBL();
        public frmManTrabajadorCrea()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(txtNombre.Text.Trim(),txtApePat.Text.Trim(),txtApeMat.Text.Trim()))
            {
                String nombre = txtNombre.Text.ToUpper().Trim()+" "+txtApePat.Text.ToUpper().Trim()+" "+txtApeMat.Text.ToUpper().Trim();
                TrabajadorEntity objTrabajador = new TrabajadorEntity();
                objTrabajador.Nombre = nombre;
                objTrabajador.Estado = "A";
                objTrabajador.CodigoZona = Convert.ToInt16(cboZona.SelectedValue.ToString());
                if (objTrabajadorBL.ValidarNombre(objTrabajador.Nombre))
                {
                    if (objTrabajadorBL.Agregar(objTrabajador))
                    {
                        MessageBox.Show("Agregado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El nombre ingresado ya se encuentra registrado", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los datos", "Aviso");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidarCampoVacio(params string[] list)
        {
            foreach (string campo in list)
            {
                if (campo.Equals(string.Empty)) { return false; }
            }
            return true;
        }

        private void frmManTrabajadorCrea_Load(object sender, EventArgs e)
        {
            cboZona.DataSource = objZonaBL.ListarTodos();
            cboZona.DisplayMember = "nombre";
            cboZona.ValueMember = "codigo";

        }
    }
}

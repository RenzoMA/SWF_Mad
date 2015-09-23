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
    public partial class frmManUsuarioCrea : Form
    {
        UsuarioBL objUsuarioBL;
        public frmManUsuarioCrea()
        {
            InitializeComponent();
            objUsuarioBL = new UsuarioBL();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(txtApeMat.Text, txtApePat.Text, txtContraseña.Text, txtLogin.Text, txtNombre.Text))
            {
                UsuarioEntity objUsuario = new UsuarioEntity();
                objUsuario.ApePat = txtApePat.Text.ToUpper().Trim();
                objUsuario.ApeMat = txtApeMat.Text.ToUpper().Trim();
                objUsuario.Contraseña = txtContraseña.Text;
                objUsuario.Estado = "A";
                objUsuario.Login = txtLogin.Text.ToUpper().Trim();
                objUsuario.Nombre = txtNombre.Text.ToUpper().Trim();
                if (objUsuarioBL.ValidarLogin(objUsuario.Login))
                {
                    if (objUsuarioBL.Agregar(objUsuario))
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Verifique");
                    }
                }
                else
                {
                    MessageBox.Show("El login ingresado ya existe", "Aviso");
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar todos los campos", "Aviso");
            }
        }
        private bool ValidarCampoVacio(params string[] list)
        {
            foreach (string campo in list)
            {
                if (campo.Trim().Equals(string.Empty)) { return false; }
            }
            return true;
        }
    }
}

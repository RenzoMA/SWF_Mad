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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           
        }
        private bool ValidarCampoVacio(params string[] list)
        {
            foreach (string campo in list)
            {
                if (campo.Equals(string.Empty)) { return false; }
            }
            return true;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampoVacio(txtContraseña.Text.Trim(), txtUsuario.Text.Trim()))
                {
                    UsuarioBL objUsuarioBL = new UsuarioBL();
                    UsuarioEntity objUsuario = objUsuarioBL.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
                    if (objUsuario != null)
                    {
                        this.Hide();
                        Sesion.UsuarioActual = objUsuario;
                        frmPrincipal frm = new frmPrincipal();
                        frm.ShowDialog();
                        this.Show();
                        txtContraseña.Text = "";
                        txtUsuario.Text = "";
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void txtContraseña_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnIngresar.PerformClick();
            }
        }
    }
}

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
    public partial class frmManUsuarioActualiza : Form
    {
        UsuarioEntity objUsuario;
        UsuarioBL objUsuarioBL;
        public frmManUsuarioActualiza()
        {
            InitializeComponent();
            objUsuarioBL = new UsuarioBL();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void frmManUsuarioActualiza_Load(object sender, EventArgs e)
        {
            objUsuario = objUsuarioBL.Consultar(codigo);
            txtApeMat.Text = objUsuario.ApeMat;
            txtApePat.Text = objUsuario.ApePat;
            txtContraseña.Text = objUsuario.Contraseña;
            txtLogin.Text = objUsuario.Login;
            txtNombre.Text = objUsuario.Nombre;
            switch (objUsuario.Estado)
            {
                case "A": cboEstado.SelectedIndex = 0; break;
                case "I": cboEstado.SelectedIndex = 1; break;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(txtApeMat.Text, txtApePat.Text, txtContraseña.Text, txtLogin.Text, txtNombre.Text))
            {

                if (objUsuario.Login != txtLogin.Text.ToUpper().Trim())
                {
                    if (!objUsuarioBL.ValidarLogin(txtLogin.Text.ToUpper().Trim()))
                    {
                        MessageBox.Show("El login ingresado ya esta en uso","Aviso");
                        return;
                    }
                }
                objUsuario.ApeMat = txtApeMat.Text.ToUpper().Trim();
                objUsuario.ApePat = txtApePat.Text.ToUpper().Trim();
                objUsuario.Contraseña = txtContraseña.Text.Trim();
                objUsuario.Login = txtLogin.Text.ToUpper().Trim();
                objUsuario.Nombre = txtNombre.Text.ToUpper().Trim();
                objUsuario.Estado = cboEstado.Text == "Activo" ? "A" : "I";
                if (objUsuarioBL.Actualizar(objUsuario))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error, verifique", "Aviso");
                }
                
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Aviso");
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

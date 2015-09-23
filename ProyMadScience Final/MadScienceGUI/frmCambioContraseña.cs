using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBE;
using MadScienceBL;

namespace MadScienceGUI
{
    public partial class frmCambioContraseña : Form
    {
        public frmCambioContraseña()
        {
            InitializeComponent();
        }
        private bool CompararContraseña(String contraseña, String confirmacion)
        {
            if (contraseña.Equals(String.Empty))
            {
                return false;
            }
            if (contraseña.Equals(confirmacion))
            {
                return true;
            }
            return false;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioEntity objUsuario = Sesion.UsuarioActual;
            UsuarioBL objUsuarioBL = new UsuarioBL();
            if (CompararContraseña(txtNuevoPassword.Text, txtConfPassword.Text))
            {
                if (objUsuarioBL.CambiarContraseña(objUsuario.Login, txtPasswordActual.Text, txtNuevoPassword.Text))
                {
                    MessageBox.Show("Contraseña modificada correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error, verifique los datos","Aviso");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Aviso");
            }
        }
    }
}

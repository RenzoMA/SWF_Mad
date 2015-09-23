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
    public partial class frmManMovilidadCrea : Form
    {
        TipoMovilidadBL objMovilidad = new TipoMovilidadBL();
        public frmManMovilidadCrea()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text.ToUpper().Trim();
            Double monto = Convert.ToDouble(txtMonto.Text.Trim());
            TipoMovilidadEntity objMovilidadEntity = new TipoMovilidadEntity();
            objMovilidadEntity.Des_nombre = nombre;
            objMovilidadEntity.Monto = monto;
            if (objMovilidad.Agregar(objMovilidadEntity))
            {
                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error, verifique");
            }

        }
        private void ValidarNumero(object sender, KeyPressEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }
    }
}

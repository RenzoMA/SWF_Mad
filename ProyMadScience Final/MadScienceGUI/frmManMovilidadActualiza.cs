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
    public partial class frmManMovilidadActualiza : Form
    {
        TipoMovilidadEntity objTipo;
        TipoMovilidadBL objMovilidadBL = new TipoMovilidadBL();
        public frmManMovilidadActualiza()
        {
            InitializeComponent();
        }
        private Int16 codigoMovilidad;

        public Int16 CodigoMovilidad
        {
            get { return codigoMovilidad; }
            set { codigoMovilidad = value; }
        }

        private void frmManMovilidadActualiza_Load(object sender, EventArgs e)
        {
            objTipo = objMovilidadBL.Consultar(codigoMovilidad);
            txtCodigo.Text = objTipo.CodigoMovilidad.ToString();
            txtCosto.Text = objTipo.Monto.ToString();
            txtNombre.Text = objTipo.Des_nombre;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            objTipo.Des_nombre = txtNombre.Text.ToUpper().Trim();
            objTipo.Monto = Convert.ToDouble(txtCosto.Text);
            if (objMovilidadBL.Actualizar(objTipo))
            {
                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error", "Aviso");
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

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

    }
}

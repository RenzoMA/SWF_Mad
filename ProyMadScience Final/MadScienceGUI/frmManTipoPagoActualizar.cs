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
    public partial class frmManTipoPagoActualizar : Form
    {
        TipoPagoBL objTipoPagoBL = new TipoPagoBL();
        TipoPagoEntity objTipoPago;
        public frmManTipoPagoActualizar()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Trim().Equals(String.Empty))
            {
                objTipoPago.Nombre = txtNombre.Text.ToUpper().Trim();
                objTipoPago.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";

                if (objTipoPagoBL.ValidarNombre(objTipoPago.Nombre, objTipoPago.Codigo))
                {
                    if (objTipoPagoBL.Actualizar(objTipoPago))
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre ingresado ya esta registrado", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe validar los campos", "Aviso");
            }

        }

        private void frmManTipoPagoActualizar_Load(object sender, EventArgs e)
        {
            objTipoPago = objTipoPagoBL.Consultar(codigo);
            txtNombre.Text = objTipoPago.Nombre;
            cboEstado.SelectedIndex = objTipoPago.Estado == "A" ? 0 : 1;

        }

    }
}

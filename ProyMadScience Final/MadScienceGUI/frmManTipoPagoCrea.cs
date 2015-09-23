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
    public partial class frmManTipoPagoCrea : Form
    {
        TipoPagoBL objTipoPagoBL = new TipoPagoBL();
        public frmManTipoPagoCrea()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                String nombre = txtNombre.Text.ToUpper().Trim();
                if (objTipoPagoBL.ValidarNombre(nombre,0))
                {
                    TipoPagoEntity objTipoPago = new TipoPagoEntity();
                    objTipoPago.Estado = "A";
                    objTipoPago.Nombre = nombre;
                    if (objTipoPagoBL.Agregar(objTipoPago))
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Alerta!! Ha ocurrido un error", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un ingreso con este nombre", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos", "Aviso");
            }
            
            
            
            
        }
    }
}
